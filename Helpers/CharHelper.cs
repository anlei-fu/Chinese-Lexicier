using Fal.Nlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fal.Chinese.Helpers
{
  /// <summary>
  /// special-word markable class
  /// </summary>
   public static class CharHelper
    {

        private static HashSet<char> _firstSingleWord = new HashSet<char>()
        {
            '谁','他','它','牠','怹','佗','我','这', '您','该','每', '各', '俺','此','那', '她','你', '哪', '别',         //pro
            '一','二','三','四', '五','六','七','八','九','十','百','千','万','亿','们',                     //num
            '在','于', '对', '自', '比','把','被', '给', '从',                                 //pre
            '了', '的','得',    '着',                                      //aux
            '不','就','也','最', '非',  '还',  '毋', '很','更', '没',                              //adverb
            '啊','吧','呗','啵','啰','吗','嘛','么', '噎','哎','唉','嗄','咍','哈','嗨','喝','嘿','哼','嚄','咳','呐','嗯','呶','喏','呢',  '噢','哦','呸','唦','呦','啥','呵','乎','嚜',//exc
            '与','和','虽','却', '如','若','即', '及','仍',                                                                                                                //con
            '怎',
            '是',              //linkverb
        };
        private static HashSet<char> _secondSingleWord = new HashSet<char>()

        {
            '另','汝', '余','尊','本','彼',  '者', '兹', '子', '伊', '吾',  '尔','夫','其', '繇','侬','斯','躬', '寡','某',  '己',     '诸',                    //pronou
            '打', '看', '将','按','能',  '见', '做', '共', '拦',   '去',  '起','让',  '往', '临','爰', '叫', '望', '问','迎',   '来','脱', '想',  '要','会','有',        //verb
            '头', '人',                               //noun
            '呃','圪',
            '唻','哩','讫','然','哇',  '兮','焉','呀','咦','矣','耶','哟','欤',   '聿','云','哉','旃',
            '除', '跟','朝','随', '令','使', '连', '因',  '照','似',  '由', '用','以', '为', '向', '让',                                                             //pre
           '儿',
            '日','月','分', '时','初',  '今', '年',                                                            //time
            '而', '况','乃','且', '或', '所', '故',  '并'  ,                                                //con
            '没', '太','只','较',  '越','更', '无','兀', '莫', '惟',                                                   //adverb
            '数', '等',  '复',  '再',  '几', '约',  '众',                  //number
            '男','女',                                                   //sex
            '出','过','到','之', '着',                                                //aux
            '上','下','左','右','中','东','南','西','北','里','外','边', '内','外',//direction
            '村','镇','乡','市','街','区','山','省','国','河','江','邦','旗',//地名
            '湖','桥','路','街','岭','峰','坡','湾','岗',//地名
            '大','小','老','曾','据','先','后','前','末','底',
            '短','长','白','黑','红','坏','新','旧', '正','副' ,'多','少','假','好','同','美','丑'     //adj
        };
        private static HashSet<char> _ThirdSingleWord = new HashSet<char>()
        {

        };
        private static HashSet<string> _chineseLastName = new HashSet<string>()
        {


        };
        private static HashSet<string> _foreignNameWords = new HashSet<string>()
        {

        };

        private static HashSet<char> _nameStopWord = new HashSet<char>()
        {
            '谁','他','它','牠','怹','佗','我','这', '您','该','每', '各', '俺','此','那', '她','你', '哪', '别',         //pro
            '一','二','三','四', '五','六','七','八','九','十','百','千','万','亿','们',   //num
            '1','2','3','4', '5','6','7','8','8','0',


            '在','于', '对', '自', '比','把','被', '给', '从',                                 //pre
            '了', '的','得',    '着',                                      //aux
            '不','就','也','最', '非',  '还',  '毋', '很','更', '没',                              //adverb
            '啊','吧','呗','啵','啰','吗','嘛','么', '噎','哎','唉','嗄','咍','哈','嗨','喝','嘿','哼','嚄','咳','呐','嗯','呶','喏','呢',  '噢','哦','呸','唦','呦','啥','呵','乎','嚜',//exc
            '与','和','虽','却', '如','若','即', '及','仍',                                                                                                                //con
            '怎',
            '是',              //linkverb

        };

        private static HashSet<string> _realLastName = new HashSet<string>()
        {
            

        };
        public static bool IsBlank(this char ch)
        {
            return ch == ' ' || ch == '\t';
        }
        
        public static bool IsSecondSingleWord(this char ch)
        {

            return _secondSingleWord.Contains( ch);
        }
        public static bool IsNameStop(char ch)
        {
            return _nameStopWord.Contains(ch);
        }
        public static bool IsFirstSingleWord(this char ch)
        {

            return _firstSingleWord.Contains( ch);
        }
        public static bool IsStopWord(this char ch)
        {
            return IsFirstSingleWord(ch) || Regex_Helper.Is_AMN(ch.ToString());
        }
        public static bool IsSingleWord(this char ch)
        {

            return _firstSingleWord.Contains(ch); 
        }
        public static bool IsThirdSingleWord(char ch)
        {
            return _ThirdSingleWord.Contains(ch);
        }
    }
    
}
