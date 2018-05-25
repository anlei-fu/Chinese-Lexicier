using ConsoleApp1.Chinese._Sentence._Sentences;
using ConsoleApp1.Chinese._Sentence._Struct;
using ConsoleApp1.Chinese.WordInfo;
using Fal.Chinese.Helpers;
using Fal.Chinese.InterFace;
using Fal.Nlp.Chinese;
using System.Collections.Generic;
using Test.Chinese.Grammer.Graphic;

namespace ConsoleApp1.Chinese._Sentence
{
    public  class SimpleSentence:BasicProperty<_WordInnfo>
    {
      
       /*************************
        * 所属句子
        * ****************************/
        public Sentence BelongTo { get; set; }
        /***********************
         * 是否完整
         * *********************/
        public bool IsComplete { get; set; }
        /************************
         * 是否正确
         * ***************************/
        public bool IsRight { get; set; }
        /**********************
         * 所包含的单词
         * ************************/
        public List<_WordInnfo> Words { get; set; } = new List<_WordInnfo>();
        /**************************
         * 句子类型
         * ***********************************************/
        public SimpleSentenceType SentenceType { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
        /***************************
         * 句子的位置信息
         * *******************************************/
        public Position Position { get; set; } = new Position();
        /********************
         * 单词总数
         * ****************************/
        public int Count => Words.Count;
        /****************
         * 有无上一句
         * *****************************/
        public bool HasPrevious => Previous!=null;
        /// <summary>
        /// 有无下一句
        /// </summary>
        public bool HasNext => Next!=null;
        /// <summary>
        /// 上一句
        /// </summary>
        public SimpleSentence Previous { get ; set ; }
        /// <summary>
        /// 下一句
        /// </summary>
        public SimpleSentence Next { get; set ; }
        /// <summary>
        /// 根节点
        /// </summary>
        public Vertex Root { get; set; }
       public void tag()
        {
            foreach (var item in Words)
            {
                if (item.Length == 1)
                {
                    if (item.Contains(WordType.Classifier))
                    {
                        var g = item.MaxType;
                        item.ClearTypeInfo();
                        item.Add(g);
                        continue;
                    }
                }
                var b = item.MaxType;
                item.ClearTypeInfo();
                item.Add(b);
            }

        }

        public string gettypestring()
        {
           
           var temp = "";
            foreach (var item in Words)
                temp += item.MaxType.ConvertWordTypeToString()+"-";
            return temp;

        }
        public string getwordstring()
        {
            var temp = "";
            foreach (var item in Words)
                temp += item.Name + "-";
            return temp;

        }
        public List<Vertex> ToVertexes()
        {
            var ls = new List<Vertex>();
            foreach (var item in Words)
                ls.Add(new Vertex(item));
            return ls;
        }

    }
}
