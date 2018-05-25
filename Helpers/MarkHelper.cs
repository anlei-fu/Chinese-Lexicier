using Fal.DataStructure.Hash_Table;

namespace Fal.Chinese.Helpers
{
    public  class MarkHelper
    {
        private static string _coupleMarkString = "";
        private static  Double_Dictionary _coupleMark = new Double_Dictionary(_coupleMarkString);
        public static bool IsCouple(char ch, string str,int start)
        {
            return str.IndexOf(ch, start) - start < 200;
        }
        public static bool IsCoupleMark(char ch)
        {
            return _coupleMark.Conatins(ch.ToString());
        }
        public static bool IsSubSentenceEndMark(char ch)
        {
            return ch == '，';
        }
        public static bool IsSentenceEndMark(char ch)
        {

            return ch == '。' || ch == '？' || ch == '！' || ch == '…' || ch == '；' ;

        }
        public static bool IsInvalidChar(char ch)
        {

            return ch == '\r' || ch == '\b' || ch == '\f' || ch =='\n';
        }
        public static bool IsMathMark(string str)
        {
            switch (str.GetMarkTypeFromString())
            {
                case Test.Chinese.Helpers.MarkType.Plus:
                case Test.Chinese.Helpers.MarkType.Minus:
                case Test.Chinese.Helpers.MarkType.PlusOrMinus:
                case Test.Chinese.Helpers.MarkType.MutipliedBy:
                case Test.Chinese.Helpers.MarkType.DividedBy:
                case Test.Chinese.Helpers.MarkType.EquelTo:
                case Test.Chinese.Helpers.MarkType.NotEquelTo:
                case Test.Chinese.Helpers.MarkType.ApproximatelyEqual:
                case Test.Chinese.Helpers.MarkType.LessThan:
                case Test.Chinese.Helpers.MarkType.MoreThan:
                case Test.Chinese.Helpers.MarkType.NotLessThan:
                case Test.Chinese.Helpers.MarkType.NotMoreThan:
                case Test.Chinese.Helpers.MarkType.LessOrEquel:
                case Test.Chinese.Helpers.MarkType.MoreOrEquel:
                case Test.Chinese.Helpers.MarkType.Percent:
                case Test.Chinese.Helpers.MarkType.Permill:
                case Test.Chinese.Helpers.MarkType.Infinity:
                case Test.Chinese.Helpers.MarkType.Root:
                case Test.Chinese.Helpers.MarkType.Since:
                case Test.Chinese.Helpers.MarkType.Hence:
                case Test.Chinese.Helpers.MarkType.Pi:
                case Test.Chinese.Helpers.MarkType.PerpendicularTo:
                case Test.Chinese.Helpers.MarkType.UnionOf:
                case Test.Chinese.Helpers.MarkType.IntersectionOf:
                case Test.Chinese.Helpers.MarkType.IntegralOf:
                case Test.Chinese.Helpers.MarkType.SummationOf:
                case Test.Chinese.Helpers.MarkType.Degree:
                case Test.Chinese.Helpers.MarkType.Minute:
                case Test.Chinese.Helpers.MarkType.Second:
                case Test.Chinese.Helpers.MarkType.OpenParen:
                case Test.Chinese.Helpers.MarkType.CloseParen:
                case Test.Chinese.Helpers.MarkType.Angle:
                case Test.Chinese.Helpers.MarkType.Arc:
                case Test.Chinese.Helpers.MarkType.Triangle:
                case Test.Chinese.Helpers.MarkType.Circle:
                case Test.Chinese.Helpers.MarkType.Power:
                case Test.Chinese.Helpers.MarkType.BelongTo:
                case Test.Chinese.Helpers.MarkType.NotBelongTo:
                case Test.Chinese.Helpers.MarkType.Include:
                case Test.Chinese.Helpers.MarkType.BeIncluded:
                case Test.Chinese.Helpers.MarkType.EquelMark:
                case Test.Chinese.Helpers.MarkType.Derivation:
                case Test.Chinese.Helpers.MarkType.Not:
                case Test.Chinese.Helpers.MarkType.Any:
                    return true;
                default:
                    return false;
            }
        }

      
    }
}
