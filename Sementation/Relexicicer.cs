using Chinese._Scanner;
using ConsoleApp1.Chinese.WordInfo;
using Fal.DataStructure.Tree;
using Fal.Nlp;
using Fal.Nlp.Chinese;
using System.Collections.Generic;
using Test.Chinese.DicManager;

namespace Test.Chinese.Lexical._Scanner
{
    /// <summary>
    /// 反向分词类
    /// 基于字符串扫描的分词方式
    /// </summary>
    public class Relexicier
    {

        public Relexicier(DicPovider p)
        {
            _provider = p;
        }
        /// <summary>
        /// 词典
        /// </summary>
        private DicPovider _provider;
        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public List<_WordInnfo> Reflex(string temp)
        {
            var ls = new List<_WordInnfo>();

            /*******************
             * 获取有问题的字符串
             * **************/
            Search_Tree_Node<_WordInnfo> current_node = null;
            Search_Tree_Node<_WordInnfo> max_node = null;
            int searchTime = 0;
            int max_time = 0;
            bool isSearchFromTheTree = true;

            for (int i = 0; i < temp.Length; i++)
            {

                /****************************
                 * 处理数字、字母、未知字符
                 * ****************************/
                if (searchTime == 0)
                {

                    /********************字母、数字*************************/
                    if (Regex_Helper.Is_Math_Expression(temp[i].ToString()))
                    {
                        reflexNumberAlpha(ls, ref temp, ref i);
                        continue;
                    }
                    /***********************未知字符********************************/
                    if (!Regex_Helper.Is_ACN(temp[i].ToString()) && !Regex_Helper.Is_Mark(temp[i].ToString()))
                    {
                        reflexUnknowChars(ls, ref temp, ref i);
                        continue;
                    }
                }

                /******************
                 * 增加搜索次数
                 * *********************/
                searchTime++;
                if (isSearchFromTheTree)
                {
                    current_node = _provider.NegtiveDic.Get_Node(temp[i].ToString());

                    isSearchFromTheTree = false;
                    /***************
                     * 是否结束分词
                     * ********************/
                    if (current_node == null)
                        endReflex(ref temp, ls, ref i, ref searchTime, ref max_time, ref isSearchFromTheTree, current_node, ref max_node);
                    else
                        /*************
                         * 是否更新maxnode
                         * ********************/
                        if (!current_node.Is_Empty)
                    {
                        max_node = current_node;
                        max_time = searchTime;
                    }




                }
                else
                {
                    current_node = current_node.Get_Child(temp[i]);
                    /***************
                     * 是否结束分词
                     * ********************/
                    if (current_node == null)
                        endReflex(ref temp, ls, ref i, ref searchTime, ref max_time, ref isSearchFromTheTree, current_node, ref max_node);

                    else
                        /*************
                         * 是否更新maxnode
                         * ********************/
                        if (!current_node.Is_Empty)
                    {
                        max_node = current_node;
                        max_time = searchTime - 1;
                    }

                }

            }

            /******************
             * 扫描结束处理
             * **********************/

            afterReflex(ls, current_node, max_node, temp);

            /****************反转链表******************/
            reverseList(ls);
            return ls;

        }

     
     
        /// <summary>
        /// 反向分词函数，读取字母，数字序列
        /// </summary>
        /// <param name="ls">反向分词结果的词链表</param>
        /// <param name="temp">要进行反向分词的字符串序列</param>
        /// <param name="i">当前扫描位置</param>
        private void reflexNumberAlpha(List<_WordInnfo> ls, ref string temp, ref int i)
        {
            var temps = temp[i].ToString();
            var w = new _WordInnfo();
            for (int j = i + 1; j < temp.Length; j++, i++)
            {
                if (Regex_Helper.Is_Number(temp[j].ToString())|| Regex_Helper.Is_Alpha(temp[j].ToString()))
                    temps += temp[j];
                else
                {
                    i++;
                    break;
                }
            }
            w.Name = temps;
            Lexicer.SetAlphaNumberType(w);
            ls.Add(w);
            if (i != temp.Length - 1)
                i--;
        }

        /// <summary>
        /// 反向分词函数，读取未知字符序列
        /// </summary>
        /// <param name="ls">反向分词结果的词链表</param>
        /// <param name="temp">要进行反向分词的字符串序列</param>
        /// <param name="i">当前扫描位置</param>
        private void reflexUnknowChars(List<_WordInnfo> ls, ref string temp, ref int i)
        {
            var temps = temp[i].ToString();
            var _w = new _WordInnfo();
            for (int j = i + 1; j < temp.Length; j++, i++)
            {

                if (!Regex_Helper.Is_ACN(temp[j].ToString()) && !Regex_Helper.Is_Mark(temp[j].ToString()))
                    temps += temp[j];
                else
                {
                    i++;
                    break;
                }
            }
            _w.Name = temps;
            _w.MaxType = WordType.Noun;
            ls.Add(_w);
            if (i != temp.Length - 1)
                i--;
        }

        /// <summary>
        /// 反向分词函数，获得词，并且重置参数
        /// </summary>
        /// <param name="temp">要进行反向分词的字符串序列</param>
        /// <param name="ls">反向分词结果的词链表</param>
        /// <param name="i">当前扫描位置</param>
        /// <param name="searchTime">搜索次数</param>
        /// <param name="max_time">最大节点的次数</param>
        /// <param name="isSearchFromTheTree">是否从根节点开始扫描</param>
        /// <param name="current_node">当前节点</param>
        /// <param name="max_node">最大节点</param>
        private void endReflex(ref string temp, List<_WordInnfo> ls, ref int i, ref int searchTime, ref int max_time, ref bool isSearchFromTheTree, Search_Tree_Node<_WordInnfo> current_node, ref Search_Tree_Node<_WordInnfo> max_node)
        {
            if (max_node != null)
                ls.Add(max_node.Content.Copy());
            else
            {
                if (_provider.SingleDic.ContainsKey(temp[i - (searchTime - max_time - 1)]))
                    ls.Add(_provider.GetWordInfoFromSingleDic(temp[i - (searchTime - max_time - 1)]).Copy());
                else
                    ls.Add(new _WordInnfo() { Name = temp[i - (searchTime - max_time - 1)].ToString(), TypeInfo = new Dictionary<WordType, int> { { WordType.Noun, 1 } }, MaxType = WordType.Unknow });
            }

            i = i - (searchTime - max_time) + 1;
            isSearchFromTheTree = true;
            current_node = null;
            max_node = null;
            searchTime = max_time = 0;
            isSearchFromTheTree = true;
        }

        /// <summary>
        /// 反向分词函数，扫描结束后的处理
        /// </summary>
        /// <param name="ls">反向分词结果的词链表</param>
        /// <param name="current_node">当前节点</param>
        /// <param name="max_node">最大节点</param>
        private void afterReflex(List<_WordInnfo> ls, Search_Tree_Node<_WordInnfo> current_node, Search_Tree_Node<_WordInnfo> max_node, string temp)
        {
            if (current_node != null)
            {
                /************************
                 * current is not empty
                 * *****************************/
                if (!current_node.Is_Empty)
                    max_node = current_node;

                if (max_node != null)
                {
                    ls.Add(max_node.Content.Copy());

                    if (max_node.Content.Name.Length < current_node.Full_Name.Length)
                    {
                        var b = current_node.Full_Name.Replace(max_node.Content.Name, "");

                        foreach (var item in b)
                        {
                            if (_provider.SingleDic.ContainsKey(item))
                                ls.Add(_provider.SingleDic[item].Copy());
                            else
                                ls.Add(new _WordInnfo(current_node.Full_Name.Replace(item.ToString(), "")) { MaxType = WordType.Unknow });
                        }

                    }
                }
                else
                {
                    foreach (var item in current_node.Full_Name)
                    {
                        if (_provider.SingleDic.ContainsKey(item))
                            ls.Add(_provider.SingleDic[item].Copy());
                        else
                            ls.Add(new _WordInnfo(item.ToString()) { MaxType = WordType.Unknow });
                    }


                }
            }
            else
            {
                if(temp.Length>0)
                if (_provider.SingleDic.ContainsKey(temp[temp.Length - 1]))
                    ls.Add(_provider.SingleDic[temp[temp.Length - 1]].Copy());
                else
                    ls.Add(new _WordInnfo(temp[temp.Length - 1].ToString()) { MaxType = WordType.Unknow });
            }
        }

      /// <summary>
      /// 反转链表
      /// </summary>
      /// <param name="input"></param>
        private void reverseList(List<_WordInnfo> input)
        {
            input.Reverse();
            foreach (var item in input)
                item.Name = StringHelper.Reverse(item.Name);
        }

       
   
    }

}
