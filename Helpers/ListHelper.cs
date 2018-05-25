using Fal.DataStructure.List.ListHelper;
using Fal.Nlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fal.DataStructure.List
{
   public static class List_Helper
    {
        /***********************************
         * 获取int 链表
         ************************************/
        public static List<int> From_String_Int(string str)
        {
            var ls = new List<int>();
            str = str.Trim();
            foreach (var item in StringHelper.Splite(str.Substring(0, str.Length - 1), ","))
                ls.Add(int.Parse(item.Substring(0, item.Length - 1).Trim()));
            return ls;
        }
        /***********************************
        * 获取float 链表
        ************************************/
        public static List<float> From_String_Float(string str)
        {
            var ls = new List<float>();
            str = str.Trim();
            foreach (var item in StringHelper.Splite(str.Substring(0, str.Length - 1), ","))
                ls.Add(float.Parse(item.Substring(0, item.Length - 1).Trim()));
            return ls;
        }
        /***********************************
        * 获取string 链表
        ************************************/
        public static List<string> From_String_String(string str)
        {
            var ls = new List<string>();
            str = str.Trim();
            foreach (var item in StringHelper.Splite(str.Substring(0, str.Length - 1), ","))
                ls.Add(item.Substring(0, item.Length - 1).Trim());
            return ls;
        }
        /***********************************
        * 获取char 链表
        ************************************/
        public static List<char> From_String_Char(string str)
        {
            var ls = new List<char>();
            str = str.Trim();
            foreach (var item in StringHelper.Splite(str.Substring(0, str.Length - 1), ","))
                ls.Add(item.Substring(0, item.Length - 1).Trim()[0]);
            return ls;
        }
        /***********************************
        * 获取double 链表
        ************************************/
        public static List<double> From_String_Double(string str)
        {
            var ls = new List<double>();
            str = str.Trim();
            foreach (var item in StringHelper.Splite(str.Substring(0, str.Length - 1), ","))
                ls.Add(double.Parse(item.Substring(0, item.Length - 1).Trim()));
            return ls;
        }
        /****************************************
         * 格式化实现IEnumerable<T> 对象到 字符串
         * *********************************************/
        public static string To_String<T>(IEnumerable<T> ls)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in ls)
                sb.Append(item.ToString() + ",");
            return sb.Append("]").ToString();
        }
        /****************************************
        * 格式化实现IEnumerable<string> 对象到 字符串
        * *********************************************/
        public static string To_String_String(IEnumerable<string> ls)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            foreach (var item in ls)
                sb.Append("_fal" + item + "fal_");
            return sb.Append("}").ToString();
        }
        /**************************************************
         * 将链表的数据进行分类统计，T必须实现equals()
         * ******************************************************/
        public static List<Classify_Class<T>> Classify_List_By_CompareTo<T>(IEnumerable<T> input)
        {
            var ls = new List<Classify_Class<T>>();
            int t = 0;
            foreach (var item in input)
            {
                Classify_Class<T> _iterator = null;
                foreach (var item1 in ls)
                    if (item1.Value.Equals(item))
                    {
                        _iterator = item1;
                        break;
                    }
                if (_iterator == null)
                    ls.Add(new Classify_Class<T>(item,t) );
                else
                    _iterator.Index.Add(t);
                t++;

            }
            return ls;
        }
        public static List<T> Get_Interlace<T>(List< List<T>> collection1) where T : IEquatable<T>
        {
            if (collection1.Count == 1)
                return Get_Unique<T>(collection1[0]);
            var g= Get_Unique<T>(collection1[0]);
            for (int i = 1; i < collection1.Count; i++)
            {
                var g1 = Get_Unique<T>(collection1[i]);
                g = Get_Interlace<T>(g, g1);
            }
            return g;
        }
        /****************************************
        * 求两个集合的交集
        * *************************************/
        public static List<T> Get_Interlace<T>(IEnumerable<T> collection1, IEnumerable<T> collection2) where T : IEquatable<T>
        {
            var ls =new List<T>();
            collection1 = Get_Unique<T>(collection1);
            foreach (var item in collection1)
                if (!collection2.Contains(item))
                    ls.Add(item);
            return ls;
        }
        /****************************************
         * 求两个集合的并集，并移除原集合中的重复元素
         * *************************************/
        public static List<T> Get_All<T>(IEnumerable<T> collection1, IEnumerable<T> collection2) where T : IEquatable<T>
        {
            var ls = Get_Unique(collection1);
            foreach (var item in collection2)
                if (!ls.Contains(item)) ls.Add(item);
            return ls;
        }
        /*********************************
        * 移除原集合中的重复元素
        **************************************/
        public static List<T> Get_Unique<T>(IEnumerable<T> collection) where T : IEquatable<T>
        {
            var ls = new List<T>();
            foreach (var item in collection)
                if (!ls.Contains(item)) ls.Add(item);
            return ls;
        }
        /****************************************************
         * 求两个集合的差集，并移除重复元素
         * **************************************************/
        public static List<T> Get_Unique<T>(IEnumerable<T> collection1, IEnumerable<T> collection2) where T : IEquatable<T>
        {
            var ls = new List<T>();
            foreach (var item in Get_Unique(collection1))
                if (!ls.Contains(item))
                    if (!collection2.Contains(item)) ls.Add(item);
            return ls;
        }
        public static List<List<T>> Divide<T>(IEnumerable<T> collection, int length)
        {
            var ls = new List<List<T>>();
            var t = 0;
            var g = 0;
            foreach (var item in collection)
            {
                if (t == 0)
                {
                    ls.Add(new List<T>());
                    g++;
                }
                else
                {
                    if (t++ > length - 1)
                        t = 0;
                    ls[g].Add(item);
                }
            }
            while (ls[g].Count < length)
                ls[g].Add(default(T));
            return ls;
        }
        public static HashSet<T> To_Hashset<T>(IEnumerable<T> collection)
        {
            var hs = new HashSet<T>();
            foreach (var item in collection)
                if (!hs.Contains(item))
                    hs.Add(item);
            return hs;
        }

        public static LinkedList<T> To_Linked_List<T>(IEnumerable<T> input)
        {
            var ls = new LinkedList<T>();
            foreach (var item in input)
                ls.AddLast(item);
            return ls;
        }

        public static List<T>Select<T>(List<T> input,int start,int end)
        {
            if (!checkRange(input.Count, start, end))
                throw new Exception($"out of range {input.Count},{start},{end}");
            List<T> ls = new List<T>();
            for (int i = start; i < end+1; i++)
                ls.Add(input[i]);
            return ls;
        }

        public static void Replace<T>(List<T> source,int start1,int end1,List<T> insert,int start2,int end2)
        {
         if(!checkRange(source.Count,start1,end1)&&!checkRange(insert.Count,start2,end2))
                throw  new Exception($"out of range {source.Count},{start1},{end2},{insert.Count},{start2},{end2}");
            source.RemoveRange(start1, end1 - start1);
            source.InsertRange(start1, Select<T>(insert, start2, end2));

        }


        private static bool checkRange(int length,int start,int end)
        {
            return start <= end && end < length && start > -1;
        }
    }
}
