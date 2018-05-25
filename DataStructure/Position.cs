using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Chinese._Sentence._Struct
{
    /// <summary>
    /// 用于记录一些位置信息
    /// </summary>
    public class Position
    {
        public Position()
        { }
        public Position(int start, int end)
        {
            Start = start;
            End = end;
        }
        public int Start { get; set; }
        public int End { get; set; }
        public int Length
        {
            get
            {
                return End - Start;
            }
        }
    }
}
