using ConsoleApp1.Chinese.WordInfo;
using Fal.Chinese.Helpers;
using Fal.DataStructure.List;
using System;
using System.Collections.Generic;
using Test.Chinese.DicManager;
using Test.Chinese.Helpers;

namespace Test.Chinese.Lexical._Scanner
{
    /// <summary>
    /// 此类完成对正反向分词结果的比较
    /// 采取：
    /// 总多字词个数最多、 
    /// 单字词个数最小、
    /// 特殊单字（在，不，和等）词个数最多、
    /// 单字构词规则“较为”正确的结果
    /// 的策略
    /// </summary>
    public class LexResultComparer
    {
        private DicPovider _provider;

        public LexResultComparer(DicPovider p)
        {
            _provider = p;
        }

        /// <summary>
        /// 反向分词函数，检查是否进行替换
        /// </summary>
        /// <param name="words">原始词链表</param>
        /// <param name="ls">反向分词得到的链表</param>
        /// <param name="s">有问题的词起始位置</param>
        /// <param name="e">有问题的词的结束位置</param>
        /// <returns>如果返回-1未进行替换，其他返回减小的词数</returns>
        public int Compare(List<_WordInnfo> words, List<_WordInnfo> ls, int s, int e)
        {
            var b = List_Helper.Select<_WordInnfo>(words, s, e - 1);
            if (compare(ls, b))
            {
                if (ls.Count == b.Count)
                    List_Helper.Replace<_WordInnfo>(words, s, e, ls, 0, ls.Count - 1);
                else
                    List_Helper.Replace<_WordInnfo>(words, s, e, ls, 0, ls.Count - 1);
                return (e - s) - ls.Count;
            }
            else
                return -1;
        }
        /// <summary>
        /// 比较选取那种单词序列
        /// </summary>
        /// <param name="l1">反向分词序列</param>
        /// <param name="l2">原始序列</param>
        /// <returns>返回值为真，采取新序列，否则使用原始序列</returns>
        private bool compare(List<_WordInnfo> l1, List<_WordInnfo> l2)
        {

            /****************
             *缩短了，直接返回true
             * ******************/
            if (l1.Count < l2.Count)
                return true;
            /***********************
             * 检查是否是相同序列
             * *************************/
            if (l1.Count == l2.Count)
                if (isTheSame(l1, l2))
                    return false;

            var a = count(l1);
            var s1 = a.Item3;
            var sr1 = a.Item1;
            var f1 = a.Item2;
            a = count(l2);
            var s2 = a.Item3;
            var sr2 = a.Item1;
            var f2 = a.Item2;

            /****************
             * 单字词个数
             * ****************************/
            if (s1 < s2)
                return false;
            /**********比较单字词比重***********************/
            else if (sr1 > sr2)
                return true;
            /*************比较单字结合比重*******************/
            else if (sr1 == sr2)
                if (f1 > f2)
                    return false;
            return true;
        }

        private bool isTheSame(List<_WordInnfo> l1, List<_WordInnfo> l2)
        {
            for (int i = 0; i < l1.Count; i++)
                if (l1[i].Name != l2[i].Name)
                    return false;
            return true;
        }

        private Tuple<int, int, int> count(List<_WordInnfo> l1)
        {
            /*******************
            *特殊单字词比重
            * 这 那 会 能 才
            * ****************/
            int sr = 0;

            /*************
             * 词性相似度
             * *****************/
            int f = 0;
            /**************
             * 单字词个数
             * *************************/
            int s = 0;

            foreach (var item in l1)
            {
                if (item.Name.Length == 1)
                {
                    s++;
                    if (CharHelper.IsFirstSingleWord(item.Name[0]))
                        sr += 3;
                    else if (CharHelper.IsSecondSingleWord(item.Name[0]))
                        sr += 2;
                    else if (CharHelper.IsThirdSingleWord(item.Name[0]))
                        sr++;

                }
                else
                {
                    if (item.Length == 2)
                    {
                        /********************************************
                         * 比较二字词构词规则可信度
                         * n+n 3
                         * v+v 3
                         * a+a 3
                         * a+n 2
                         * adv+v 2
                         * a+v 1
                         * ********************************/
                        if (_provider.SingleDic.ContainsKey(item.Name[0]) && _provider.SingleDic.ContainsKey(item.Name[1]))
                        {
                            var a = _provider.GetWordInfoFromSingleDic(item.Name[0]).MaxType;
                            var b = _provider.GetWordInfoFromSingleDic(item.Name[1]).MaxType;
                            if (a.GetBigType() == b.GetBigType())
                                f += 3;
                            else if (a.IsAdjective() && b.IsNoun())
                                f += 2;
                            else if (a.IsAdverb() && b.IsVerb())
                                f += 2;
                            else if (a.IsAdverb() && b.IsAdjective())
                                f += 1;
                            else if (a.IsAdjective() && b.IsVerb())
                                f += 1;
                        }
                    }
                }


            }
            return new Tuple<int, int, int>(sr, s, f);
        }
    }
}
