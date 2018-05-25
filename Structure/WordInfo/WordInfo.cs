using Fal.Chinese.Helpers;
using Fal.DataStructure;
using Fal.Nlp;
using Fal.Nlp.Chinese;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Chinese.WordInfo
{


    /*******************************************
     * 
     * 该类用于记录每个单词的信息，包括类别及所属的频率
     * 字符串形式为 ()([,][,])
     * 如：
     * (火爆)([ver,36][adj,23])（[])
     * *******************************/
    public class _WordInnfo : IName, IComparable<_WordInnfo>
    {

        public _WordInnfo()
        { }

        public _WordInnfo(string name,WordType t)
        {
            Name = name;
            TypeInfo.Add(t, 1);
        }
        public _WordInnfo(string str)
        {
            Name = str;
        }
        /// <summary>
        /// 最后类型
        /// </summary>
        public WordType FinalType { get; internal set; }
        /// <summary>
        /// 单词名
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// 拼音
        /// </summary>
        public string PinYin { get; set; } = "";
        /// <summary>
        /// 所属第一类型
        /// </summary>
        public Dictionary<WordType, int>TypeInfo { get; set; } = new Dictionary<WordType, int>();
        /// <summary>
        /// 单词长度
        /// </summary>
        public int Length => Name.Length;

     
        /// <summary>
        /// 词性最大的类型
        /// </summary>
        public WordType MaxType;
     
        public void ClearTypeInfo()
        {
            TypeInfo.Clear();
        }
        public _WordInnfo Copy()
        {
            return new _WordInnfo
            {
                Name = this.Name,
                TypeInfo = new Dictionary<WordType, int>(this.TypeInfo),
                PinYin = this.PinYin,
                MaxType = this.MaxType
                
            };
        }
        /// <summary>
        /// 单词频率
        /// </summary>
        public int Frequency
        {
            get
            {
                var t = 0;
                foreach (var item in TypeInfo)
                    t += item.Value;
                return t;
            }
        }
        public bool Contains(WordType type) =>TypeInfo.ContainsKey(type);
     
        /// <summary>
        /// 增加第一词性频率
        /// </summary>
        /// <param name="type"></param>
        public void Add(WordType type,int t=1)
        {
            if (Contains(type))
                TypeInfo[type]+=t;
            else
                TypeInfo.Add(type, t);
        }
        /// <summary>
        /// 移除第一词性
        /// </summary>
        /// <param name="type"></param>
        public void RemoveFirstType(WordType type)
        {
            if (Contains(type))
               TypeInfo.Remove(type);
        }
        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var ls = new List<KeyValuePair<WordType, int>>();
            foreach (var item in TypeInfo)
                ls.Add(item);
            ls.Sort((x, y) => x.Value < y.Value ? 1: x.Value==y.Value?0:-1);

            var str = "(" + Name + ")(";
            foreach (var item in ls)
                str += $"[{item.Key.ConvertWordTypeToString()},{item.Value}]";
            str +=")";
            return str + $"({PinYin})";
        }
        /// <summary>
        /// 解析字符串 创建对象
        /// </summary>
        /// <param name="str"></param>
        public static _WordInnfo Parse(string str)
        {
            var b = StringHelper.Select1(str, "(", ")");
            if (b.Count < 3)
                return null;
            var res = new _WordInnfo();
            res.Name = b[0];
            WordType max = WordType.Unknow;
            bool flag = false;
            foreach (var item in StringHelper.Select1(b[1], "[", "]"))
            {
                var c = StringHelper.Splite1(item, ",");
                if (c.Count != 2)
                    continue;

                var type = c[0].GetWordTypeFromString();
                if (!flag)
                {
                    max = type;
                    flag = !flag;
                }
                if (res.Contains(type))
                    continue;
                var f = 0;
                if (!int.TryParse(c[1], out f))
                    continue;
                res.TypeInfo.Add(type, f);
            }
            res.PinYin = b[2];
            res.MaxType = max;
            return res;
        }
        /// <summary>
        /// 重写equels,
        /// 比较name 是否相同
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            return ((_WordInnfo)obj).Name == Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// 重写compareto
        /// 比较 frequency
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(_WordInnfo other)
        {
            return Frequency.CompareTo(other.Frequency);
        }




        public void Change(WordType t,int f)
        {
            if (!TypeInfo.ContainsKey(t))
                return;
            TypeInfo[t] = f;
        }
    }
}
