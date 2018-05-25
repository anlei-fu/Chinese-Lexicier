using ConsoleApp1.Chinese._Paragraph;
using Fal.Chinese.InterFace;
using Fal.Chinese.Structure._Passage;
using System;

namespace ConsoleApp1.Chinese._Passage
{
    public   class Passage:BasicProperty<Paragraph>
    {
        /// <summary>
        /// 来源
        /// </summary>
        public string SourceFrom { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Tiltle { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public PassageType Type { get; set; }
    }
}
