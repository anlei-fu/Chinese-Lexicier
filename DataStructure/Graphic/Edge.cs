using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Chinese.Grammer.Graphic
{
   public class Edge
    {
        public Edge(Vertex s,Vertex e,EdgeType t,bool isright=true)
        {
            Start = s;
            End = e;
            Type = t;
            IsRight = isright;
        }
        public EdgeType Type { get; set; }
        /// <summary>
        /// 标识是否是绝对的正确
        /// </summary>
        public bool IsRight { get; set; }
        /// <summary>
        /// 起始节点
        /// </summary>
        public Vertex Start { get; set; }
        /// <summary>
        /// 终止节点
        /// </summary>
        public Vertex End { get; set; }
        /// <summary>
        /// 标识两个节点在上下文中的位置关系
        /// </summary>
        public bool IsBeFore;
    }
}
