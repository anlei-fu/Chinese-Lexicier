using ConsoleApp1.Chinese.WordInfo;
using Fal.Nlp.Chinese;
using System.Collections.Generic;

namespace Test.Chinese.Grammer.Graphic
{
    public  class Vertex
    {
        public Vertex()
        { }
        public Vertex(_WordInnfo w)
        {
            Content = w;
        }
        /// <summary>
        /// 内容
        /// </summary>
        public _WordInnfo Content;
        /// <summary>
        /// 连接到的边
        /// </summary>
        public List<Edge> ConnectTo = new List<Edge>();
        /// <summary>
        /// 被连接到的边
        /// </summary>
        public List<Edge> BeConnected = new List<Edge>();
        /// <summary>
        /// 连接到的边 是否包含
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ConnectToContains(EdgeType t)
        {
            foreach (var item in ConnectTo)
                if (item.Type == t)
                    return true;
            return false;
        }
        /// <summary>
        ///被连接到的边 是否包含
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool BeConnectedContains(EdgeType t)
        {
            foreach (var item in ConnectTo)
                if (item.Type == t)
                    return true;
            return false;
        }
        /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="t"></param>
       public  void ChangeMaxType(WordType t)
        {
            MaxtypeRecorder.Add(Content.MaxType);
            Content.MaxType = t;
            IsMaxTypeChanged = true;
        }
        /// <summary>
        /// 标识主类型是否发生过更改
        /// </summary>
        public bool IsMaxTypeChanged { get; private set; }
        /// <summary>
        /// 记录修改过的类型
        /// </summary>
        public List<WordType> MaxtypeRecorder { get; private set; } = new List<WordType>();
       /// <summary>
       /// 标识名字是否被改变过
       /// </summary>
        public bool IsNameChanged { get; private set; }
        /// <summary>
        /// 记录修改过的名字
        /// </summary>
        public List<string> NameRecorder { get; private set; } = new List<string>();
        /// <summary>
        /// 修改名字
        /// 主要用于 有些单词的合并
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(string name)
        {
            IsNameChanged = true;
            NameRecorder.Add(Content.Name);
            Content.Name = name;
        }
        /// <summary>
        /// 得到最左边的节点
        /// </summary>
        /// <returns></returns>
        public Vertex GetLefestVertex()
        {
            return null;
        }
        /// <summary>
        /// 得到最右边的节点
        /// </summary>
        /// <returns></returns>
        public Vertex GetRIghtestVertex()
        {
            return null;
        }
        public bool IsAnd { get; private set; }

        public Vertex CreatAndVertext(IEnumerable<Vertex>ls,WordType t)
        {

            var v = new Vertex();
            v.Content = new _WordInnfo();
            v.Content.MaxType = t;
            v.IsAnd = true;
            foreach (var item in ls)
                v.ConnectTo.Add(new Edge(this, item, EdgeType.And));
            return v;
                 

        }

   






    }
}
