using Fal.Fal_Exception;
using Fal.Nlp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fal.DataStructure.Tree
{
    /***************************************************************
    * this is a  tree-like structure.
    * except first-layer-node use a hash-table,others all use linked-list.
    * it searchs from first letter to last letter.
    * such as "console" form 'c' to 'e',about seven steps.
    * if get the node return the node,or return null .
    * 
    * good :
    * 1.it searchs very fast.
    * 2. it can do some statistics
    * such as 
    * how many words begin with st(start,state.......)
    * if you get another  reversed tree 
    * you can finish: how many words begin with st and end with t(start)
    * 3.it uses less memery than get all in a hash table
    * 
    * bad:
    * it will generate many empty nodes ,will wast much memery.
    * 
    * copyright by fuanle,all rights reserved
    * telephone :18108342263
    * e-mail:18009049622@163.com
    ****************************************************************/
    public class SearchTree<T>  where T : IName
    {
        public SearchTree()
        {
        }
        public SearchTree(IEnumerable<T> Items)
        {

            foreach (var item in Items)
                AddNode(item);
        }
        public SearchTree(IEnumerable<string> Items)
        {
            foreach (var item in Items)
                AddNode(item);
        }
        /// <summary>
        /// 树名，几乎不用
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// 所有节点的个数
        /// 包含空节点
        /// </summary>
        public int Count { get => Root.AllChildCount; }
        /// <summary>
        /// 根节点
        /// </summary>
        public SearchTreeNode<T> Root { get; } = new SearchTreeNode<T>('R');
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SearchTreeNode<T> this[string name] => GetNode(name);
        /// <summary>
        /// 添加空节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public SearchTreeNode<T> AddNode(string str)
        {

            var b = getNodeFromFirstLayer(str[0]);
            if (b == null)
            {
                var node = new SearchTreeNode<T>(str[0]);
                Root.Add(node);
               _firstLayer.Add(str[0], node);
                b = node;
            }
            if (str.Length < 2)
                return b;
            for (int i = 1; i < str.Length; i++)
            {
                var a = b.GetChild(str[i]);
                if (a == null)
                {
                    var node = new SearchTreeNode<T>(str[i]);
                    node.Father = b;
                    b.Add(node);
                    b = node;
                }
                else
                    b = a;
            }
            return b;
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public SearchTreeNode<T> AddNode(T item)
        {
            var b = AddNode(item.Name);
            b.Content = item;
            b.IsEmpty = false;
            return b;
        }
        /// <summary>
        /// 是否包含节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Contain(string str)
        {
            var b = GetNode(str);
            if (b == null)
                return false;
            if (b.IsEmpty)
                return false;
            return true;
        }
        /// <summary>
        /// 清楚所有节点
        /// </summary>
        public void Clear()
        {
            _firstLayer.Clear();
            Root.Children.Clear();
        }
        /// <summary>
        /// 获取所有节点
        /// </summary>
        /// <returns></returns>
        public List<SearchTreeNode<T>> GetAllNodes()
        {
            var ls = new List<SearchTreeNode<T>>();
            foreach (var item in _firstLayer)
            {
                ls.Add(item.Value);
                foreach (var item1 in item.Value.GetAllChildren())
                    ls.Add(item1);
            }
            return ls;
        }
        /// <summary>
        /// 获取节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public SearchTreeNode<T> GetNode(string str)
        {
            var b = getNodeFromFirstLayer(str[0]);
            if (b == null)
                return b;
            if (str.Length < 2)
                return b;
            for (int i = 1; i < str.Length; i++)
            {
                b = b.GetChild(str[i]);
                if (b == null)
                    return null;
            }
            return b;
        }
        /// <summary>
        /// 深度优先遍历获取所有节点
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            var ls = new List<T>();
            foreach (var item in GetAllNodes())
                if (!item.IsEmpty)
                    ls.Add(item.Content);
            return ls;
        }
        /// <summary>
        /// 移除节点
        /// </summary>
        /// <param name="str"></param>
        public void RemoveNode(string str)
        {
            var b = GetNode(str);
            b.Father.Remove(b);

            if (str.Length == 1)
                if (_firstLayer.ContainsKey(str[0]))
                    _firstLayer.Remove(str[0]);

        }
      
        /// <summary>
        /// 从字典中获取节点
        /// 第一层字符
        /// </summary>
        /// <param name="_char"></param>
        /// <returns></returns>
        private SearchTreeNode<T> getNodeFromFirstLayer(char _char) => _firstLayer.ContainsKey(_char) ? _firstLayer[_char] : null;
        /// <summary>
        /// 第一层节点的管理的字典
        /// </summary>
        private Dictionary<char, SearchTreeNode<T>> _firstLayer = new Dictionary<char, SearchTreeNode<T>>();
    }
}
