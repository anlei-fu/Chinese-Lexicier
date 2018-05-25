using ConsoleApp1.Chinese._Paragraph;
using ConsoleApp1.Chinese._Passage;
using ConsoleApp1.Chinese._Sentence;
using ConsoleApp1.Chinese.WordInfo;
using Fal.Chinese.Helpers;
using Fal.DataStructure.Tree;
using Fal.Nlp;
using Fal.Nlp.Chinese;
using System.Diagnostics;
using Test.Chinese.Counters;
using Test.Chinese.DicManager;
using Test.Chinese.Lexical._Scanner;
using Test.Chinese.Structure;

namespace Chinese._Scanner
{

    public delegate void LexEvent(Paragraph p);
    /// <summary>
    /// 中文分词类
    /// 基于正反向扫描字符串
    /// </summary>
    public class Lexicer
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lex">分词配置</param>
        public Lexicer(LexConfig lex)
        {
            _config = lex;
            if (_config.IsConvertToSimplify)
                _schelper = new Simplify_And_Traditional_Chinese_Helper();
            this.DicProvider = new DicPovider(lex);
            _checker = new LexChecker(DicProvider);
            _watch = new Stopwatch();
        }
        /// <summary>
        /// 统计器
        /// </summary>
        public Counter Counter { get; private set; } = new Counter();

        /// <summary>
        /// 分词函数
        /// </summary>
        /// <param name="str">需要分词的字符串</param>
        /// <returns></returns>
        public Passage Work(string str)
        {
            _watch.Start();
            preWork(str);
            work();

            _watch.Stop();
            Speed = $"{(float)_context.Length / (float)_watch.ElapsedMilliseconds * 1000}字/秒";
            return _passage;
        }

        /**********************
         * 为多线程设计考虑，
         * ***********************/
        /// <summary>
        /// 解析完成一个子句触发
        /// </summary>
        public event LexEvent SubSenceFinish;
        /// <summary>
        /// 解析完成一个句子触发
        /// </summary>
        public event LexEvent SentenceFinish;
        /// <summary>
        /// 解析完成一个段落出发
        /// </summary>
        public event LexEvent ParagraphFinish;
        /// <summary>
        /// 
        /// </summary>

        internal Search_Tree<WordsVertex> VertexDic = new Search_Tree<WordsVertex>();
        /// <summary>
        /// 词典路径配置
        /// </summary>
        public LexConfig _config;
        /// <summary>
        /// 字典管理
        /// </summary>
        public DicPovider DicProvider { get; internal set; }
        /// <summary>
        /// 分词速度
        /// </summary>
        public string Speed { get; private set; }
        /// <summary>
        /// 用于计算分词速度
        /// </summary>
        private Stopwatch _watch;
        /// <summary>
        /// 临时文章
        /// </summary>
        private Passage _passage;
        /// <summary>
        /// 临时句子
        /// </summary>
        private Sentence _sentence = new Sentence();
        /// <summary>
        /// 是否从根节点开始搜索
        /// </summary>
        private bool _isSearchFromTree = true;
        /// <summary>
        /// 临时子句
        /// </summary>
        private SimpleSentence _susentence = new SimpleSentence();
        /// <summary>
        /// 确定句子是否开始
        /// </summary>
        private bool _isSentenceStarted;
        /// <summary>
        /// 确定子句是否开始
        /// </summary>
        private bool _isSubsentenceStarted;
        /// <summary>
        /// 段落是否开始
        /// </summary>
        private bool _isParagraphStarted;
        /// <summary>
        /// 临时字符
        /// </summary>
        private char _token;
        /// <summary>
        /// 临时节点
        /// </summary>
        private Search_Tree_Node<_WordInnfo> _current_node;
        /// <summary>
        /// 最大节点
        /// </summary>
        private Search_Tree_Node<_WordInnfo> _max_node;
        /// <summary>
        /// 临时段落
        /// </summary>
        private Paragraph _paragraph = new Paragraph();
        /// <summary>
        /// 搜索次数
        /// </summary>
        private int _serachTime;
        /// <summary>
        /// 最大次数
        /// </summary>
        private int _maxTime;
        /// <summary>
        /// 分词结束后的检查器
        /// </summary>
        private LexChecker _checker;
        /// <summary>
        /// 简繁转换器
        /// </summary>
        private Simplify_And_Traditional_Chinese_Helper _schelper;
        /// <summary>
        /// 记录当前字符位置
        /// </summary>
        private int _currentPos { get; set; } = -1;
        /// <summary>
        /// 记录输入的字符串
        /// </summary>
        private string _context { get; set; }
        /// <summary>
        /// 是否有下一个字符
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private bool hasNext => _currentPos + 1 < _context.Length;
        /// <summary>
        /// 是否有上一个字符
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private bool hasPrevious => _currentPos - 1 > 0;
        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private char previous(int len = 1)
        {
            _currentPos -= len;
            if (_currentPos < 0)
                return '\0';
            return _context[_currentPos];
        }
        /// <summary>
        /// 前进
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private char next(int len = 1)
        {
            _currentPos += len;
            if (_currentPos > _context.Length - 1)
                return '\0';
            return _context[_currentPos];
        }
        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="str"></param>
        private void preWork(string str)
        {
            _currentPos = -1;
            Counter.Reset();
            _passage = new Passage();
            _context = str.Trim();
            if (_config.IsConvertToSimplify)
                _context = _schelper.Covert_Traditional_Chinese_To_Simplify(_context);
        }

        /// <summary>
        /// 主分词函数
        /// 从头到尾扫描字符串一遍，
        /// 并进行相应的处理
        /// </summary>
        /// 
        private void work()
        {
            while (true)
            {
                if (_currentPos < _context.Length - 1)
                    _token = next();
                else
                {
                    if (_serachTime == 0)
                        break;
                    else
                    {

                        endFlex();
                        continue;
                    }
                }
                if (_isParagraphStarted)
                {
                    if (isParagraphEnd())
                        continue;

                    if (_isSentenceStarted)
                    {
                        if (_isSubsentenceStarted)
                        {

                            /****************************
                             * 无效字符 \r\n \b \f
                             * **********************/
                            if (MarkHelper.IsInvalidChar(_token))
                                continue;
                            /***********************
                             * 子句结束符 ,
                             * ************************/
                            if (isSubsentenceEnd())
                                continue;
                            /***************************
                             * 句子结束符 。 ； …… ！？
                             * ************************/
                            if (isSentenceEnd())
                                continue;
                            /************************
                           * 分割特殊字符
                           * **********************************/
                            if (_serachTime == 0)
                                if (workSpecialChars())
                                    continue;
                            searchInTheTree();
                        }
                        else

                            subSentenceStart();
                    }
                    else
                        sentenceStart();
                }
                else
                {
                    if (CharHelper.IsBlank(_token))
                        continue;
                    paragraphStart();
                }

            }

        }


        /// <summary>
        /// 切分一些特殊字符
        /// </summary>
        /// <returns></returns>
        private bool workSpecialChars()
        {
            /****************************************************
             * 处理以字母（包括希腊字母）数字英文标点开始的字符片段
             * e-mail,
             * addreess
             * mathexpression
             *  and so on
             * *******************************************************/
            if (Regex_Helper.Is_AN(_token.ToString()) || Regex_Helper.Is_Concrete_Number(_token.ToString()) || Regex_Helper.Is_English_Mark(_token.ToString()))
            {
                flexNumberAlpha(_token);
                return true;
            }
            /*********************************
             * 处理未知字符开始的字符片段
             * 其他语言的文字 （日文，韩文等）
             * *******************************/
            if (!Regex_Helper.Is_ACN(_token.ToString()) && !Regex_Helper.Is_Mark(_token.ToString()))
            {
                flexUnknowChar(_token);
                return true;
            }
            return false;
        }

        private bool isParagraphEnd()
        {

            /***********************************
             * \t 认为是段落的结束符
             * ************************************/
            if (_token == '\t')
            {
                if (_serachTime != 0)
                    return false;
                else
                {
                    paragraphEnd('\t');
                    return true;
                }
            }
            /******************
             * 空格认为是句子的结束符
             * 但是 英语中只是词的分隔符
             * ****************************/
            if (_token == ' ')
            {
                if (_serachTime != 0)
                    return false;
                else
                {
                    if (hasNext)
                        if (next() == ' ')
                            paragraphEnd(' ');
                        else
                        {
                            previous();
                            sentenceEnd(' ');
                        }
                    return true;
                }

            }
            return false;
        }

        private void searchInTheTree()
        {
            _serachTime++;
            /*************************
             * 是否从根节点开始搜索
             * *******************/
            if (_isSearchFromTree)
                _current_node = DicProvider.PositiveDic.Get_Node(_token.ToString());
            else
                _current_node = _current_node.Get_Child(_token);


            /*********************
             * 记录找到的最长词
             * ********************************/
            if (_current_node != null)
                if (!_current_node.Is_Empty)
                {
                    _max_node = _current_node;
                    _maxTime = _serachTime;
                }
            /*****************************
             * 当前搜索节点不是从根节点
             * **************************/
            _isSearchFromTree = false;

            /**************************
             * 检查是否结束向下搜索
             * ***********************/
            if (_current_node == null)
                endFlex();

        }
        private bool isSubsentenceEnd()
        {
            if (!MarkHelper.IsSubSentenceEndMark(_token))
                return false;
            else
            {
                /***************
                 * 不等于0
                 * 说明此时工作在searchtree
                 * 不进行结束子句的操作
                 * *************************/
                if (_serachTime == 0)
                {
                    subSentenceEnd(_token);
                    return true;
                }
                else
                    return false;
            }

        }
        /// <summary>
        /// 检查是否是句子结束
        /// 如果是，结束句子
        /// </summary>
        /// <returns></returns>
        private bool isSentenceEnd()
        {
            if (!MarkHelper.IsSentenceEndMark(_token))
                return false;
            else
            {
                /***************
                 * 不等于0
                 * 说明此时工作在searchtree
                 * 不进行结束句子的操作
                 * *************************/
                if (_serachTime != 0)
                    return false;
                else
                {
                    sentenceEnd(_token);
                    return true;
                }
            }

        }


        /// <summary>
        /// 切割字母数字
        /// </summary>
        /// <param name="ch"></param>
        private void flexNumberAlpha(char ch)
        {

            var name = ch.ToString();

            /***************************
             * 用于确定是否回跳
             * 如果执行了 while 下面的语句
             * 需要回跳一个字符
             * *************************/
            bool flag = false;
            while (_currentPos < _context.Length - 1)
            {

                flag = true;
                var b = next();
                if (Regex_Helper.Is_AN(b.ToString()))
                    name += b;
                /********************************
                 * website address, math expression
                 * *************************************/
                else if (Regex_Helper.Is_Mark(b.ToString()))
                {
                    /**********************
                     *if chinese mark ens prosses
                     * *************************/
                    if (Regex_Helper.Is_Chinese_Mark(b.ToString()))
                        break;
                    name += b;
                }
                else
                    break;

            }

            var w = new _WordInnfo() { Name = name, };
            /**********************
             * 设置获得片段的词性
             * 可能是数词，也可能是其他（数学表达式，网址等）
             * ************************/
            SetAlphaNumberType(w);


            if (flag)
                previous();

            w.Name = name;
            _susentence.Words.Add(w);
        }
        /// <summary>
        /// 判断类型
        /// reflexier也会使用 ，所以改成公开静态函数
        /// </summary>
        /// <param name="w"></param>
        public static void SetAlphaNumberType(_WordInnfo w)
        {
            var t = StringHelper.Count(w.Name, (x) => Regex_Helper.Is_Concrete_Number(x.ToString()));
            if (t == w.Name.Length)
                w.MaxType = WordType.NumberConcrete;
            else if (t == w.Name.Length - 1)
            {
                if (w.Name.Contains('.'.ToString()))
                    w.MaxType = WordType.NumberConcrete;
                else
                    w.MaxType = WordType.NounAlphaNumberMark;
            }
            else
                w.MaxType = WordType.NounAlphaNumberMark;
        }

        /// <summary>
        /// 切割未知字符
        /// 如 japannese alpha 
        /// arabic kraon
        /// </summary>
        /// <param name="ch"></param>
        private void flexUnknowChar(char ch)
        {
            var w = new _WordInnfo();

            var name = ch.ToString();
            bool flag = false;
            while (hasNext)
            {
                var b = next();
                flag = true;
                if (!Regex_Helper.Is_ACN(b.ToString()) && !Regex_Helper.Is_Mark(b.ToString()))
                    name += b;
                else
                    break;
            }
            if (flag)
                previous();
            w.Name = name;
            w.MaxType = WordType.Noun;
            _susentence.Words.Add(w);
        }
        /// <summary>
        /// 结束分词，添加最大词进入句子的单词序列
        /// </summary>
        private void endFlex()
        {
            /***********************
             * 识别出单词
             * ***********************/
            if (_max_node != null)
                _susentence.Words.Add(_max_node.Content.Copy());
            /**************************
             * 未识别出单词
             * ********************************/
            else
            {
                /*********************************
                 * 单字词词典包含信息
                 * *********************************************/
                if (DicProvider.SingleDic.ContainsKey(_context[_currentPos - _serachTime + 1]))
                    _susentence.Words.Add(DicProvider.GetWordInfoFromSingleDic(_context[_currentPos - _serachTime + 1]).Copy());
                /***************************
                 * 单字词词典未包含信息
                 * ****************************/
                else
                    _susentence.Words.Add(new _WordInnfo(_context[_currentPos - _serachTime + 1].ToString(), WordType.Unknow));
            }
            /********************
             * 返回位置
             * **********************************/
            if (_maxTime == 0)
                previous(_serachTime - 1);
            else
                previous(_serachTime - _maxTime);

            /********************
             * 重置参数
             * ******************/
            _maxTime = _serachTime = 0;
            _max_node = null;
            _isSearchFromTree = true;
        }
        /// <summary>
        /// 段落开始处理函数
        /// </summary>
        private void paragraphStart()
        {
            _isParagraphStarted = true;
            var b = _paragraph;
            _paragraph = new Paragraph();
            _paragraph.SetPrevious(b);
            _passage.Items.Add(_paragraph);
            _paragraph.Position.Start = _currentPos;
            sentenceStart();


        }
        /// <summary>
        /// 段落结束处理函数
        /// </summary>
        private void paragraphEnd(char ch)
        {
            _isParagraphStarted = false;
            sentenceEnd(ch);
            _paragraph.Position.End = _currentPos;
            if (ParagraphFinish != null)
                ParagraphFinish(_paragraph);
        }
        /// <summary>
        /// 句子开始处理函数
        /// </summary>
        private void sentenceStart()
        {
            _isSentenceStarted = true;
            var b = _sentence;
            _sentence = new Sentence();
            _sentence.SetPrevious(b);
            _paragraph.Items.Add(_sentence);
            _sentence.Position.Start = _currentPos;
            subSentenceStart();

        }
        /// <summary>
        /// 句子结束处理函数
        /// </summary>
        private void sentenceEnd(char ch)
        {

            subSentenceEnd(ch);
            _sentence.Position.End = _currentPos;
            /***************
             * 发布句子结束事件
             * *************/
            if (SentenceFinish != null)
                SentenceFinish(_paragraph);
        }
        /// <summary>
        /// 子句开始处理函数
        /// </summary>
        private void subSentenceStart()
        {
            _isSubsentenceStarted = true;

            var b = _susentence;
            _susentence = new SimpleSentence();
            _susentence.SetPrevious(b);

            _susentence.Position.Start = _currentPos;
            _sentence.Items.Add(_susentence);
            /***********************************************
             * 回跳一次
             * 因为在主函数向前移动了一个字符，而且没有对这个字符进行处理
             * *********************************************/
            previous();

        }
        /// <summary>
        /// 子句结束处理函数
        /// </summary>
        private void subSentenceEnd(char ch)
        {
            /****************
             * 确定是否为子句添加一个标点
             * 如果子句以空格结束
             * ************************/
            var w = new _WordInnfo();
            if (MarkHelper.IsSubSentenceEndMark(ch))
                w.Name = ch.ToString();
            else if (MarkHelper.IsSentenceEndMark(ch))
                w.Name = ch.ToString();
            else
                w.Name = '。'.ToString();
            w.MaxType = WordType.Mark;
            _susentence.Words.Add(w);

            _susentence.Position.End = _currentPos;
            _isSubsentenceStarted = false;

            /******************
             * 是否执行分次结果检测
             * ****************/
            if (_config.IsReflex)
                _checker.Check(_susentence.Words);
            /*************************
             * 发布子句解析完成事件
             * ********************/
            if (SubSenceFinish != null)
                SubSenceFinish(_paragraph);
        }
    }
}

