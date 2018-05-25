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
    public class Search_Tree<T> : IFrom_String where T : IName
    {
        public Search_Tree()
        {
        }
        public Search_Tree(IEnumerable<T> Items)
        {
            Exception_Thrower.Check_argNull(Items);
            foreach (var item in Items) Add_Node(item);
        }
        public Search_Tree(IEnumerable<string> Items)
        {
            Exception_Thrower.Check_argNull(Items);
            foreach (var item in Items) Add_Node(item);
        }
        public string Name { get; set; } = "";
        public int Count { get => Root.All_Child_Count; }
        public Search_Tree_Node<T> Root { get; } = new Search_Tree_Node<T>('R');
        public Search_Tree_Node<T> this[string name] { get => Get_Node(name); }
        public Search_Tree_Node<T> Add_Node(string str)
        {
            Exception_Thrower.Check_argNull(str);
            if (String.IsNullOrEmpty(str)) return Root;
            var b = get_Node_From_First_Layer(str[0]);
            if (b == null)
            {
                var node = new Search_Tree_Node<T>(str[0]);
                Root.Add(node);
                First_Layer.Add(str[0], node);
                b = node;
            }
            if (str.Length < 2) return b;
            for (int i = 1; i < str.Length; i++)
            {
                var a = b.Get_Child(str[i]);
                if (a == null)
                {
                    var node = new Search_Tree_Node<T>(str[i]);
                    node.Father = b;
                    b.Add(node);
                    b = node;
                }
                else b = a;
            }
            b.Is_Empty = false;
            return b;
        }
        public Search_Tree_Node<T> Add_Node(T item)
        {
            var b = Add_Node(item.Name);
                        b.Content=item;
            return b;
        }
        public bool Contain(string str)
        {
            var b = Get_Node(str);
            if (b == null)
                return false;
            if (b.Is_Empty)
                return false;
            return true;
        }
        public void From_String(string str)
        {
            Exception_Thrower.Check_argNull(str);
            foreach (var item in StringHelper.Splite(str, "_nd_")) Add_Node(item.Substring(0, item.Length - 4));
        }
        public void Clear() => First_Layer.Clear();
        public List<Search_Tree_Node<T>> Get_All_Nodes()
        {
            var ls = new List<Search_Tree_Node<T>>();
            foreach (var item in First_Layer)
            {
                ls.Add(item.Value);
                foreach (var item1 in item.Value.Get_All_Children()) ls.Add(item1);
            }
            return ls;
        }
        public Search_Tree_Node<T> Get_Node(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            var b = get_Node_From_First_Layer(str[0]);
            if (b == null)
                return null;
            if (str.Length < 2)
                return b;
            for (int i = 1; i < str.Length; i++)
            {
                b = b.Get_Child(str[i]);
                if (b == null)
                    return null;
            }
            return b;
        }
        public List<T> ToList()
        {
            var ls = new List<T>();
            foreach (var item in Get_All_Nodes())
                if(!item.Is_Empty)
                ls.Add(item.Content);
            return ls;
        }
        public void Remove_Node(string str)
        {
            var b = Get_Node(str);
            if (b.Children.Count != 0)
                b.Is_Empty = true;
            else
            {
                while (b.Father != null)
                {
                    var c = b.Father;
                    b.Father.Remove(b);
                    b.Father = null;
                    if (c.Is_Empty)
                        b = c;

                }
            }

        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in Get_All_Nodes()) sb.Append(item.ToString());
            return sb.ToString();
        }
        private Search_Tree_Node<T> get_Node_From_First_Layer(char _char) => First_Layer.ContainsKey(_char) ? First_Layer[_char] : null;
        private Dictionary<char, Search_Tree_Node<T>> First_Layer = new Dictionary<char, Search_Tree_Node<T>>();
    }
}
