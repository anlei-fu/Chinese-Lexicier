using Fal.Chinese.Structure._Passage._Paragraph._Sentence.WordInfo.WordType;
using Fal.Nlp.Chinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Chinese.Helpers;

namespace Fal.Chinese.Helpers
{
    public static class EnumConvertor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ConvertMarkTypeToString(this MarkType type)
        {
            switch (type)
            {
                case MarkType.FullStop: return ".";
                case MarkType.Comma: return ",";
                case MarkType.Colon: return ";";
                case MarkType.SemiColon: return ":";
                case MarkType.QuestionMark: return "?";
                case MarkType.ExclamationMark: return "!";
                case MarkType.Apostrope: return "`";
                case MarkType.Hyphen: return "-";
                case MarkType.Dash: return "--";
                case MarkType.Dots: return "...";
                case MarkType.SingleQuotationMark: return "'";
                case MarkType.DoubleQuotationMark: return "\"";
                case MarkType.Parallel: return "|";
                case MarkType.And: return "&";
                case MarkType.SwungDash: return "~";
                case MarkType.Plus: return "+";
                case MarkType.Minus: return "-";
                case MarkType.PlusOrMinus: return "±";
                case MarkType.MutipliedBy: return "*";
                case MarkType.DividedBy: return "/";
                case MarkType.EquelTo: return "=";
                case MarkType.NotEquelTo: return "≠";
                case MarkType.ApproximatelyEqual: return "≈";
                case MarkType.LessThan: return "<";
                case MarkType.MoreThan: return ">";
                case MarkType.NotLessThan: return "≮ ";
                case MarkType.NotMoreThan: return "≯";
                case MarkType.LessOrEquel: return "≤";
                case MarkType.MoreOrEquel: return "≥";
                case MarkType.Percent: return "%";
                case MarkType.Permill: return "‰";
                case MarkType.Infinity: return "∞";
                case MarkType.Root: return "√";
                case MarkType.Since: return "∵";
                case MarkType.Hence: return "∴";
                case MarkType.Pi: return "π";
                case MarkType.PerpendicularTo: return "⊥";
                case MarkType.UnionOf: return "∪";
                case MarkType.IntersectionOf: return "∩";
                case MarkType.IntegralOf: return "∫";
                case MarkType.SummationOf: return "∑";
                case MarkType.Degree: return "° ";
                case MarkType.Minute: return "′ ";
                case MarkType.Second: return "〃";
                case MarkType.CelsiusSystem: return "℃";
                case MarkType.OpenBrace: return "{";
                case MarkType.CloseBrace: return "}";
                case MarkType.OpenParen: return "(";
                case MarkType.CloseParen: return ")";
                case MarkType.OpenBracket: return "[";
                case MarkType.CloseBracket: return "]";
                case MarkType.ChineseQuestionMark: return "？";
                case MarkType.ChineseExclamationMark: return "！";
                case MarkType.ChineseComma: return "，";
                case MarkType.ChineseFullStop: return "。";
                case MarkType.ChineseColon: return "；";
                case MarkType.ChineseSemicolon: return "：";
                case MarkType.ChineseOpenSingleQuotation: return "‘";
                case MarkType.ChineseCloseSingleQuotation: return "’";
                case MarkType.ChineseOpenDoubleQuotation: return "“";
                case MarkType.ChineseCloseDoubleQuotation: return "”";
                case MarkType.SlightPauseMark: return "、";
                case MarkType.ChineseOpenBrace: return "｛";
                case MarkType.ChineseCloseBrace: return "｝";
                case MarkType.ChineseOpenBrackt: return "【";
                case MarkType.ChineseCloseBrakt: return "】";
                case MarkType.ChineseOpenParen: return "（";
                case MarkType.ChineseCloseParen: return "）";
                case MarkType.OpenBookTitle: return "《";
                case MarkType.CloseBookTitle: return "》";
                case MarkType.Rmb: return "￥";
                case MarkType.Doller: return "$";
                case MarkType.Poun: return "￡";
                case MarkType.Angle: return "∠";
                case MarkType.Triangle: return "△";
                case MarkType.Arc: return "⌒";
                case MarkType.Circle: return "⊙";
                case MarkType.Power: return "^";
                case MarkType.BelongTo: return "∈";
                case MarkType.Include: return "⊇";
                case MarkType.BeIncluded: return "⊆";
                case MarkType.EquelMark: return "⇔";
                case MarkType.Derivation: return "⇒";
                case MarkType.Not: return "￢";
                case MarkType.Any: return "∀";
                case MarkType.UnderScode: return "_";
                case MarkType.Hash: return "#";
                case MarkType.At: return "@";
                default: return "unknow";
            }
        }
        public static MarkType GetMarkTypeFromString(this string str)
        {
            switch (str)
            {
                case ".": return MarkType.FullStop;
                case ",": return MarkType.Comma;
                case ";": return MarkType.Colon;
                case ":": return MarkType.SemiColon;
                case "?": return MarkType.QuestionMark;
                case "!": return MarkType.ExclamationMark;
                case "'": return MarkType.SingleQuotationMark;
                case "\"": return MarkType.DoubleQuotationMark;
                case "`": return MarkType.Apostrope;
                case "~": return MarkType.SwungDash;
                case "@": return MarkType.At;
                case "#": return MarkType.Hash;
                case "$": return MarkType.Doller;
                case "%": return MarkType.Percent;
                case "^": return MarkType.Power;
                case "&": return MarkType.And;
                case "*": return MarkType.MutipliedBy;
                case "(": return MarkType.OpenParen;
                case ")": return MarkType.CloseParen;
                case "-": return MarkType.Minus;
                case "+": return MarkType.Plus;
                case "_": return MarkType.UnderScode;
                case "=": return MarkType.EquelTo;
                case "{": return MarkType.OpenBrace;
                case "}": return MarkType.CloseBrace;
                case "[": return MarkType.OpenBracket;
                case "]": return MarkType.CloseBracket;
                case "<": return MarkType.LessThan;
                case ">": return MarkType.MoreThan;
                case "/": return MarkType.DividedBy;
                case "...": return MarkType.Dots;
                case "--": return MarkType.Dash;
                case "！": return MarkType.ChineseExclamationMark;
                case "（": return MarkType.ChineseOpenParen;
                case "）": return MarkType.ChineseCloseParen;
                case "【": return MarkType.ChineseOpenBrackt;
                case "】": return MarkType.ChineseCloseBrakt;
                case "｛": return MarkType.ChineseOpenBrace;
                case "｝": return MarkType.ChineseCloseBrace;
                case "。": return MarkType.ChineseFullStop;
                case "，": return MarkType.ChineseComma;
                case "、": return MarkType.SlightPauseMark;
                case "？": return MarkType.ChineseQuestionMark;
                case "|": return MarkType.Parallel;
                case "‘": return MarkType.ChineseOpenSingleQuotation;
                case "’": return MarkType.ChineseCloseSingleQuotation;
                case "“": return MarkType.ChineseOpenDoubleQuotation;
                case "”": return MarkType.ChineseCloseDoubleQuotation;
                case "《": return MarkType.OpenBookTitle;
                case "》": return MarkType.CloseBookTitle;
                case "±": return MarkType.PlusOrMinus;
                case "≠": return MarkType.NotEquelTo;
                case "≈": return MarkType.ApproximatelyEqual;
                case "≮": return MarkType.NotLessThan;
                case "≯": return MarkType.NotMoreThan;
                case "≤": return MarkType.LessOrEquel;
                case "≥": return MarkType.MoreOrEquel;
                case "‰": return MarkType.Permill;
                case "∞": return MarkType.Infinity;
                case "√": return MarkType.Root;
                case "∵": return MarkType.Since;
                case "∴": return MarkType.Hence;
                case "π": return MarkType.Pi;
                case "⊥": return MarkType.PerpendicularTo;
                case "∪": return MarkType.UnionOf;
                case "∩": return MarkType.IntersectionOf;
                case "∫": return MarkType.IntegralOf;
                case "∑": return MarkType.SummationOf;
                case "℃": return MarkType.CelsiusSystem;
                case "￡": return MarkType.Poun;
                case "∠": return MarkType.Angle;
                case "△": return MarkType.Triangle;
                case "⌒": return MarkType.Arc;
                case "⊙": return MarkType.Circle;
                case "∈": return MarkType.BelongTo;
                case "∉": return MarkType.NotBelongTo;
                case "⊇": return MarkType.Include;
                case "⊆": return MarkType.BeIncluded;
                case "⇔": return MarkType.EquelMark;
                case "⇒": return MarkType.Derivation;
                case "￢": return MarkType.Not;
                case "∀": return MarkType.Any;

                default: return MarkType.Unknow;

            }

        }
        public static string ConvertWordTypeToString(this WordType type)
        {
            switch (type)
            {
                #region verb
                case WordType.Verb:
                    return "v";
                case WordType.VerbLexicalVerb:
                    return "vlex";
                case WordType.VerbLink:
                    return "vl";
                case WordType.VerbHave:
                    return "vhv";
                case WordType.VerbSituationism:
                    return "vs";
                case WordType.VerbSituationismWant:
                    return "vswt";
                case WordType.VerbSituationismWill:
                    return "vswl";
                case WordType.VerbSituationismCan:
                    return "vsc";
                case WordType.VerbSituationismShould:
                    return "vss";
                case WordType.VerbHope:
                    return "vhp";
                case WordType.VerbNeed:
                    return "vnd";
                case WordType.VerbSituationismDare:
                    return "vdr";
                case WordType.VerbSituationismWish:
                    return "vsh";
                case WordType.VerbLike:
                    return "vlk";
                case WordType.VerbGei:
                    return "vg";
                case WordType.VerbShi:
                    return "vshi";
                case WordType.verbQing:
                    return "vq";
                case WordType.VerbAction:
                    return "va";
                case WordType.VerbExistChangeDisapear:
                    return "vecd";
                case WordType.VerbActionOfMind:
                    return "vaod";
                case WordType.VerbDirection:
                    return "vdir";
                case WordType.VerbDevelope:
                    return "vdl";
                case WordType.VerbTransitive:
                    return "vtr";
                case WordType.VerbIntrasitive:
                    return "vitr";
                case WordType.VerbPeople:
                    return "vpp";
                case WordType.VerbPlant:
                    return "vpt";
                case WordType.VerbAnimal:
                    return "van";
                case WordType.VerbSustance:
                    return "vst";
                case WordType.VerbNoun:
                    return "vn";
                case WordType.VerbOpinion:
                    return "vo";
                case WordType.VerbSituationismMust:
                    return "vsmt";
                case WordType.VerbNoneMean:
                    return "vnm";
                case WordType.VerbNotVerb:
                    return "vnv";
                #endregion
                #region noun
                case WordType.Noun:
                    return "n";
                case WordType.NounName:
                    return "nn";
                case WordType.NounPeopeleName:
                    return "npn";
                case WordType.NounChineseLastName:
                    return "ncln";
                case WordType.NounJapanneseLastName:
                    return "njln";
                case WordType.NounForeignLastName:
                    return "nfln";
                case WordType.NounFirstName:
                    return "nfn";
                case WordType.NounPlaceName:
                    return "npln";
                case WordType.NounPlaceNameGeograph:
                    return "npng";
                case WordType.NounPlaceNameOfAdministrative:
                    return "npnoa";
                case WordType.NounPlaceNameOfBuilding:
                    return "npnob";
                case WordType.NounTime:
                    return "nt";
                case WordType.NounDirection:
                    return "nd";
                case WordType.NounAbstract:
                    return "nab";
                case WordType.NounAlphaNumberMark:
                    return "nanm";
                case WordType.NounCollective:
                    return "nc";
                case WordType.NounCommon:
                    return "ncom";
                case WordType.NounProper:
                    return "npp";
                case WordType.NounCountable:
                    return "nct";
                case WordType.NounUncountable:
                    return "nuct";
                case WordType.NounConcrete:
                    return "ncr";
                case WordType.NounInstuation:
                    return "nit";
                case WordType.NounCulture:
                    return "nca";
                case WordType.NounAnimal:
                    return "nan";
                case WordType.NounPlant:
                    return "nplt";
                case WordType.NounAnimalBird:
                    return "nanb";
                case WordType.NounAnimalBuru:
                    return "nanbr";
                case WordType.NounAnimalFish:
                    return "nanf";
                case WordType.NounAnimalPaxing:
                    return "nanp";
                case WordType.NounLiangQi:
                    return "nanlq";
                case WordType.NounInsect:
                    return "nani";
                case WordType.NounMicro:
                    return "nanmc";
                case WordType.NounTool:
                    return "ntl";
                case WordType.NounSubtence:
                    return "nsub";
                case WordType.NounPolitical:
                    return "nptc";
                case WordType.NounEconomi:
                    return "ne";
                case WordType.NounPe:
                    return "npe";
                case WordType.NounFood:
                    return "nfd";
                case WordType.NounEntertaiment:
                    return "net";
                case WordType.NounScience:
                    return "nsci";
                case WordType.NounReligion:
                    return "nrg";
                case WordType.NounMilitary:
                    return "nmt";
                case WordType.NounOccupation:
                    return "nocu";
                case WordType.NounIllness:
                    return "nill";
                case WordType.NounWeapen:
                    return "nw";
                case WordType.NounWeather:
                    return "nwt";
                case WordType.NounEducation:
                    return "nedu";
                case WordType.NounOrgan:
                    return "nor";
                case WordType.NounCalling:
                    return "ncal";
                case WordType.NounInstrument:
                    return "nin";
                case WordType.NounClothing:
                    return "ncl";
                case WordType.NounBigType:
                    return "nbt";
                case WordType.NounPlace:
                    return "npl";
                case WordType.NounCountry:
                    return "nplc";
                case WordType.NounTimeHoliday:
                    return "nth";
                case WordType.NounDisaster:
                    return "nds";
                case WordType.NounTimeClassifer:
                    return "ntc";
                case WordType.NounTimeDynasty:
                    return "ntd";
                case WordType.NounColor:
                    return "nclr";
                #endregion
                #region adjective
                case WordType.AdJective:
                    return "a";
                case WordType.AdjectiveSex:
                    return "as";
                case WordType.AdjectiveColor:
                    return "ac";
                case WordType.AdjectiveLength:
                    return "al";
                case WordType.AdjectiveLook:
                    return "alo";
                case WordType.AdjectiveNewOld:
                    return "ano";
                case WordType.AdjectiveAge:
                    return "aa";
                case WordType.AdjectiveMood:
                    return "am";
                case WordType.AdjectiveNumber:
                    return "an";
                case WordType.AdjectiveShape:
                    return "ash";
                case WordType.AdjectivePeople:
                    return "ap";
                case WordType.AdjectiveChild:
                    return "acl";
                case WordType.AdjectiveAdult:
                    return "aad";
                case WordType.AdjectiveMan:
                    return "aman";
                case WordType.AdjectiveWoman:
                    return "awm";
                case WordType.AdjectiveSpeed:
                    return "asp";
                case WordType.AdjectiveBigSmall:
                    return "abs";
                case WordType.AdjectiveWeather:
                    return "awt";
                case WordType.AdjectivePersonaty:
                    return "apn";
                case WordType.AdjectivePlace:
                    return "apl";
                case WordType.AdjectiveAnimal:
                    return "aani";
                case WordType.AdjectivePlant:
                    return "aplt";
                case WordType.AdjectiveFood:
                    return "af";
                case WordType.AdjectiveScope:
                    return "aspe";
                case WordType.AdjectiveLikeEnd:
                    return "alke";
                #endregion
                #region conjunction
                case WordType.Conjunction:
                    return "c";
                case WordType.ConjunctionStructureAnd:
                    return "csa";
                case WordType.ConjunctionStructureOr:
                    return "cso";
                case WordType.ConjunctionAndStart:
                    return "cas";
                case WordType.ConjunctionAndEnd:
                    return "cae";
                case WordType.ConjunctionUnderTakeStart:
                    return "cus";
                case WordType.ConjunctionUnderTakeEnd:
                    return "cue";
                case WordType.ConJunctionProcessStart:
                    return "cps";
                case WordType.ConjunctionProcessEnd:
                    return "cpe";
                case WordType.ConjunctionSelectionStart:
                    return "css";
                case WordType.ConjunctionSelectionEnd:
                    return "cse";
                case WordType.ConjunctionAdvertStart:
                    return "cats";
                case WordType.ConjunctionAdvertEnd:
                    return "cate";
                case WordType.ConjunctionSupposeStart:
                    return "csus";
                case WordType.ConjunctionSupposeEnd:
                    return "csue";
                case WordType.ConJunctionConditionStart:
                    return "ccs";
                case WordType.ConjunctionConditionEnd:
                    return "cce";
                case WordType.ConjunctionReasonResultStart:
                    return "crs";
                case WordType.ConjunctionReasonResultEnd:
                    return "cre";
                case WordType.ConjunctionSub:
                    return "csub";
                case WordType.ConjunctionSummery:
                    return "csum";
                case WordType.ConjunctionDestination:
                    return "cd";
                #endregion
                #region adverb
                case WordType.Adverb:
                    return "ad";
                case WordType.AdverContinuity:
                    return "adc";
                case WordType.AdvProcessing:
                    return "adp";
                case WordType.AdverbFrequency:
                    return "adf";
                case WordType.AdverbDegreeGeng:
                    return "addg";
                case WordType.AdverbDegreeHeng:
                    return "addh";
                case WordType.AdverDegreeZui:
                    return "addz";
                case WordType.AdverbScopeDou:
                    return "adsd";
                case WordType.AdverbScopeYe:
                    return "adsy";
                case WordType.AdverbScopeZhi:
                    return "adsz";
                case WordType.AdverbTime:
                    return "adt";
                case WordType.AdverbTimeYijing:
                    return "adtyj";
                case WordType.AdverbTimeLe:
                    return "adtl";
                case WordType.AdverbTimeJiu:
                    return "adtj";
                case WordType.AdverbTimeZheng:
                    return "adtz";
                case WordType.AdverbManner:
                    return "adm";
                case WordType.AdverbYesNoYes:
                    return "adyn";
                case WordType.AdverbYesNoNo:
                    return "adyny";
                case WordType.AdverbModal:
                    return "adynn";
                case WordType.AdverbIntergrate:
                    return "adi";
                case WordType.AdverbZai:
                    return "adz";
                case WordType.AdverbHai:
                    return "adh";
                case WordType.AdverbCai:
                    return "adci";
                case WordType.AdverbTogther:
                    return "adtg";
                #endregion
                #region number
                case WordType.Number:
                    return "nm";
                case WordType.NumOrder:
                    return "nmo";
                case WordType.NumberApproxiateBefore:
                    return "nmab";
                case WordType.NumberApproxiateAfter:
                    return "nmaa";
                case WordType.NumberConcrete:
                    return "nmc";
                case WordType.NumberPulary:
                    return "nmp";
                case WordType.NumberDeng:
                    return "nmd";
                #endregion
                #region classiffier
                case WordType.Classifier:
                    return "cla";
                #endregion
                #region pronoun
                case WordType.Pronoun:
                    return "pn";
                case WordType.PronounPerSonal:
                    return "pnp";
                case WordType.PronounPossessive:
                    return "pnps";
                case WordType.PronounReflexive:
                    return "pnr";
                case WordType.PronounDemonstrative:
                    return "pnd";
                case WordType.PronounInterrogative:
                    return "pnt";
                case WordType.PronounReciprocal:
                    return "pnrc";
                case WordType.PronounIndefinite:
                    return "pnif";
                case WordType.PronounConjunctive:
                    return "pnc";
                case WordType.ProNounEvery:
                    return "pne";
                case WordType.ProNounAny:
                    return "pna";
                case WordType.ProNounEach:
                    return "pneh";
                case WordType.ProNounWhen:
                    return "pnwn";
                case WordType.ProNounWhere:
                    return "pnwe";
                case WordType.ProNounWho:
                    return "pnwo";
                case WordType.ProNounWhos:
                    return "pnwos";
                case WordType.ProNounWhy:
                    return "pnwy";
                case WordType.ProNounOther:
                    return "pno";
                case WordType.ProNounWhat:
                    return "pnwt";
                case WordType.ProNounHow:
                    return "pnhw";
                case WordType.ProNounPeople:
                    return "pnpp";
                case WordType.ProNounTime:
                    return "pnti";
                case WordType.ProNounPlace:
                    return "pnpl";
                case WordType.PronounRelation:
                    return "pnre";
                #endregion
                #region preposition
                case WordType.Preposition:
                    return "ps";
                case WordType.PrepositionExcept:
                    return "pse";
                case WordType.PrepositionCompare:
                    return "psc";
                case WordType.PrepositionCong:
                    return "pscg";
                case WordType.PrepositionAn:
                    return "psa";
                case WordType.PrepositionYong:
                    return "psy";
                case WordType.PrepositionXiang:
                    return "psx";
                case WordType.PrepositionDang:
                    return "psd";
                case WordType.PrepositionBei:
                    return "psbe";
                case WordType.PrepositionBa:
                    return "psb";
                case WordType.PrepositionSui:
                    return "pss";
                case WordType.PrepositionAbout:
                    return "psat";
                case WordType.PrepositionZai:
                    return "psz";
                case WordType.prepositionAccording:
                    return "psad";
                case WordType.PrepositionZhi:
                    return "pszh";
                case WordType.PrepositionTi:
                    return "pst";
                case WordType.PrepositionKao:
                    return "psk";
                case WordType.PrepositionDao:
                    return "psda";
                case WordType.PrepositionLai:
                    return "psla";
                case WordType.PrepositionBang:
                    return "psba";
                #endregion
                #region aux
                case WordType.Auxiliary:
                    return "ax";
                case WordType.AuxiliaryModalParticle:
                    return "axmp";
                case WordType.AuxiliaryStructure:
                    return "axs";
                case WordType.AuxiliaryAdVerb:
                    return "axad";
                case WordType.AuxiliaryVerb:
                    return "axv";
                case WordType.AuxiliaryZhe:
                    return "axze";
                case WordType.AuxiliaryZhi:
                    return "axz";
                case WordType.AuxliaryNone:
                    return "axn";
                case WordType.AuxiliarySuo:
                    return "axsu";
                
                #endregion
                case WordType.Exclamation:
                    return "e";
                case WordType.Onomatopoetic:
                    return "o";
                case WordType.OnomatopoeticPeople:
                    return "op";
                case WordType.OnomatopoeticAnimal:
                    return "oa";
                case WordType.OnomatopoeticPlant:
                    return "opt";
                case WordType.OnomatopoeticUnknow:
                    return "ou";
                case WordType.Idiom:
                    return "i";
                case WordType.Abbreviation:
                    return "abbr";
                case WordType.Mark:
                    return "m";
                case WordType.Unknow:
                    return "u";
                default:
                    return "u";
            }
        }
        public static WordType GetWordTypeFromString(this string str)
        {
            switch (str)
            {
                #region verb
                case "v":
                    return WordType.Verb;
                case "vlex":
                    return WordType.VerbLexicalVerb;
                case "vl":
                    return WordType.VerbLink;
                case "vhv":
                    return WordType.VerbHave;
                case "vs":
                    return WordType.VerbSituationism;
                case "vswt":
                    return WordType.VerbSituationismWant;
                case "vswl":
                    return WordType.VerbSituationismWill;
                case "vsc":
                    return WordType.VerbSituationismCan;
                case "vss":
                    return WordType.VerbSituationismShould;
                case "vhp":
                    return WordType.VerbHope;
                case "vnd":
                    return WordType.VerbNeed;
                case "vdr":
                    return WordType.VerbSituationismDare;
                case "vsh":
                    return WordType.VerbSituationismWish;
                case "vlk":
                    return WordType.VerbLike;
                case "vg":
                    return WordType.VerbGei;
                case "vshi":
                    return WordType.VerbShi;
                case "vq":
                    return WordType.verbQing;
                case "va":
                    return WordType.VerbAction;
                case "vecd":
                    return WordType.VerbExistChangeDisapear;
                case "vaod":
                    return WordType.VerbActionOfMind;
                case "vdir":
                    return WordType.VerbDirection;
                case "vdl":
                    return WordType.VerbDevelope;
                case "vtr":
                    return WordType.VerbTransitive;
                case "vitr":
                    return WordType.VerbIntrasitive;
                case "vpp":
                    return WordType.VerbPeople;
                case "vpt":
                    return WordType.VerbPlant;
                case "van":
                    return WordType.VerbAnimal;
                case "vst":
                    return WordType.VerbSustance;
                case "vn":
                    return WordType.VerbNoun;
                case "vo":
                    return WordType.VerbOpinion;
                case "vsmt":
                    return WordType.VerbSituationismMust;
                case "vnm":
                    return WordType.VerbNoneMean;
                case "vnv":
                    return WordType.VerbNotVerb;
                #endregion
                #region noun
                case "n":
                    return WordType.Noun;
                case "nn":
                    return WordType.NounName;
                case "npn":
                    return WordType.NounPeopeleName;
                case "ncln":
                    return WordType.NounChineseLastName;
                case "njln":
                    return WordType.NounJapanneseLastName;
                case "nfln":
                    return WordType.NounForeignLastName;
                case "nfn":
                    return WordType.NounFirstName;
                case "npln":
                    return WordType.NounPlaceName;
                case "npng":
                    return WordType.NounPlaceNameGeograph;
                case "npnoa":
                    return WordType.NounPlaceNameOfAdministrative;
                case "npnob":
                    return WordType.NounPlaceNameOfBuilding;
                case "nt":
                    return WordType.NounTime;
                case "nd":
                    return WordType.NounDirection;
                case "nab":
                    return WordType.NounAbstract;
                case "nanm":
                    return WordType.NounAlphaNumberMark;
                case "nc":
                    return WordType.NounCollective;
                case "ncom":
                    return WordType.NounCommon;
                case "npp":
                    return WordType.NounProper;
                case "nct":
                    return WordType.NounCountable;
                case "nuct":
                    return WordType.NounUncountable;
                case "ncr":
                    return WordType.NounConcrete;
                case "nit":
                    return WordType.NounInstuation;
                case "nca":
                    return WordType.NounCulture;
                case "nan":
                    return WordType.NounAnimal;
                case "nplt":
                    return WordType.NounPlant;
                case "nanb":
                    return WordType.NounAnimalBird;
                case "nanbr":
                    return WordType.NounAnimalBuru;
                case "nanf":
                    return WordType.NounAnimalFish;
                case "nanp":
                    return WordType.NounAnimalPaxing;
                case "nanlq":
                    return WordType.NounLiangQi;
                case "nani":
                    return WordType.NounInsect;
                case "nanmc":
                    return WordType.NounMicro;
                case "ntl":
                    return WordType.NounTool;
                case "nsub":
                    return WordType.NounSubtence;
                case "nptc":
                    return WordType.NounPolitical;
                case "ne":
                    return WordType.NounEconomi;
                case "npe":
                    return WordType.NounPe;
                case "nfd":
                    return WordType.NounFood;
                case "net":
                    return WordType.NounEntertaiment;
                case "nsci":
                    return WordType.NounScience;
                case "nrg":
                    return WordType.NounReligion;
                case "nmt":
                    return WordType.NounMilitary;
                case "nocu":
                    return WordType.NounOccupation;
                case "nill":
                    return WordType.NounIllness;
                case "nw":
                    return WordType.NounWeapen;
                case "nwt":
                    return WordType.NounWeather;
                case "nedu":
                    return WordType.NounEducation;
                case "nor":
                    return WordType.NounOrgan;
                case "ncal":
                    return WordType.NounCalling;
                case "nin":
                    return WordType.NounInstrument;
                case "ncl":
                    return WordType.NounClothing;
                case "nbt":
                    return WordType.NounBigType;
                case "npl":
                    return WordType.NounPlace;
                case "nplc":
                    return WordType.NounCountry;
                case "nth":
                    return WordType.NounTimeHoliday;
                case "nds":
                    return WordType.NounDisaster;
                case "ntc":
                    return WordType.NounTimeClassifer;
                case "ntd":
                    return WordType.NounTimeHoliday;
                case "nclr":
                    return WordType.NounColor;
                #endregion
                #region adjective
                case "a":
                    return WordType.AdJective;
                case "as":
                    return WordType.AdjectiveSex;
                case "ac":
                    return WordType.AdjectiveColor;
                case "al":
                    return WordType.AdjectiveLength;
                case "alo":
                    return WordType.AdjectiveLook;
                case "ano":
                    return WordType.AdjectiveNewOld;
                case "aa":
                    return WordType.AdjectiveAge;
                case "am":
                    return WordType.AdjectiveMood;
                case "an":
                    return WordType.AdjectiveNumber;
                case "ash":
                    return WordType.AdjectiveShape;
                case "ap":
                    return WordType.AdjectivePeople;
                case "acl":
                    return WordType.AdjectiveChild;
                case "aad":
                    return WordType.AdjectiveAdult;
                case "aman":
                    return WordType.AdjectiveMan;
                case "awm":
                    return WordType.AdjectiveWoman;
                case "asp":
                    return WordType.AdjectiveSpeed;
                case "abs":
                    return WordType.AdjectiveBigSmall;
                case "awt":
                    return WordType.AdjectiveWeather;
                case "apn":
                    return WordType.AdjectivePersonaty;
                case "apl":
                    return WordType.AdjectivePlace;
                case "aani":
                    return WordType.AdjectiveAnimal;
                case "aplt":
                    return WordType.AdjectivePlant;
                case "af":
                    return WordType.AdjectiveFood;
                case "aspe":
                    return WordType.AdjectiveScope;
                case "alke":
                    return WordType.AdjectiveLikeEnd;
                #endregion
                #region
                case "c":
                    return WordType.Conjunction;
                case "csa":
                    return WordType.ConjunctionStructureAnd;
                case "cso":
                    return WordType.ConjunctionStructureOr;
                case "cas":
                    return WordType.ConjunctionAndStart;
                case "cae":
                    return WordType.ConjunctionAndEnd;
                case "cus":
                    return WordType.ConjunctionUnderTakeStart;
                case "cue":
                    return WordType.ConjunctionUnderTakeEnd;
                case "cps":
                    return WordType.ConJunctionProcessStart;
                case "cpe":
                    return WordType.ConjunctionProcessEnd;
                case "css":
                    return WordType.ConjunctionSelectionStart;
                case "cse":
                    return WordType.ConjunctionSelectionEnd;
                case "cats":
                    return WordType.ConjunctionAdvertStart;
                case "cate":
                    return WordType.ConjunctionAdvertEnd;
                case "csus":
                    return WordType.ConjunctionSupposeStart;
                case "csue":
                    return WordType.ConjunctionSupposeEnd;
                case "ccs":
                    return WordType.ConJunctionConditionStart;
                case "cce":
                    return WordType.ConjunctionConditionEnd;
                case "crs":
                    return WordType.ConjunctionReasonResultStart;
                case "cre":
                    return WordType.ConjunctionReasonResultEnd;
                case "csub":
                    return WordType.ConjunctionSub;
                case "csum":
                    return WordType.ConjunctionSummery;
                case "cd":
                    return WordType.ConjunctionDestination;
                #endregion
                #region
                case "ad":
                    return WordType.Adverb;
                case "adc":
                    return WordType.AdverContinuity;
                case "adp":
                    return WordType.AdvProcessing;
                case "adf":
                    return WordType.AdverbFrequency;
                case "addg":
                    return WordType.AdverbDegreeGeng;
                case "addh":
                    return WordType.AdverbDegreeHeng;
                case "addz":
                    return WordType.AdverDegreeZui;
                case "adsd":
                    return WordType.AdverbScopeDou;
                case "adsy":
                    return WordType.AdverbScopeYe;
                case "adsz":
                    return WordType.AdverbScopeZhi;
                case "adt":
                    return WordType.AdverbTime;
                case "adtyj":
                    return WordType.AdverbTimeYijing;
                case "adtl":
                    return WordType.AdverbTimeLe;
                case "adtj":
                    return WordType.AdverbTimeJiu;
                case "adtz":
                    return WordType.AdverbTimeZheng;
                case "adm":
                    return WordType.AdverbManner;
                case "adyn":
                    return WordType.AdverbYesNoYes;
                case "adyny":
                    return WordType.AdverbYesNoNo;
                case "adynn":
                    return WordType.AdverbModal;
                case "adi":
                    return WordType.AdverbIntergrate;
                case "adz":
                    return WordType.AdverbZai;
                case "adh":
                    return WordType.AdverbHai;
                case "adci":
                    return WordType.AdverbCai;
                case "adtg":
                    return WordType.AdverbTogther;
                #endregion
                #region
                case "nm":
                    return WordType.Number;
                case "nmo":
                    return WordType.NumOrder;
                case "nmab":
                    return WordType.NumberApproxiateBefore;
                case "nmaa":
                    return WordType.NumberApproxiateAfter;
                case "nmc":
                    return WordType.NumberConcrete;
                case "nmp":
                    return WordType.NumberPulary;
                case "nmd":
                
                    return WordType.NumberDeng;
                #endregion
                case "cla":
                    return WordType.Classifier;
                #region
                case "pn":
                    return WordType.Pronoun;
                case "pnp":
                    return WordType.PronounPerSonal;
                case "pnps":
                    return WordType.PronounPossessive;
                case "pnr":
                    return WordType.PronounReflexive;
                case "pnd":
                    return WordType.PronounDemonstrative;
                case "pnt":
                    return WordType.PronounInterrogative;
                case "pnrc":
                    return WordType.PronounReciprocal;
                case "pnif":
                    return WordType.PronounIndefinite;
                case "pnc":
                    return WordType.PronounConjunctive;
                case "pne":
                    return WordType.ProNounEvery;
                case "pna":
                    return WordType.ProNounAny;
                case "pneh":
                    return WordType.ProNounEach;
                case "pnwn":
                    return WordType.ProNounWhen;
                case "pnwe":
                    return WordType.ProNounWhere;
                case "pnwo":
                    return WordType.ProNounWho;
                case "pnwos":
                    return WordType.ProNounWhos;
                case "pnwy":
                    return WordType.ProNounWhy;
                case "pno":
                    return WordType.ProNounOther;
                case "pnwt":
                    return WordType.ProNounWhat;
                case "pnhw":
                    return WordType.ProNounHow;
                case "pnpp":
                    return WordType.ProNounPeople;
                case "pnti":
                    return WordType.ProNounTime;
                case "pnpl":
                    return WordType.ProNounPlace;
                case "pnre":
                    return WordType.PronounRelation;
                #endregion
                #region

                case "ps":
                    return WordType.Preposition;
                case "pse":
                    return WordType.PrepositionExcept;
                case "psc":
                    return WordType.PrepositionCompare;
                case "pscg":
                    return WordType.PrepositionCong;
                case "psa":
                    return WordType.PrepositionAn;
                case "psy":
                    return WordType.PrepositionYong;
                case "psx":
                    return WordType.PrepositionXiang;
                case "psd":
                    return WordType.PrepositionDang;
                case "psbe":
                    return WordType.PrepositionBei;
                case "psb":
                    return WordType.PrepositionBa;
                case "pss":
                    return WordType.PrepositionSui;
                case "psat":
                    return WordType.PrepositionAbout;
                case "psz":
                    return WordType.PrepositionZai;
                case "psad":
                    return WordType.prepositionAccording;
                case "pszh":
                    return WordType.PrepositionZhi;
                case "pst":
                    return WordType.PrepositionTi;
                case "psk":
                    return WordType.PrepositionKao;
                case "psda":
                    return WordType.PrepositionDao;
                case "psla":
                    return WordType.PrepositionLai;
                case "psba":
                    return WordType.PrepositionBang;
                #endregion
                #region Auxliary
                case "ax":
                    return WordType.Auxiliary;
                case "axmp":
                    return WordType.AuxiliaryModalParticle;
                case "axs":
                    return WordType.AuxiliaryStructure;
                case "axad":
                    return WordType.AuxiliaryAdVerb;
                case "axv":
                    return WordType.AuxiliaryVerb;
                case "axze":
                    return WordType.AuxiliaryZhe;
                case "axz":
                    return WordType.AuxiliaryZhi;
                case "axn":
                    return WordType.AuxliaryNone;
                case "axsu":
                    return WordType.AuxiliarySuo;
                #endregion
                case "e":
                    return WordType.Exclamation;
                case "o":
                    return WordType.Onomatopoetic;
                case "op":
                    return WordType.OnomatopoeticPeople;
                case "oa":
                    return WordType.OnomatopoeticAnimal;
                case "opt":
                    return WordType.OnomatopoeticPlant;
                case "ou":
                    return WordType.OnomatopoeticUnknow;
                case "i":
                    return WordType.Idiom;
                case "abbr":
                    return WordType.Abbreviation;
                case "m":
                    return WordType.Mark;
                case "u":
                default:
                    return WordType.Unknow;
            }
        }
    }
}
