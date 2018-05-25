using ConsoleApp1.Chinese.WordInfo;
using Fal.Nlp.Chinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Test.Chinese.Helpers.Delegates;

namespace Test.Chinese.Helpers
{
  public static  class WordTypeHelper
    {




        public static WordType GetBigType(this WordType type)
        {
            switch (type)
            {
                case WordType.Verb:

                case WordType.VerbLexicalVerb:

                case WordType.VerbLink:

                case WordType.VerbHave:

                case WordType.VerbSituationism:

                case WordType.VerbSituationismWant:

                case WordType.VerbSituationismWill:

                case WordType.VerbSituationismCan:

                case WordType.VerbSituationismShould:

                case WordType.VerbSituationismMust:

                case WordType.VerbHope:

                case WordType.VerbNeed:

                case WordType.VerbSituationismDare:

                case WordType.VerbSituationismWish:

                case WordType.VerbLike:

                case WordType.VerbGei:

                case WordType.VerbShi:

                case WordType.verbQing:

                case WordType.VerbAction:

                case WordType.VerbExistChangeDisapear:

                case WordType.VerbActionOfMind:

                case WordType.VerbDirection:

                case WordType.VerbDevelope:

                case WordType.VerbTransitive:

                case WordType.VerbIntrasitive:

                case WordType.VerbPeople:

                case WordType.VerbPlant:

                case WordType.VerbAnimal:

                case WordType.VerbSustance:

                case WordType.VerbOpinion:

                case WordType.VerbNoun:
                    return WordType.Verb;

                case WordType.Noun:

                case WordType.NounName:

                case WordType.NounPeopeleName:

                case WordType.NounChineseLastName:

                case WordType.NounJapanneseLastName:

                case WordType.NounForeignLastName:

                case WordType.NounFirstName:

                case WordType.NounPlaceName:

                case WordType.NounPlaceNameGeograph:

                case WordType.NounPlaceNameOfAdministrative:

                case WordType.NounPlaceNameOfBuilding:

                case WordType.NounTime:

                case WordType.NounDirection:

                case WordType.NounAbstract:

                case WordType.NounAlphaNumberMark:

                case WordType.NounCollective:

                case WordType.NounCommon:

                case WordType.NounProper:

                case WordType.NounCountable:

                case WordType.NounUncountable:

                case WordType.NounConcrete:

                case WordType.NounInstuation:

                case WordType.NounCulture:

                case WordType.NounAnimal:

                case WordType.NounPlant:

                case WordType.NounAnimalBird:

                case WordType.NounAnimalBuru:

                case WordType.NounAnimalFish:

                case WordType.NounAnimalPaxing:

                case WordType.NounLiangQi:

                case WordType.NounInsect:

                case WordType.NounMicro:

                case WordType.NounTool:

                case WordType.NounSubtence:

                case WordType.NounPolitical:

                case WordType.NounEconomi:

                case WordType.NounPe:

                case WordType.NounFood:

                case WordType.NounEntertaiment:

                case WordType.NounScience:

                case WordType.NounReligion:

                case WordType.NounMilitary:

                case WordType.NounOccupation:

                case WordType.NounIllness:

                case WordType.NounWeapen:

                case WordType.NounWeather:

                case WordType.NounEducation:

                case WordType.NounOrgan:

                case WordType.NounCalling:

                case WordType.NounInstrument:
                case WordType.NounPlace:
                    return WordType.Noun;

                case WordType.AdJective:

                case WordType.AdjectiveScope:

                case WordType.AdjectiveSex:

                case WordType.AdjectiveColor:

                case WordType.AdjectiveLength:

                case WordType.AdjectiveLook:

                case WordType.AdjectiveNewOld:

                case WordType.AdjectiveAge:

                case WordType.AdjectiveMood:

                case WordType.AdjectiveNumber:

                case WordType.AdjectiveShape:

                case WordType.AdjectivePeople:

                case WordType.AdjectiveChild:

                case WordType.AdjectiveAdult:

                case WordType.AdjectiveMan:

                case WordType.AdjectiveWoman:

                case WordType.AdjectiveSpeed:

                case WordType.AdjectiveBigSmall:

                case WordType.AdjectiveWeather:

                case WordType.AdjectivePersonaty:

                case WordType.AdjectivePlace:

                case WordType.AdjectiveAnimal:

                case WordType.AdjectivePlant:

                case WordType.AdjectiveFood:
                    return WordType.AdJective;

                case WordType.Conjunction:

                case WordType.ConjunctionStructureAnd:

                case WordType.ConjunctionStructureOr:

                case WordType.ConjunctionAndStart:

                case WordType.ConjunctionAndEnd:

                case WordType.ConjunctionUnderTakeStart:

                case WordType.ConjunctionUnderTakeEnd:

                case WordType.ConJunctionProcessStart:

                case WordType.ConjunctionProcessEnd:

                case WordType.ConjunctionSelectionStart:

                case WordType.ConjunctionSelectionEnd:

                case WordType.ConjunctionAdvertStart:

                case WordType.ConjunctionAdvertEnd:

                case WordType.ConjunctionSupposeStart:

                case WordType.ConjunctionSupposeEnd:

                case WordType.ConJunctionConditionStart:

                case WordType.ConjunctionConditionEnd:

                case WordType.ConjunctionReasonResultStart:

                case WordType.ConjunctionReasonResultEnd:

                case WordType.ConjunctionSub:

                case WordType.ConjunctionSummery:

                case WordType.ConjunctionDestination:
                    return WordType.Conjunction;

                case WordType.Adverb:

                case WordType.AdverContinuity:

                case WordType.AdvProcessing:

                case WordType.AdverbFrequency:

                case WordType.AdverbDegreeGeng:

                case WordType.AdverbDegreeHeng:

                case WordType.AdverDegreeZui:

                case WordType.AdverbScopeDou:

                case WordType.AdverbScopeYe:

                case WordType.AdverbScopeZhi:

                case WordType.AdverbTime:

                case WordType.AdverbTimeYijing:

                case WordType.AdverbTimeLe:

                case WordType.AdverbTimeJiu:

                case WordType.AdverbTimeZheng:

                case WordType.AdverbManner:

                case WordType.AdverbYesNoYes:

                case WordType.AdverbYesNoNo:

                case WordType.AdverbModal:

                case WordType.AdverbIntergrate:

                case WordType.AdverbGong:

                case WordType.AdverbZai:

                case WordType.AdverbHai:

                case WordType.AdverbCai:

                case WordType.AdverbTogther:
                    return WordType.Adverb;

                case WordType.Number:

                case WordType.NumOrder:

                case WordType.NumberApproxiateBefore:

                case WordType.NumberApproxiateAfter:

                case WordType.NumberConcrete:

                case WordType.NumberPulary:

                case WordType.NumberDeng:
                    return WordType.Number;

                case WordType.Classifier:
                    return WordType.Classifier;

                case WordType.Pronoun:

                case WordType.PronounPerSonal:

                case WordType.PronounPossessive:

                case WordType.PronounReflexive:

                case WordType.PronounDemonstrative:

                case WordType.PronounInterrogative:

                case WordType.PronounReciprocal:

                case WordType.PronounIndefinite:

                case WordType.PronounConjunctive:

                case WordType.PronounRelation:

                case WordType.ProNounEvery:

                case WordType.ProNounAll:

                case WordType.ProNounAny:

                case WordType.ProNounEach:

                case WordType.ProNounWho:

                case WordType.ProNounWhere:

                case WordType.ProNounWhy:

                case WordType.ProNounWhos:

                case WordType.ProNounHow:

                case WordType.ProNounOther:

                case WordType.ProNounWhen:

                case WordType.ProNounWhat:

                case WordType.ProNounPeople:

                case WordType.ProNounTime:

                case WordType.ProNounPlace:
                    return WordType.Pronoun;

                case WordType.Preposition:

                case WordType.PrepositionExcept:

                case WordType.PrepositionCompare:

                case WordType.PrepositionCong:

                case WordType.PrepositionAn:

                case WordType.PrepositionYong:

                case WordType.PrepositionXiang:

                case WordType.PrepositionDang:

                case WordType.PrepositionBei:

                case WordType.PrepositionBa:

                case WordType.PrepositionSui:

                case WordType.PrepositionAbout:

                case WordType.PrepositionZai:

                case WordType.prepositionAccording:

                case WordType.PrepositionTi:

                case WordType.PrepositionDao:

                case WordType.PrepositionKao:

                case WordType.PrepositionLai:

                case WordType.PrepositionBang:

                case WordType.PrepositionZhi:
                    return WordType.Preposition;

                case WordType.Auxiliary:

                case WordType.AuxiliaryModalParticle:

                case WordType.AuxiliaryStructure:

                case WordType.AuxiliaryAdVerb:

                case WordType.AuxiliaryVerb:

                case WordType.AuxiliaryZhe:

                case WordType.AuxiliaryZhi:

                case WordType.AuxiliarySuo:

                case WordType.AuxliaryNone:
                    return WordType.Auxiliary;

                case WordType.Exclamation:
                    return WordType.Exclamation;

                case WordType.Onomatopoetic:

                case WordType.OnomatopoeticPeople:

                case WordType.OnomatopoeticAnimal:

                case WordType.OnomatopoeticPlant:

                case WordType.OnomatopoeticUnknow:
                    return WordType.Onomatopoetic;

                case WordType.Idiom:
                    return WordType.Idiom;

                case WordType.Abbreviation:
                    return WordType.Abbreviation;

                case WordType.Mark:
                    return WordType.Mark;

                case WordType.Unknow:
                default:
                    return WordType.Unknow;

            }
        }
        #region IS
        public static bool IsNoun(this WordType type) => type.GetBigType() == WordType.Noun;
        public static bool IsVerb(this WordType type) => type.GetBigType() == WordType.Verb;
        public static bool IsAdjective(this WordType type) => type.GetBigType() == WordType.AdJective;
        public static bool IsAdverb(this WordType type) => type.GetBigType() == WordType.Adverb;
        public static bool IsConjunction(this WordType type) => type.GetBigType() == WordType.Conjunction;

        public static bool IsNotStructureConjunction(this WordType type) => type.GetBigType() == WordType.Conjunction && (type != WordType.ConjunctionStructureAnd && type != WordType.ConjunctionStructureOr);
        public static bool IsStrucreConjunction(this WordType type) => type == WordType.ConjunctionStructureAnd || type == WordType.ConjunctionStructureOr;
        public static bool IsNumber(this WordType type) => type.GetBigType() == WordType.Number;
        public static bool IsPreposition(this WordType type) => type.GetBigType() == WordType.Preposition;
        public static bool IsProNoun(this WordType type) => type.GetBigType() == WordType.Pronoun;
        public static bool IsAuxliary(this WordType type) => type.GetBigType() == WordType.Auxiliary;
        public static bool IsIdiom(this WordType type) => type.GetBigType() == WordType.Idiom;
        public static bool IsAbbraviation(this WordType type) => type.GetBigType() == WordType.Abbreviation;
        public static bool IsMark(this WordType type) => type.GetBigType() == WordType.Mark;
        public static bool IsExclamtion(this WordType type) => type.GetBigType() == WordType.Exclamation;
        public static bool IsUnknow(this WordType type) => type.GetBigType() == WordType.Unknow;
        public static bool IsClassification(this WordType type) => type.GetBigType() == WordType.Classifier||type==WordType.NounTimeClassifer;
        public static bool IsOnomatopoetic(this WordType type) => type.GetBigType() == WordType.Onomatopoetic;
        public static bool IsName(this WordType type)

        {
            switch (type)
            {
                case WordType.NounName:
                case WordType.NounPeopeleName:
                case WordType.NounChineseLastName:
                case WordType.NounJapanneseLastName:
                case WordType.NounForeignLastName:
                case WordType.NounFirstName:
                case WordType.NounPlaceName:
                case WordType.NounPlace:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsPeopleName(this WordType type)
        {
            switch (type)
            {
               
                case WordType.NounPeopeleName:
                case WordType.NounChineseLastName:
                case WordType.NounJapanneseLastName:
                case WordType.NounForeignLastName:
                case WordType.NounFirstName:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsTime(this WordType type)
        {
            switch (type)
            {
                case WordType.NounTime:
                case WordType.NounDirection:
                case WordType.NounTimeHoliday:
                case WordType.NounTimeClassifer:
                    return true;
            }

            return false;
        }
        public static bool IsAnimal(this WordType type)
        {
            switch (type)
            {

                case WordType.NounAnimal:
                case WordType.NounAnimalBird:
                case WordType.NounAnimalBuru:
                case WordType.NounAnimalFish:
                case WordType.NounAnimalPaxing:
                case WordType.NounLiangQi:
                case WordType.NounInsect:
                    return true;
            }
            return false;
        }
        public static bool IsBigNoun(this WordType type)
        {
            switch (type)
            {
             
                case WordType.NounPlaceNameGeograph:
                case WordType.NounPlaceNameOfAdministrative:
                case WordType.NounPlaceNameOfBuilding:
                case WordType.NounTime:
                case WordType.NounDirection:
                case WordType.NounCollective:
                case WordType.NounInstuation:
                case WordType.NounCulture:
                case WordType.NounAnimal:
                case WordType.NounPlant:
                case WordType.NounAnimalBird:
                case WordType.NounAnimalBuru:
                case WordType.NounAnimalFish:
                case WordType.NounAnimalPaxing:
                case WordType.NounLiangQi:
                case WordType.NounInsect:
                case WordType.NounMicro:
                case WordType.NounTool:
                case WordType.NounClothing:
                case WordType.NounCountry:
                case WordType.NounSubtence:
                case WordType.NounFood:
                case WordType.NounScience:
                case WordType.NounReligion:
                case WordType.NounOccupation:
                case WordType.NounIllness:
                case WordType.NounWeapen:
                case WordType.NounWeather:
                case WordType.NounEducation:
                case WordType.NounOrgan:
                case WordType.NounCalling:
                case WordType.NounInstrument:
                case WordType.NounPlace:
                case WordType.NounTimeHoliday:
                case WordType.NounRice:
                case WordType.NounBigType:
                case WordType.NounDisaster:
                    return true;
                
            }
            return false;
        }
        public static bool IsBiology(this WordType type)
        {
            if (type == WordType.NounPlant)
                return true;
            if (type == WordType.NounMicro)
                return true;
            return IsAnimal(type);
        }
        public static bool IsPlace(this WordType type)
        {
            switch (type)
            {
                case WordType.NounCountry:
                case WordType.NounPlaceName:
                case WordType.NounPlaceNameGeograph:
                case WordType.NounPlaceNameOfAdministrative:
                case WordType.NounPlaceNameOfBuilding:
                case WordType.NounDirection:
                case WordType.NounInstuation:
                case WordType.NounPlace:
                    return true;
            }
            return false;
        }
        public static bool IsSituationism(this  WordType type)
        {

            switch (type)
            {
               
                case WordType.VerbSituationism:
                case WordType.VerbSituationismWant:
                case WordType.VerbSituationismWill:
                case WordType.VerbSituationismCan:
                case WordType.VerbSituationismShould:
                case WordType.VerbSituationismMust:
                case WordType.VerbSituationismDare:
                case WordType.VerbSituationismWish:
                    return true;
               
            }
            return false;
        }
        public static bool IsTool(this WordType type)
        {
            switch (type)
            {
                case WordType.NounTool:
                case WordType.NounClothing:
                case WordType.NounSubtence:
                case WordType.NounFood:
                case WordType.NounWeapen:
                case WordType.NounOrgan:
                case WordType.NounInstrument:
                    return true;
            }
            return false;
        }
        public static bool IsConnective(this WordType type)
        {
            if (type == WordType.NounCollective)
                return true;
            return IsTime(type) || IsTool(type) || IsBiology(type) || IsPlace(type);
        }
        public static bool IsAdjectiveAdverb(this WordType type)
        {
            switch (type)
            {
                case WordType.AdverbFrequency:
                case WordType.AdverbDegreeGeng:
                case WordType.AdverbDegreeHeng:
                case WordType.AdverDegreeZui:
                case WordType.AdverDegreeWei:
                    return true;
            }
            return false;
        }
       
        #endregion
        #region    contains
        public static bool ContainsConjunction(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsConjunction());
        }
        public static bool ContainsAuxiliary(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsAuxliary());
        }
        public static bool ContainsPreposition(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsPreposition());
        }
        public static bool ContainsPronoun(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsProNoun());
        }
        public static bool ContainsNumber ( this _WordInnfo w)
        {
            return contains(w, (x) => x.IsNumber());
        }
        public static bool ContainsAdverb(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsAdverb());
        }
       
        public static bool ContainsAdjective(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsAdjective());
        }
        public static bool ContainsVerb(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsVerb());
        }

        public static bool ContainsNoun(this _WordInnfo w)
        {
           return contains(w, (x) => x.IsNoun());
        }

        public static bool ContainsCollective(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsConnective());
        }

        public static bool ContainsAdjectiveAdverb(this _WordInnfo w)
        {
            return contains(w, (x) => x.IsAdjectiveAdverb());
        }







        private static bool contains(_WordInnfo w,Contains c)
        {
            foreach (var item in w.TypeInfo)
                if (c(item.Key))
                    return true;
            return false;
        }






        #endregion

        #region
        /// <summary>
        /// 获取 所有noun
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public static List<KeyValuePair<WordType, int>> GetNoun(this _WordInnfo w)
            => get(w, (x) => x.IsNoun());
        /// <summary>
        /// 获取 所有verb
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public static List<KeyValuePair<WordType, int>> GetVerb(this _WordInnfo w)
           => get(w, (x) => x.IsVerb());
        public static List<KeyValuePair<WordType, int>> GetAdjective(this _WordInnfo w)
            => get(w, (x) => x.IsAdjective());
        public static List<KeyValuePair<WordType, int>> GetAdverb(this _WordInnfo w)
           => get(w, (x) => x.IsAdverb());
        public static List<KeyValuePair<WordType, int>> GetClassifier(this _WordInnfo w)
            => get(w, (x) => x.IsClassification());
        public static List<KeyValuePair<WordType, int>> GetAuxliary(this _WordInnfo w)
           => get(w, (x) => x.IsAuxliary());
        public static List<KeyValuePair<WordType, int>> GetConjunction(this _WordInnfo w)
            => get(w, (x) => x.IsConjunction());
        public static List<KeyValuePair<WordType, int>> GetPronoun(this _WordInnfo w)
           => get(w, (x) => x.IsProNoun());
        public static List<KeyValuePair<WordType, int>> GetNumber(this _WordInnfo w)
            => get(w, (x) => x.IsNumber());
        public static List<KeyValuePair<WordType, int>> GetPreposition(this _WordInnfo w)
           => get(w, (x) => x.IsPreposition());
        public static List<KeyValuePair<WordType, int>> GetAdjectiveAdverb(this _WordInnfo w)
            => get(w, (x) => x.IsAdjectiveAdverb());
        private static List<KeyValuePair<WordType, int>> get(_WordInnfo w,Contains s)
        {
            List<KeyValuePair<WordType, int>> res = new List<KeyValuePair<WordType, int>>();
            foreach (var item in w.TypeInfo)
                if (s(item.Key))
                    res.Add(item);
            return res;
        }
        #endregion

    }
}
