using Fal.Nlp.Chinese;
using System.Collections.Generic;
using Test.Chinese.Grammer.Graphic;
using static Test.Chinese.Helpers.Delegates;

namespace Test.Chinese.Grammer
{
    public  class BasicVertexesOperator
    {
        /// <summary>
        /// 记录输入节点
        /// </summary>
        protected List<Vertex> Vertexes;
        /// <summary>
        /// 当前位置
        /// </summary>
        public int CurrentPos { get;  set; }
        /// <summary>
        /// 当前节点
        /// </summary>
        public Vertex Current => Vertexes[CurrentPos];
        /// <summary>
        /// 前一个节点
        /// </summary>
        public    Vertex Previous => Vertexes[CurrentPos - 1];
        /// <summary>
        /// 后一个节点
        /// </summary>
        public Vertex Next => Vertexes[CurrentPos + 1];
        /// <summary>
        /// 是否处于最后
        /// </summary>
        protected bool isAtLast => CurrentPos == Vertexes.Count - 2;
        /// <summary>
        /// 是否是第一个节点
        /// </summary>
        protected bool isAtFirst => CurrentPos == 0;
        /// <summary>
        /// 是否拥有下一个节点
        /// </summary>
        public bool HasNext => CurrentPos + 1 < Vertexes.Count;
        /// <summary>
        /// 是否拥有前一个节点
        /// </summary>
        public bool HasPrevious => CurrentPos > 0;
        /// <summary>
        /// 最后一个节点
        /// </summary>
        protected Vertex Last => Vertexes[Vertexes.Count - 2];
        /// <summary>
        /// 起始节点
        /// </summary>
        protected Vertex First => Vertexes[0];
     
        /// <summary>
        /// 重置参数
        /// </summary>
        /// <param name="input"></param>
        protected void reset(List<Vertex> input)
        {
            Vertexes = input;
            CurrentPos = 1;
        }
        /// <summary>
        /// 改变当前类型
        /// </summary>
        /// <param name="t"></param>
        public void changeType(WordType t)
        {
            Vertexes[CurrentPos].ChangeMaxType(t);
            CurrentPos++;
        }
        /// <summary>
        /// 和前一个合并
        /// </summary>
        /// <param name="t"></param>
       public void mergeWithBefore(WordType t)
        {
            Vertexes[CurrentPos].ChangeName(Vertexes[CurrentPos - 1].Content.Name + Vertexes[CurrentPos].Content.Name);
            Vertexes[CurrentPos].ChangeMaxType(t);
            Vertexes.RemoveAt(CurrentPos - 1);
        }
        /// <summary>
        /// 和后一个合并
        /// </summary>
        /// <param name="t"></param>
        public     void mergeWithAfter(WordType t)
        {
            Vertexes[CurrentPos].ChangeName(Vertexes[CurrentPos].Content.Name + Vertexes[CurrentPos + 1].Content.Name);
            Vertexes[CurrentPos].ChangeMaxType(t);
            Vertexes.RemoveAt(CurrentPos + 1);
            CurrentPos++;

        }
        /// <summary>
        /// 前后都合并
        /// </summary>
        /// <param name="t"></param>
        public void mergeBothAfterAndBefore(WordType t)
        {
            Vertexes[CurrentPos].ChangeName(Vertexes[CurrentPos - 1].Content.Name + Vertexes[CurrentPos].Content.Name + Vertexes[CurrentPos + 1].Content.Name);
            Vertexes[CurrentPos].ChangeMaxType(t);
            Vertexes.RemoveAt(CurrentPos + 1);
            Vertexes.RemoveAt(CurrentPos - 1);
            CurrentPos++;
        }
        /// <summary>
        /// 什么都不做
        /// </summary>
        public void doNothing()
        {
            CurrentPos++;
        }
        /// <summary>
        /// 需要进行前后比较的未知的检测
        /// </summary>
        /// <returns></returns>
        public bool checkPosition() => CurrentPos > 0 || CurrentPos > Vertexes.Count - 1;
        /// <summary>
        /// 改变前一个的类型
        /// </summary>
        /// <param name="t"></param>
        public void changePreviousType(WordType t)
        {
            Previous.ChangeMaxType(t);
            CurrentPos++;
        }
        /// <summary>
        /// 改变后一个类型
        /// </summary>
        /// <param name="t"></param>
        public   void changeNextType(WordType t)
        {
            Next.ChangeMaxType(t);
            CurrentPos++;
        }
        /// <summary>
        /// 之前是否含有某种类型
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool BeforeHas(Contains c)
        {
            for (int i = CurrentPos - 1; i > 0; i--)
                if (c(Vertexes[i].Content.MaxType))
                    return true;
            return false;
        }
        /// <summary>
        /// 之后是否含有某种类型
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool AfterHas(Contains c)
        {
            for (int i = CurrentPos + 1; i < Vertexes.Count; i++)
                if (c(Vertexes[i].Content.MaxType))
                    return true;
            return false;
        }
        /// <summary>
        /// 得到 前方某种类型的最近位置
        /// 若 没有 返回 -1；
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int GetBeforeLatestPos(Contains c)
        {
            for (int i = CurrentPos - 1; i > 0; i--)
                if (c(Vertexes[i].Content.MaxType))
                    return i;
            return -1;

        }
        /// <summary>
        ///  得到 后方某种类型的最近位置
        /// 若 没有 返回 -1；
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
       public int GetAfterLatestPos(Contains c)
        {
            for (int i = CurrentPos + 1; i < Vertexes.Count; i++)
                if (c(Vertexes[i].Content.MaxType))
                    return i;
            return -1;
        }
        /// <summary>
        /// 统计某种类型的数量
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
       public int TypeCount(Contains c)
        {
            int t = 0;
            for (int i = 0; i < Vertexes.Count; i++)
                if (c(Vertexes[i].Content.MaxType))
                    ++t;
            return t;
        }

        
    }
}
