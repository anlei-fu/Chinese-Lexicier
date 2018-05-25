using Fal.DataStructure.Hash_Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Fal
{
    namespace Nlp
    {
        public enum Text_Align
        {
            Left=1,
            Center,
            Right,
        }
        public class String_Position
        {
            public String_Position()
            {
            }
            public String_Position(int start, int length)
            {
                this.Start = start;
                this.Length = length;
            }
            public override bool Equals(object obj)
            {
                if (obj.GetType() != GetType())
                    return false;
                if (((String_Position)obj).Start == Start)
                    return true;
                return false;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public int Start = -1;
            public int Length = -1;
        }
        /****************************************************
         * record  a word's positionsl. in a passage.
         * as a result structure, to receive  StringHelper's
         * Get_Position();
         * Get_Position_With_Match();
         **************************************************/
        public class String_Info
        {
            public String_Info()
            {

            }
            public String_Info(string str)
            {
                this.Type = Regex_Helper.Get_String_Type(str);
            }
            public String_Type Type = String_Type.UNKNOW;
            public string Name = string.Empty;
            public int Count
            {
                get
                {
                    return PositionS.Count;
                }
            }
            public List<String_Position> PositionS = new List<String_Position>();
        }
        /*******************************************************
         *  a static class ,provide some basic string operation.
         *  select,reverse,splite,replace.......
         *  
         ******************************************************/
        public class StringHelper
        {

            public static int LastIndexOf(string str, int start, HashSet<char> input)
            {
                if (start > str.Length || start < 0)
                    throw new Exception("out of range!");
                for (int i = start; i >= 0; i--)
                {
                    if (input.Contains(str[i]))
                        return i;
                }
                return -1;
            }
            public static string Reverse(string str)
            {
                var ch = str.ToArray();
                Array.Reverse(ch);
                return new string(ch);
            }
            public static string Range_Reverse(string str, int start, int end)
            {
                char[] ch1 = null;
                try
                {
                    ch1 = str.Substring(start, end - start).ToArray();
                }
                catch
                {
                    return str;
                }
                Array.Reverse(ch1);
                var ch2 = str.ToArray();
                var t = 0;
                for (int i = start; i < end; i++, t++)
                    ch2[i] = ch1[t];
                return new string(ch2);
            }



            public static List<string> Select_With_Match(string str, string start, string end)
            {
                var ls = new List<string>();
                int t = 0, k = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    t = str.IndexOf(start, i);
                    if (t == -1) break;
                    k = str.IndexOf(end, t + start.Length);
                    if (k == -1) break;
                    if (k < t)
                        for (int j = k; j < str.Length; j++)
                        {
                            k = k + 1;
                            if (k > str.Length) break;
                            k = str.IndexOf(end, k);
                            if (k > t) break;
                            if (k == -1) return ls;
                        }
                    ls.Add(str.Substring(t, k - t + end.Length));
                    i = k;
                }
                return ls;
            }
            public static string Rang_Replace(string str, string oldpattern, string newpattern, int start, int end)

            {
                string temp = string.Empty;
                try
                {
                    temp = str.Substring(start, end - start);
                }
                catch
                {
                    return str;
                }

                str = str.Replace(temp, "*&ds2￥h5j%^w我kjd");
                temp = temp.Replace(oldpattern, newpattern);
                return str.Replace("*&ds2￥h5j%^w我kjd", temp);
            }

            public static List<string> Select(string str, string start, string end)
            {

                var ls = new List<string>();
                int t = 0, k = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    t = str.IndexOf(start, i);
                    if (t == -1) break;
                    k = str.IndexOf(end, t + start.Length);
                    if (k == -1) break;
                    ls.Add(str.Substring(t, k - t + end.Length));
                    i = k;
                }
                return ls;
            }
            public static List<string> Select1(string str, string start, string end)
            {

                var ls = new List<string>();
                int t = 0, k = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    t = str.IndexOf(start, i);
                    if (t == -1) break;
                    k = str.IndexOf(end, t + start.Length);
                    if (k == -1) break;
                    ls.Add(str.Substring(t + 1, k - t + end.Length - 2));
                    i = k;
                }
                return ls;
            }
            public static List<string> Select_With_Count(string str, string start, string end, int count = 1)
            {
                List<string> ls = new List<string>();
                if (str is null) return ls;
                int t = 0, k = 0;
                if (count < 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        t = str.IndexOf(start, i);
                        if (t == -1) break;
                        k = str.IndexOf(end, t + start.Length);
                        if (k == -1) break;
                        ls.Add(str.Substring(t, k - t + end.Length));
                        i = k;
                    }
                    return ls;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    t = str.IndexOf(start, i);
                    if (t == -1) break;
                    k = str.IndexOf(end, t + start.Length);
                    if (k == -1) break;
                    ls.Add(str.Substring(t, k - t + end.Length));
                    if (ls.Count == count) break;
                    i = k;
                }
                return ls;
            }
            public static List<string> Splite(string str, string pattern, int count = -1)
            {
                var ls = new List<string>();
                var use_count = true;
                if (count <= 0)
                    use_count = false;
                int _count = 0;
                if (str is null)
                    return ls;
                int t = 0;
                int k = 0;
                while (true)
                {
                    t = str.IndexOf(pattern, k);
                    if (t == -1)
                    {
                        ls.Add(str.Substring(k, str.Length - k) + pattern);
                        break;
                    }
                    t += pattern.Length;
                    ls.Add(str.Substring(k, t - k));
                    k = t;
                    if (k == str.Length)
                        return ls;
                    if (!use_count)
                        continue;
                    if (++_count == count)
                        return ls;
                }
                return ls;
            }
            public static List<string> Splite1(string str, string pattern, int count = -1)
            {
                var ls = new List<string>();
                var use_count = true;
                if (count <= 0)
                    use_count = false;
                int _count = 0;
                if (str is null)
                    return ls;
                int t = 0;
                int k = 0;
                while (true)
                {
                    t = str.IndexOf(pattern, k);
                    if (t == -1)
                    {
                        ls.Add(str.Substring(k, str.Length - k));
                        break;
                    }

                    ls.Add(str.Substring(k, t - k));
                    k = t + 1;
                    if (k == str.Length)
                        return ls;
                    if (!use_count)
                        continue;
                    if (++_count == count)
                        return ls;
                }
                return ls;
            }
            public static List<string> Splite(string str, IEnumerable<String> splitors)
            {

                var t = 0;
                var k = 1000000;
                var ls = new List<string>();
                while (true)
                {
                    foreach (var item in splitors)
                    {
                        var b = str.IndexOf(item, t);
                        b = b == -1 ? 1000000 : b;
                        if (k >= b)
                            k = b;
                    }
                    if (k == 1000000)
                    {
                        if (t != str.Length)
                            ls.Add(str.Substring(t, str.Length - t));
                        break;
                    }
                    ls.Add(str.Substring(t, k + 1 - t));

                    t = k + 1;
                    k = 1000000;
                }
                return ls;

            }
            public static string Get_One_Return(string str)
            {
                str = str.Replace("\r", "\n");
                int t = 0;
                while (t != -1)
                {
                    str = str.Replace("\n\n", "\n");
                    t = str.IndexOf("\n\n");
                }
                return str.Replace("\n", "\r\n");
            }
            public static string Get_One_Blank(string str)
            {
                str = str.Replace("\t", " ");
                StringBuilder sb = new StringBuilder();
                bool rm = false;
                foreach (var item in str)
                {
                    var temp = item.ToString();
                    if (temp == " ")
                    {
                        if (rm)
                            continue;
                        rm = true;
                    }
                    else
                        rm = false;
                    sb.Append(temp);
                }
                return sb.ToString();
            }
            public static string Format_To_Paragraph(string str)
            {
                return str.Replace("\r\n", "\r\n  ");
            }
            public static string Remove_Format_Chars(string str)
            {
                HashSet<char> temp = new HashSet<char>() { '\n', '\t', '\r', ' ', };
                var sb = new StringBuilder();
                foreach (var item in str)
                {
                    if (!temp.Contains(item))
                        sb.Append(item);
                }
                return sb.ToString();
            }
            public static List<String_Position> Get_Position(string str, string pattern)
            {
                var ls = new List<String_Position>();
                if (str == "")
                    return ls;
                if (pattern == "")
                    return ls;
                int t = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    t = str.IndexOf(pattern, i);
                    if (t == -1)
                        break;
                    ls.Add(new String_Position(t, pattern.Length));
                    i = t + pattern.Length;
                }
                return ls;
            }
            public static List<String_Position> Get_Position_With_Match(string str, string start, string end, int count = -1)
            {
                var ls = new List<String_Position>();
                var use_count = true;
                if (count <= 0)
                    use_count = false;
                var _count = 0;
                int t = 0, k = 0;

                while (true)
                {
                    t = str.IndexOf(start, k);
                    if (t == -1) return ls;
                    k = str.IndexOf(end, t);
                    if (k == -1) return ls;
                    ls.Add(new String_Position(t, k + end.Length - t));
                    k += end.Length;
                    if (!use_count) continue;
                    if (++_count == count) return ls;
                }

            }
            /********************************************************
             * 将每个英文单词第一个字母大写
             * ******************************************************/
            public static string Upper_First_Letter(string str)
            {
                if (string.IsNullOrEmpty(str))
                    return str;
                return str[0].ToString().ToUpper()
                        + str.Remove(0, 1);
            }
            public static string Remove_With_Match(string str, string start, string end)
            {
                int t = 0, k = 0;

                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    t = str.IndexOf(start, k);
                    if (t == -1)
                    {
                        sb.Append(str.Substring(k, str.Length - k));
                        break;
                    }
                    sb.Append(str.Substring(k, t - k));
                    k = str.IndexOf(end, t);
                    if (k == -1)
                    {
                        sb.Append(str.Substring(t, str.Length - t));
                        break;
                    }
                    k += end.Length;
                }
                return sb.ToString();
            }

            /********************************
             * 移除 匹配中的字符串
             * *********************************************/
            public static void Remove_With_Match(ref string str, string start, string end, int count = -1)
            {
                int t = 0, k = 0;
                var use_count = true;
                if (count <= 0)
                    use_count = true;
                var _count = 0;
                while (true)
                {
                    t = str.IndexOf(start, k);
                    if (t == -1)
                        return;
                    k = str.IndexOf(end, t + start.Length);
                    if (k == -1)
                        return;
                    str = str.Remove(t, k + end.Length - t);
                    k = t;
                    if (!use_count)
                        continue;
                    if (++_count == count)
                        return;
                }
            }
            /***********************
             * 用于分割英文单词和标点
             * ************************************************/
            public static void Add_Blank_Before_And_After_English_Mark(ref string str)
                                                       => str.Replace(",", " , ").Replace("'", " . ").Replace("'", " ' ")
                                                             .Replace("\"", " \" ").Replace(";", " ; ").Replace("!", " ! ")
                                                             .Replace("?", " ? ").Replace(":", " : ");
            public static List<string> Get_All_Number_In_Mixed_String(string str)
            {
                var ls = new List<string>();
                foreach (var item in Flex.Flex_Mixed_Number_And_Other(str))
                    if (Regex_Helper.Is_Number(item[item.Length - 1].ToString()))
                        ls.Add(item.Trim());
                return ls;
            }
            /*******************************
             * 加倍字符串
             * *******************************/
            public static string Repeat(string str, int time)
            {
                int t = 0;
                var temp = str;
                while (++t < time)
                    str += temp;
                return str;
            }
            /*************************************
             * 格式化字符链表 
             * 使每一项的长度相同
             * **********************************/
            public static void TextAlign_Format(List<string> ls, Text_Align align = Text_Align.Center)
            {
                var max = 0;
                foreach (var item in ls)
                    max = max > item.Length ? max : item.Length;

                for (int i = 0; i < ls.Count; i++)
                {
                    var temp = "";
                    switch (align)
                    {
                        case Text_Align.Left:
                            ls[i] = ls[i].Length < max ? ls[i] + Repeat(temp, max - ls[i].Length) : ls[i];
                            break;
                        case Text_Align.Center:
                            ls[i] = ls[i].Length < max ? Repeat(temp, max - ls[i].Length / 2) + ls[i] + Repeat(temp, max - ls[i].Length / 2) : ls[i];
                            break;
                        case Text_Align.Right:
                            ls[i] = ls[i].Length < max ? Repeat(temp, max - ls[i].Length) + ls[i] : ls[i];
                            break;
                        default:
                            break;
                    }
                }


            }
            /// <summary>
            /// 统计
            /// </summary>
            /// <param name="source"></param>
            /// <param name="func">判断的函数</param>
            /// <returns></returns>
            public static int Count(string source, Func<char, bool> func)
            {
                int t = 0;
                foreach (var item in source)
                    if (func(item))
                        t++;
                return t;
            }
            /// <summary>
            /// 将mathexpression 切分为 字母 数字 和符号的 序列
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            public static List<string> FlexMathExpression(string str)
            {
                var ls = new List<string>();
                var flag = -1;
                var temp = string.Empty;
                foreach (var item in str)
                    if (Regex_Helper.Is_Alpha(item.ToString()))
                    {
                        if (flag == -1)
                        {
                            if (temp == string.Empty)
                            {
                                temp += item;
                                flag = 0;
                            }
                        }
                        else if (flag == 1)
                            temp += item;
                        else
                        {
                            ls.Add(temp);
                            temp = item.ToString();
                            flag = 1;
                        }

                    }
                    else if (Regex_Helper.Is_Number(item.ToString()))
                    {

                        if (flag == -1)
                        {
                            flag = 0;
                            temp += item;
                        }
                        else if (flag == 0)
                            temp += item;
                        else
                        {
                            ls.Add(temp);
                            temp += item;
                            flag = 0;

                        }
                    }
                    else
                    {
                        ls.Add(temp);
                        ls.Add(item.ToString());
                        flag = -1;
                        temp = string.Empty;

                    }

                ls.Add(temp);
                return ls;

            }

            #region 处理匹配部分
            /*******************************************
             * 获取单个字符处想的所有位置
             * ***********************************************/
            public static List<int> Get_Position(string str,char _char)
            {

                var ls = new List<int>();
                for (int i = 0; i < str.Length; i++)
                    if (str[i] == _char)
                        ls.Add(i);
                return ls;
            }
            /***********************
             * 获取 匹配 的字符串
             * *********************************/
            public static List<String_Position> Get_Match(string str,char _s,char _e)
            {
                return match_Start_End(Get_Position(str,_s), Get_Position(str,_e));
            }
          /*******************
           * 匹配
           * ***********************************************/
            public static  List<String_Position>match_Start_End(List<int> s,List<int> e)
            {
                var ls = new List<String_Position>();
                for (int i = 0; i < e.Count; i++)
                {
                    int index=0;
                    var max_s = -1;
                    for (int j= 0; j < s.Count; j++)
                    {
                        if (e[i] < s[j])
                            break;
                        if (s[j] > max_s)
                            max_s = s[j];
                         index = j;
                    }
                    if(max_s!=-1)
                    {
                        ls.Add(new String_Position(s[index], e[i] - s[index]));
                        s.RemoveRange(index, 1);
                        e.RemoveRange(i, 1);
                        i--;
                    }
                }
                return ls;
            }
#endregion
            #region 处理引号的部分
            /***************************************************
             *处理引号的部分
             * ***********************************/

            public static List<string> Get_Quotations(string str, int count = 100000000)
            {
                var ls = new List<string>();
                List<int> pos = new List<int>();
                for (int i = 0; i < str.Length; i++)
                    if (str[i] == '"')
                    {
                        if (i > 0)
                            if (str[i - 1] == '\\')
                                continue;
                        pos.Add(i);
                    }
                for (int i = 1; i < pos.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        ls.Add(str.Substring(pos[i - 1], pos[i] - pos[i - 1]+1));
                        if (ls.Count == count)
                            break;
                    }
                }


                return ls;
            }







            /*****************************************************
             * 替换引号中的一些字符
             * 
             ****************************************************/
            public static string Format_Quota(string str)
            {
                var b = Get_Quotations(str);
                for (int i = 0; i < b.Count; i++)
                {
                    bool flag = false;
                    var temp = b[i];
                    for (int j = 0; j < b[i].Length; j++)
                    {
                        if (_quota_chars.Contains(b[i][j]))
                        {
                            temp = temp.Replace(b[i][j].ToString(), _quota_Dic.Get_Value(b[i][j].ToString()));
                            flag = true;
                        }
                        if (flag)
                            str = str.Replace(b[i], temp);
                    }
                }

                return str;

            }
            public static string Format_Quota(string str,IEnumerable<char> input)
            {
                var b = Get_Quotations(str);
                for (int i = 0; i < b.Count; i++)
                {
                    bool flag = false;
                    var temp = b[i];
                    for (int j = 0; j < b[i].Length; j++)
                    {
                        if (input.Contains(b[i][j]))
                        {
                            temp = temp.Replace(b[i][j].ToString(), _quota_Dic.Get_Value(b[i][j].ToString()));
                            flag = true;
                        }
                        if (flag)
                            str = str.Replace(b[i], temp);
                    }
                }

                return str;

            }
            public static string Format_Quota1(string str, IEnumerable<char> input)
            {
                var sb = new StringBuilder();
                bool flag = false;
                for (int i = 0; i < str.Length; i++)
                {
                    if(str[i]=='\"')
                        flag = !flag;
                    if (!flag)
                        sb.Append(str[i]);
                    else
                    {
                        if (input.Contains(str[i]))
                            sb.Append(_quota_Dic.Get_Value(str[i].ToString()));
                        else
                            sb.Append(str[i]);
                    }
                }
                return sb.ToString();
            }
            public static string Format_Quota2(string str, IEnumerable<char> input)
            {
                var sb = new StringBuilder();
                bool flag = false;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '\'')
                        flag = !flag;
                    if (!flag)
                        sb.Append(str[i]);
                    else
                    {
                        if (input.Contains(str[i]))
                            sb.Append(_quota_Dic.Get_Value(str[i].ToString()));
                        else
                            sb.Append(str[i]);
                    }
                }
                return sb.ToString();
            }
            public static string Retrive_From_Quota_Format(string str,IEnumerable<char> input)
            {
                foreach (var item in input)
                {
                    var g = item.ToString();
                    str = str.Replace(_quota_Dic.Get_Value(item.ToString()), item.ToString());
                }
                return str;
            }
            /************************************************
             * 从被引号format过的字符串中恢复原来的字符
             ****************************************************/
            public static string Retrive_From_Quota_Format(string str)
            {
                return str.Replace("f_0_l", " ").Replace("f_1_l", "'").Replace("f_2_l", ",").Replace("f_3_l", "=").Replace("f_4_l", ";").Replace("f_5_l", "(")
                    .Replace("f_6_l", ")").Replace("f_7_l", "[").Replace("f_8_l", "]").Replace("f_9_l", "{").Replace("f_10_l", "}").Replace("f_11_l", "<")
                    .Replace("f_12_l", ">").Replace("f_13_l", "?").Replace("f_14_l", ".").Replace("f_15_l", "!").Replace("f_16_l", "#")
                    .Replace("f_17_l", "@").Replace("f_18_l", "%").Replace("f_19_l", "^").Replace("f_20_l", "&")
                    .Replace("f_21_l", "|").Replace("f_22_l", "`").Replace("f_23_l", "~").Replace("f_24_l", "\\")
                    .Replace("f_25_l","\"").Replace("f_26_l", "-").Replace("f_27_l", "_").Replace("f_28_l", "+")
                    .Replace("f_29_l", "*").Replace("f_30_l", "/").Replace("f_31_l", "\r").Replace("f_32_l", "\n")
                    .Replace("f_33_l","1").Replace("f_34_l","2").Replace("f_35_l","3").Replace("f_36_l","4").Replace("f_37_l","5").Replace("f_38_l","6")
                    .Replace("f_39_l","7").Replace("f_40_l","8").Replace("f_41_l","9").Replace("f_42_l","0").Replace("f_43_l","a").Replace("f_44_l","b")
                    .Replace("f_45_l","c").Replace("f_46_l","d").Replace("f_47_l","e").Replace("f_48_l","f").Replace("f_49_l","g").Replace("f_50_l","h")
                    .Replace("f_51_l","i").Replace("f_52_l","j").Replace("f_53_l","k").Replace("f_54_l","l").Replace("f_55_l","m").Replace("f_56_l","n")
                    .Replace("f_57_l","o").Replace("f_58_l","p").Replace("f_59_l","q").Replace("f_60_l","r").Replace("f_61_l","s").Replace("f_62_l","t")
                    .Replace("f_63_l","u").Replace("f_64_l","v").Replace("f_65_l","w").Replace("f_66_l","x").Replace("f_67_l","y").Replace("f_68_l","z")
                    .Replace("f_69_l","A").Replace("f_70_l","B").Replace("f_71_l","C").Replace("f_72_l","D").Replace("f_73_l","E").Replace("f_74_l","F")
                    .Replace("f_75_l","G").Replace("f_76_l","H").Replace("f_77_l","I").Replace("f_78_l","J").Replace("f_79_l","K").Replace("f_80_l","L")
                    .Replace("f_81_l","M").Replace("f_82_l","N").Replace("f_83_l","O").Replace("f_84_l","P").Replace("f_85_l","Q").Replace("f_86_l","R")
                    .Replace("f_87_l","S").Replace("f_88_l","T").Replace("f_89_l","U").Replace("f_90_l","V").Replace("f_91_l","W").Replace("f_92_l","X")
                    .Replace("f_93_l","Y").Replace("f_94_l","Z");

            }
            /*********************************************
             * 
             *******************************************/
            private static string _quota_Dic_String = "':f_0_l\r\n,:f_1_l\r\n=:f_2_l\r\n;:f_3_l\r\n(:f_4_l\r\n):f_5_l\r\n[:f_6_l\r\n]:f_7_l\r\n{:f_8_l\r\n}:f_9_l\r\n" +
                "<:f_10_l\r\n>:f_11_l\r\n :f_12_l\r\n?:f_13_l\r\n.:f_14_l\r\n!:f_15_l\r\n#:f_16_l\r\n@:f_17_l\r\n%:f_18_l\r\n^:f_19_l\r\n&:f_20_l\r\n|:f_21_l\r\n`:f_22_l\r\n" +
                "~:f_23_l\r\n\\:f_24_l\r\n\":f_25_l\r\n-:f_26_l\r\n_:f_27_l\r\n+:f_28_l\r\n*:f_29_l\r\n/:f_30_l\r\n" +
                "\r:f_31_l\r\n" +
                "\n:f_32_l\r\n1:f_33_l\r\n2:f_34_l\r\n3:f_35_l\r\n4:f_36_l\r\n5:f_37_l\r\n6:f_38_l\r\n7:f_39_l\r\n8:f_40_l\r\n9:f_41_l\r\n0:f_42_l\r\na:f_43_l\r\n" +
                "b:f_44_l\r\nc:f_45_l\r\nd:f_46_l\r\ne:f_47_l\r\nf:f_48_l\r\ng:f_49_l\r\nh:f_50_l\r\ni:f_51_l\r\nj:f_52_l\r\nk:f_53_l\r\nl:f_54_l\r\nm:f_55_l\r\n" +
                "n:f_56_l\r\no:f_57_l\r\np:f_58_l\r\nq:f_59_l\r\nr:f_60_l\r\ns:f_61_l\r\nt:f_62_l\r\nu:f_63_l\r\nv:f_64_l\r\nw:f_65_l\r\nx:f_66_l\r\ny:f_67_l\r\nz:f_68_l\r\n" +
                "A:f_69_l\r\nB:f_70_l\r\nC:f_71_l\r\nD:f_72_l\r\nE:f_73_l\r\nF:f_74_l\r\nG:f_75_l\r\nH:f_76_l\r\nI:f_77_l\r\nJ:f_78_l\r\nK:f_79_l\r\nL:f_80_l\r\nM:f_81_l\r\n" +
                "N:f_82_l\r\nO:f_83_l\r\nP:f_84_l\r\nQ:f_85_l\r\nR:f_86_l\r\nS:f_87_l\r\nT:f_88_l\r\nU:f_89_l\r\nV:f_90_l\r\nW:f_91_l\r\nX:f_92_l\r\nY:f_93_l\r\nZ:f_94_l\r\n";
            /********************************************
             * 引号中需要被格式化的字符
             ********************************************/
            private static HashSet<char> _quota_chars = new HashSet<char>()
            {
                ',','=',';','(',')','[',']','{','}','<','>',' ','?','.','!','#','@','%','^','&','|','`','~','=','\'','\\','\"','-','_','+','-','*','/',
                '1','2','3','4','5','6','7','8','9','0',
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                '\r','\n','\t'
            };
             /****************************************
              * 格式化，恢复 引号格式化的双向字典
              **********************************/
            private static Double_Dictionary _quota_Dic = new Double_Dictionary(_quota_Dic_String);
          
        }
#endregion


       
    }
}
