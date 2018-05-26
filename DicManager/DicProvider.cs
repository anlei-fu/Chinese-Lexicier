using Chinese._Scanner;
using ConsoleApp1.Chinese.WordInfo;
using Fal.DataStructure.Tree;
using Fal.Nlp;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test.Chinese.DicManager
{
    /// <summary>
    /// 字典管理与提供
    /// </summary>
    public   class DicPovider
    {
        public DicPovider(LexConfig config)
        {
            _config = config;
            initia();
        }
        /// <summary>
        /// 词典解析器
        /// </summary>
        private DicParser _parser;
        /// <summary>
        /// 词典路径配置
        /// </summary>
        private LexConfig _config;
        /// <summary>
        /// 新词词典
        /// </summary>
        public Search_Tree<_WordInnfo> NewWordDic { get; private set; } = new Search_Tree<_WordInnfo>();
        /// <summary>
        /// 单字词典
        /// </summary>
        public Dictionary<char, _WordInnfo> SingleDic { get; private set; } = new Dictionary<char, _WordInnfo>();
        /// <summary>
        /// 正向词典
        /// </summary>
        public Search_Tree<_WordInnfo> PositiveDic { get; private set; } = new Search_Tree<_WordInnfo>();
        /// <summary>
        /// 反向词典
        /// </summary>
        public Search_Tree<_WordInnfo> NegtiveDic { get; private set; } = new Search_Tree<_WordInnfo>();
        /// <summary>
        /// 更新字典
        /// </summary>
        public void UpdateDics()
        {
            var sb = new StringBuilder();
            var b = PositiveDic.ToList();
            b.Sort();
            foreach (var item in b)
                sb.Append(item.ToString() + "\r\n");
            File.WriteAllText(_config.DicPath, sb.ToString());
            sb.Clear();
            if (_config.IsDetectNewWord)
            {
                b = NewWordDic.ToList();
                b.Sort();
                foreach (var item in b)
                    sb.Append(item.ToString() + "\r\n");
                File.WriteAllText(_config.NewDicPath, sb.ToString());
            }

        }
        /// <summary>
        /// 加载字典数据
        /// </summary>
        private void initia()
        {
            _parser = new DicParser();
            /****************
             * 正向词典
             * **********************/
            var b = File.ReadAllText(_config.DicPath);
            _parser.Parse(b, PositiveDic);
            /****************
             * 反向词典
             * *************/
            _parser.Parse(b, NegtiveDic, true);
            /*************************************
             * 单字词典
             * *********************/
            foreach (var item in StringHelper.Splite(File.ReadAllText(_config.SingleDicDicPath), "\r\n"))
            {
                var w = _WordInnfo.Parse(item);
                if (w != null)
                    if (w.Name.Length != 0)
                        if (!SingleDic.ContainsKey(w.Name[0]))
                            SingleDic.Add(w.Name[0], w);
            }
            /****************
             * 新词词典
             * *****************/
            if (_config.IsDetectNewWord)
            {
                b = File.ReadAllText(_config.NewDicPath);
                _parser.Parse(b, NewWordDic);
            }

        }

        public _WordInnfo GetWordInfoFromSingleDic(char ch) => SingleDic.ContainsKey(ch) ? SingleDic[ch] : null;
       

        private void parseDic(string path, Search_Tree<_WordInnfo> dic)
        {

        }
    }
}
