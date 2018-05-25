using System.Collections.Generic;
using Test.Chinese.Grammer.Graphic;

namespace Test.Chinese.Grammer.RelationAnalnizer.Revisers
{
    public abstract class BasicReviser:BasicVertexesOperator
    {

        /// <summary>
        /// 主函数需要被实现
        /// </summary>
        /// <param name="ls"></param>
        public abstract void Revise(List<Vertex> ls);
      
    }
}
