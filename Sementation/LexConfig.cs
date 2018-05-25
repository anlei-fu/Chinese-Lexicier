using System;
using System.IO;

namespace Chinese._Scanner
{
    /// <summary>
    /// 分词配置类
    /// </summary>
    public  class LexConfig
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dicpath">词典路径</param>
        /// <param name="newdicpath">新词词典路径</param>
        /// <param name="isdetectnewword">是否识别新词</param>
        public LexConfig(string dicpath,string newdicpath,string singledicpath,bool isreflex,bool isconverttosimplify,bool isdetectnewword=false)
        {
            SingleDicDicPath = singledicpath;
            DicPath = dicpath;
            NewDicPath = newdicpath;
            IsDetectNewWord = isdetectnewword;
            IsReflex = isreflex;
            IsConvertToSimplify = isconverttosimplify;
            checkPath();
        }
        /// <summary>
        /// 是否进行反向分词
        /// </summary>
        public  bool IsReflex { get; private set; }
        /// <summary>
        /// 主词典路径
        /// </summary>
        public string DicPath { get; private set; }
        /// <summary>
        /// 新词词典路径
        /// </summary>
        public string NewDicPath { get; private set; }
        /// <summary>
        ///单子词词典
        /// </summary>
        public string SingleDicDicPath { get; private set; }
        /// <summary>
        /// 是否进行新词识别
        /// </summary>
        public bool IsDetectNewWord { get; private set; }
        /// <summary>
        /// 是否将繁体字转换为简体字
        /// </summary>
        public bool IsConvertToSimplify { get; private set; }
        /// <summary>
        /// 检查词典是否存在
        /// </summary>
        private void checkPath()
        {
            if (!File.Exists(DicPath))
                throw new Exception($"file not exist: {DicPath}");
            if (!File.Exists(SingleDicDicPath))
                throw new Exception($"file not exist: {DicPath}");
            if (IsDetectNewWord)
                if (!File.Exists(NewDicPath))
                    throw new Exception($"file not exist: {NewDicPath}");
        }
    }
}
