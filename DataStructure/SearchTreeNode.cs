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
    public class Search_Tree_Node<T>
        
    { 
        public Search_Tree_Node()
        { }
        public Search_Tree_Node(char _char)
        {
            this.name = _char;
        }
        public int All_Child_Count { get => get_All_Children_Count(); }
        public LinkedList<Search_Tree_Node<T>> Children { get; set; }
        public T Content { get; set; } 
        public int Count { get => Children == null ? 0 : Children.Count; }
        public Search_Tree_Node<T> this[char name] { get => Get_Child(name); }
        public Search_Tree_Node<T> this[string name] { get => Get_Child(name); }
        public Search_Tree_Node<T> Father { get; set; }
        public string Full_Name { get => _get_Full_Name(); }
        public bool Is_Empty { get;  set; } = true;
        public Search_Tree_Node<T> Get_Child(string str)
        {
            if (Children != null)
                foreach (var item in Children)
                    if (item.Full_Name == str) return item;
            return null;
        }
        public Search_Tree_Node<T> Get_Child(char _char)
        {
            if (Children != null)
                foreach (var item in Children)
                    if (item.name == _char) return item;
            return null;
        }
        public Search_Tree_Node<T> Get_Child(Search_Tree_Node<T> child)
        {
            if (Children != null)
                foreach (var item in Children)
                    if (item.Full_Name == child.Full_Name) return item;
            return null;
        }
        public void Add(char _char)
        {
            if (Get_Child(_char) != null) return;
            add(new Search_Tree_Node<T>() { name = _char });
        }
        public void Add(string str)
        {
            if (Get_Child(str) != null) return;
            add(new Search_Tree_Node<T>() { name = str[str.Length - 1] });
        }
        public void Add(Search_Tree_Node<T> node)
        {
            if (Get_Child(node) != null) return;
            add(node);
        }
        public bool Contains(char _char) => Get_Child(_char) != null;
        public bool Contains(Search_Tree_Node<T> node) => Get_Child(node) != null;
        public bool Contains(string str) => Get_Child(str) != null;
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return (obj as Search_Tree_Node<T>).Full_Name == Full_Name;
        }
        public List<Search_Tree_Node<T>> Get_All_Children()
        {
            var ls = new List<Search_Tree_Node<T>>();
            if (Children ==null) return ls;
            foreach (var item in Children)
            {
                ls.Add(item);
                foreach (var item1 in item.Get_All_Children()) ls.Add(item1);
            }
            return ls;
        }
        public  List<Search_Tree_Node<T>> Get_All_Children_Not_Empty()
        {
            var ls = new List<Search_Tree_Node<T>>();
            foreach (var item in Get_All_Children())
                if (!item.Is_Empty)
                    ls.Add(item);
            return ls;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public void Remove(Search_Tree_Node<T> node)
        {
            if (Children != null)
                foreach (var item in Children)
                {
                    if (item.Full_Name == node.Full_Name)
                    {
                        node.Father = null;
                        Children.Remove(item);
                        return;
                    }
                }
        }
        public void Remove(string str)
        {
            if (Children != null)
                foreach (var item in Children)
                {
                    if (item.Full_Name == str)
                    {
                        item.Father = null;
                        Children.Remove(item);
                        return;
                    }

                }

        }
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
        public override string ToString() => $"{Full_Name}_nd_";
        public static bool operator ==(Search_Tree_Node<T> node1, Search_Tree_Node<T> node2) => Equals(node1, node2);
        public static bool operator !=(Search_Tree_Node<T> node1, Search_Tree_Node<T> node2) => !Equals(node1, node2);
        private char name;
        private void add(Search_Tree_Node<T> node)
        {
            if (node.Father != null) node.Father.Remove(node);
            node.Father = this;
            if (Children == null) Children = new LinkedList<Search_Tree_Node<T>>();
            Children.AddLast(node);
        }
        private string _get_Full_Name()
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
        private int get_All_Children_Count()
        {
            var t = Count;
            if (Children != null)
                foreach (var item in Children) t += item.get_All_Children_Count();
            return t;
        }
    }
}
