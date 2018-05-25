using ConsoleApp1.Chinese.WordInfo;
using Fal.Chinese.Helpers;
using Fal.Nlp;
using System.Collections.Generic;
using Test.Chinese.DicManager;

namespace Test.Chinese.Lexical._Scanner
{
    /// <summary>
    /// 此类完成对正向分词结果的检测
    /// 如果检测到可能有问题的序列 进行反向分词
    /// 再由 compare 对正反向分词结果进行比较
    /// 选取 “较为合适”的序列作为最终结果
    /// </summary>
    public class LexChecker
    {
        public LexChecker(DicPovider p)
        {
            _relexWorker = new Relexicier(p);
            _comparer = new LexResultComparer(p);
        }
        /// <summary>
        /// 要检测的单词序列
        /// </summary>
        private List<_WordInnfo> _ls;
        /// <summary>
        /// 反向分词器
        /// </summary>
        private Relexicier _relexWorker;
        /// <summary>
        /// 分词结果比较器
        /// </summary>
        private LexResultComparer _comparer;
        /// <summary>
        /// 检测
        /// 出现单字进行检测
        /// 一些特殊的单字则跳过
        /// </summary>
        /// <param name="ls"></param>
        public void Check(List<_WordInnfo> ls)
        {
            _ls = ls;
            var start = -1;//用于记录有问题词的起始位置
            var end = -1;///用于记录有问题词的结束位置
            for (int i = 0; i < _ls.Count; i++)
            {
                var temp = _ls[i];
                if (temp.Name.Length == 1)
                {
                    if (start == -1)
                    {
                        /********************
                         * 跳过部分单字词
                         * 如 ：不 很 能 在
                         * ***************************/
                        if (CharHelper.IsStopWord(temp.Name[0]))
                            continue;
                        if (i != 0)
                            start = i - 1;
                        else
                            start = i;
                    }
                    /**********************stopword****************************/
                    else
                    {
                        /****************************
                         * 遇到结束的单字词
                         * **********************/
                        if (CharHelper.IsStopWord(temp.Name[0]))
                        {
                            end = i;
                            /***************************************/
                            if (end - start == 1)
                            {
                                start = -1;
                                continue;
                            }
                            /*****************
                             * 执行反向分词
                             * ************************************/
                            var g = _comparer.Compare(_ls, _relexWorker.Reflex(getProblemString(_ls, start, end)), start, end);

                            start = -1;
                            /*******************
                             * 没有进行缩短
                             * ************************************/
                            if (g == -1)
                                continue;
                            i -= g;

                        }
                    }
                }
                else
                {
                    if (start == -1)
                        continue;
                    else
                    {
                        end = i;
                        var g = _comparer.Compare(_ls, _relexWorker.Reflex(getProblemString(_ls, start, end)), start, end);
                        start = -1;
                        if (g == -1)
                            continue;
                        i -= g;

                    }
                }
            }
            /****************
             * 句子最尾部的情况
             * *******************************/
            if (start != -1)
                if (checkIsReflex(_ls, start, _ls.Count))
                    _comparer.Compare(_ls, _relexWorker.Reflex(getProblemString(_ls, start, end)), start, end);

        }


        /// <summary>
        /// 检查是否进行反向分词
        /// </summary>
        /// <param name="ls">原始词链表</param>
        /// <param name="start">有问题的词的起始位置</param>
        /// <param name="end">有问题的词的结束位置</param>
        /// <returns></returns>
        private bool checkIsReflex(List<_WordInnfo> ls, int start, int end)
        {
            for (int i = start; i < end; i++)
                if (ls[i].Name.Length == 1)
                    if (!CharHelper.IsSingleWord(ls[i].Name[0]))
                        return true;
            return false;
        }

        /// <summary>
        ///从 list 获取字符串
        /// </summary>
        /// <param name="words">词序列</param>
        /// <param name="s">词的起始位置</param>
        /// <param name="e">词的结束位置</param>
        /// <returns></returns>
        private string getProblemString(List<_WordInnfo> words, int s, int e)
        {
            var temp = "";
            for (int i = s; i < e; i++)
                temp += words[i].Name;

            return StringHelper.Reverse(temp);
        }
    }
}
