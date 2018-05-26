using System.Collections.Generic;
namespace Fal.DataStructure.Tree
{
    /*****************************************************
     * this is  s-tree-node.
     * include
     * [ (char)name,(linkedlist)children,(this)father,
     * (linkedlist)content,(bool)Is_empty]
     * five members.
     * and some basic methods.
     *****************************************************/
    public class SearchTreeNode<T>
        
    { 
        public SearchTreeNode()
        { }
        public SearchTreeNode(char _char)
        {
            this.name = _char;
        }
        /// <summary>
        /// 所有子节点个数
        /// </summary>
        public int AllChildCount  => getAllChildrenCount(); 
        /// <summary>
        /// 子节点
        /// </summary>
        public LinkedList<SearchTreeNode<T>> Children { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public T Content { get; set; } 
        /// <summary>
        /// 自己点个数
        /// </summary>
        public int Count  => Children == null ? 0 : Children.Count; 
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SearchTreeNode<T> this[char name] => GetChild(name);
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SearchTreeNode<T> this[string name]   => GetChild(name); 
        /// <summary>
        /// 父节点
        /// </summary>
        public SearchTreeNode<T> Father { get; set; }
        /// <summary>
        /// 全名
        /// </summary>
        public string FullName  => _getFullName(); 
        /// <summary>
        /// 是否是空节点
        /// </summary>
        public bool IsEmpty { get;  set; } = true;
        /// <summary>
        /// 通过全名获取子节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public SearchTreeNode<T> GetChild(string str)
        {
            if (Children != null)
                foreach (var item in Children)
                    if (item.FullName == str)
                        return item;
            return null;
        }
        /// <summary>
        /// 通过名称获取子节点
        /// </summary>
        /// <param name="_char"></param>
        /// <returns></returns>
        public SearchTreeNode<T> GetChild(char _char)
        {
            if (Children != null)
                foreach (var item in Children)
                    if (item.name == _char) return item;
            return null;
        }
       /// <summary>
       /// 添加子节点
       /// </summary>
       /// <param name="_char"></param>
        public void Add(char _char)
        {
            if (GetChild(_char) != null)
                return;
            add(new SearchTreeNode<T>() { name = _char });
        }
        /// <summary>
        /// 通过全名添加子节点
        /// </summary>
        /// <param name="str"></param>
        public void Add(string str)
        {
            if (GetChild(str) != null)
                return;
            add(new SearchTreeNode<T>() { name = str[str.Length - 1] });
        }
        
        public bool Contains(char _char) => GetChild(_char) != null;
    
        public bool Contains(string str) => GetChild(str) != null;
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return (obj as SearchTreeNode<T>).FullName == FullName;
        }
        /// <summary>
        /// 获取所有子节点
        /// </summary>
        /// <returns></returns>
        public List<SearchTreeNode<T>> GetAllChildren()
        {
            var ls = new List<SearchTreeNode<T>>();
            if (Children ==null) return ls;
            foreach (var item in Children)
            {
                ls.Add(item);
                foreach (var item1 in item.GetAllChildren()) ls.Add(item1);
            }
            return ls;
        }
        /// <summary>
        /// 获取所有非空子节点
        /// </summary>
        /// <returns></returns>
        public  List<SearchTreeNode<T>> Get_All_Children_Not_Empty()
        {
            var ls = new List<SearchTreeNode<T>>();
            foreach (var item in GetAllChildren())
                if (!item.IsEmpty)
                    ls.Add(item);
            return ls;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
      /// <summary>
      /// 通过全名删除子节点
      /// </summary>
      /// <param name="str"></param>
        public void Remove(string str)
        {
            if (Children != null)
                foreach (var item in Children)
                {
                    if (item.FullName == str)
                    {
                        item.Father = null;
                        Children.Remove(item);
                        return;
                    }

                }

        }
        /// <summary>
        /// 通过名称删除子点
        /// </summary>
        /// <param name="_char"></param>
        public void Remove(char _char)
        {
            if (Children != null)
                foreach (var item in Children)
                {
                    if (item.name == _char)
                    {
                        item.Father = null;
                        Children.Remove(item);
                        return;
                    }
                }
        }
     
        public static bool operator ==(SearchTreeNode<T> node1, SearchTreeNode<T> node2) => Equals(node1, node2);
        public static bool operator !=(SearchTreeNode<T> node1, SearchTreeNode<T> node2) => !Equals(node1, node2);
        private char name;
        public SearchTreeNode<T> GetChild(SearchTreeNode<T> child)
        {
            if (Children != null)
                foreach (var item in Children)
                    if (item.FullName == child.FullName) return item;
            return null;
        }
        public void Remove(SearchTreeNode<T> node)
        {
            if (Children != null)
                foreach (var item in Children)
                {
                    if (item.FullName == node.FullName)
                    {
                        node.Father = null;
                        Children.Remove(item);
                        return;
                    }
                }
        }
        private void add(SearchTreeNode<T> node)
        {
            if (node.Father != null)
                node.Father.Remove(node);
            node.Father = this;
            if (Children == null) Children = new LinkedList<SearchTreeNode<T>>();
            Children.AddLast(node);
        }
        public void Add(SearchTreeNode<T> node)
        {
            if (GetChild(node) != null)
                return;
            add(node);
        }
        /// <summary>
        /// 获取全名
        /// </summary>
        /// <returns></returns>
        private string _getFullName()
        {
            var b = this;
            var name = this.name.ToString();
            while (b.Father != null)
            {
                name = b.Father.name + name;
                b = b.Father;
            }
            return name.Length == 1 ? name : name.Substring(1, name.Length - 1);
        }
        private int getAllChildrenCount()
        {
            var t = Count;
            if (Children != null)
                foreach (var item in Children) t += item.getAllChildrenCount();
            return t;
        }
    }
}
