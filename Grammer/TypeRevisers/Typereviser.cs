using ConsoleApp1.Chinese._Sentence;
using ConsoleApp1.Chinese.WordInfo;
using Fal.Nlp.Chinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Chinese.Grammer.Graphic;
using Test.Chinese.Grammer.RelationAnalnizer.Revisers;
using Test.Chinese.Helpers;

namespace Test.Chinese.Grammer.RelationAnalnizer
{
    /// <summary>
    /// 此类完成一些特殊词的词性纠正
    /// 和做一些必要的合并
    /// </summary>
    public class WordTypeReviser : BasicReviser
    {
        /// <summary>
        /// 处理 不
        /// </summary>
        /// <param name="pos"></param>
        private void handBu()
        {

            if (!checkPosition())
                doNothing();



            /**************************
             * 去不去 会不会
             * *****************************/
            else if (Previous.Content.Name == Next.Content.Name)
                mergeBothAfterAndBefore(WordType.VerbNotVerb);


            else if (Previous.Content.MaxType.IsVerb())
            {
                /*************************************
                 * 吃不完 打不过 走不动
                 * *************************************/
                if (Next.Content.MaxType.IsVerb())
                    mergeBothAfterAndBefore(WordType.VerbNotVerb);
                /******************************
                 * 管不着 
                 * ************************/
                else if (Next.Content.MaxType.IsAuxliary())
                    mergeBothAfterAndBefore(WordType.VerbNotVerb);
                /***********************
                 * 受不了
                 * **********************/
                else if (Next.Content.MaxType.IsAdverb())
                    mergeBothAfterAndBefore(WordType.VerbNotVerb);
                else
                    doNothing();
            }
            else
                doNothing();

        }

        /// <summary>
        /// Ceng
        /// </summary>
        /// <param name="pos"></param>
        private void handCeng()
        {
            if (Next.Content.MaxType.IsVerb())
                changeType(WordType.AdverbTimeLe);
            else if (Next.Content.MaxType.IsConjunction() || Next.Content.MaxType.IsPreposition())
                changeType(WordType.AdverbTimeLe);
            else
                doNothing();
        }
        private void handLai()
        {
            if (Previous.Content.MaxType.IsTime())
                changeType(WordType.NounTime);
            else
                doNothing();
        }

        /// <summary>
        /// 进去 
        /// </summary>
        /// <param name="pos"></param>
        private void handVdir()
        {
            if (!checkPosition())
                doNothing();
            else if (Next.Content.MaxType == WordType.NumberConcrete)
                changeType(WordType.NumOrder);
            else
                doNothing();

        }
        /// <summary>
        /// 处理 会
        /// </summary>
        /// <param name="pos"></param>
        private void handHui()
        {
            if (!checkPosition())
                doNothing();
            else if ((!(Next.Content.MaxType.IsAdverb() || Next.Content.MaxType.IsVerb())) || (Previous.Content.MaxType == WordType.NounOccupation))
                changeType(WordType.NounInstuation);
            else
                doNothing();
        }
        /// <summary>
        /// 上 
        /// </summary>
        private void handShangXia()
        {
            if (Next.Content.MaxType != WordType.NounTool)
                changeType(WordType.NounDirection);
            else
                doNothing();
        }
        /// <summary>
        /// 处理 将
        /// </summary>
        /// <param name="pos"></param>
        private void handVjiang()
        {
            if (!checkPosition())
                doNothing();
            else if (!(Next.Content.MaxType.IsAdverb() || Next.Content.MaxType.IsVerb()))
                changeType(WordType.PrepositionBa);
            else
                doNothing();
        }
        /// <summary>
        /// 之
        /// </summary>
        private void handAuxZhi()
        {
            if (!checkPosition())
                doNothing();
            /****************************
             * 之强 之 最  之猛
             * ****************************/
            else if (Next.Content.MaxType.IsVerb() || Next.Content.MaxType.IsAdjective() || Next.Content.MaxType.IsAdverb())
                changeType(WordType.AdverbDegreeHeng);
            /********************
             * 之 人  之 一
             * ****************************/
            else if (Next.Content.MaxType.IsNoun() || Next.Content.MaxType.IsNumber())
                changeType(WordType.AuxiliaryStructure);
            /******************
             * 打 之
             * ***************************************/
            else if (Previous.Content.MaxType.IsVerb())
                changeType(WordType.Pronoun);
            else if (Previous.Content.MaxType.IsPreposition())
                changeType(WordType.Pronoun);
            else
                doNothing();
        }
        /// <summary>
        /// 处理 地
        /// </summary>
        /// <param name="pos"></param>
        private void handDi()
        {
            if (!checkPosition())
                doNothing();
            else if (Previous.Content.MaxType.IsNoun())
                changeType(WordType.NounPlace);
            else
                doNothing();

        }
        /// <summary>
        ///处理  能
        /// </summary>
        /// <param name="pos"></param>
        private void handVCan()
        {
            if (!checkPosition())
                doNothing();
            else if (!(Next.Content.MaxType.IsAdverb() || Next.Content.MaxType.IsVerb()))
                changeType(WordType.NounSubtence);
            else
                doNothing();
        }

        /// <summary>
        ///处理  还
        /// </summary>
        /// <param name="pos"></param>
        private void handHai()
        {
            if (!checkPosition())
                doNothing();
            else if (!(Next.Content.MaxType.IsNoun()))
                changeType(WordType.Verb);
            else
                doNothing();
        }
        /// <summary>
        /// 处理 可
        /// </summary>
        private void handKe()
        {
            if (!checkPosition())
                doNothing();
            else if (Next.Content.MaxType == WordType.VerbLink)
                changeType(WordType.AdverbModal);
            else
                doNothing();
        }
        /// <summary>
        /// 处理 处
        /// </summary>
        /// <param name="pos"></param>
        private void handChu()
        {
            if (!checkPosition())
                doNothing();
            else if (Next.Content.MaxType.IsPreposition())
                changeType(WordType.Verb);
            else
                doNothing();
        }
        /// <summary>
        /// 处理 在
        /// </summary>
        /// <param name="pos"></param>
        private void handPreZai()
        {
            if (!checkPosition())
                doNothing();
            else if (Next.Content.MaxType.IsVerb())
                changeType(WordType.AdverbTimeZheng);
            else
                doNothing();
        }
        /// <summary>
        /// 处理 为
        /// </summary>
        /// <param name="pos"></param>
        private void handCWei()
        {

            if (!checkPosition())
                doNothing();
            else if (Next.Content.MaxType.IsNumber())
                changeType(WordType.VerbLink);
            else if (Next.Content.MaxType.IsAdjective())
                changeType(WordType.VerbLink);
            else
                doNothing();
        }

        /// <summary>
        ///处理同
        /// </summary>
        /// <param name="pos"></param>
        private void handTong()
        {
            if (!checkPosition())
                doNothing();
            else if (Previous.Content.MaxType.IsAdverb())
                changeType(WordType.AdJective);
            else if (Previous.Content.MaxType == WordType.PrepositionXiang)
                changeType(WordType.AdJective);
            else
                doNothing();
        }

        /// <summary>
        /// 处理 得
        /// </summary>
        /// <param name="pos"></param>
        private void HanAxDe()
        {

            if (!checkPosition())
                doNothing();
            else if (Previous.Content.MaxType.IsVerb())
            {
                /*************************************
                 * 吃得完
                 * *************************************/
                if (Next.Content.MaxType.IsVerb())
                    mergeBothAfterAndBefore(WordType.VerbNotVerb);
                /*************************************
                * 说得清楚
                * *************************************/
                else if (Next.Content.MaxType.IsAdjective())
                    mergeBothAfterAndBefore(WordType.Verb);
                /*******************
                 * 说得着
                 * **************************/
                else if (Next.Content.MaxType.IsAuxliary())
                    mergeBothAfterAndBefore(WordType.Verb);
                /*****************************/
                else if (Next.Content.MaxType.IsAdverb())
                    mergeBothAfterAndBefore(WordType.Verb);
                else
                    doNothing();
            }
            else if (Previous.Content.MaxType.IsAdjective())
            {


                if (Next.Content.MaxType.IsAdjective())
                    mergeBothAfterAndBefore(WordType.Verb);
                else if (Next.Content.MaxType.IsAuxliary())
                    mergeBothAfterAndBefore(WordType.Verb);
                else if (Next.Content.MaxType.IsAdverb())
                    mergeBothAfterAndBefore(WordType.Verb);
                else
                    doNothing();
            }
            else if (Next.Content.MaxType.IsAdverb())
                changeType(WordType.Verb);
            else
                doNothing();

        }
        /// <summary>
        /// 处理 均
        /// </summary>
        /// <param name="pos"></param>
        private void handJun()
        {
            if (!checkPosition())
                doNothing();
            else if (!(Next.Content.MaxType.IsVerb() || Next.Content.MaxType.IsAdverb()))
                changeType(WordType.Verb);
            else
                doNothing();
        }

        public override void Revise(List<Vertex> ls)
        {
            reset(ls);
            while (CurrentPos < Vertexes.Count)
            {

                if (handClassifier())
                    continue;
                /*****************************
                 * 处理单字
                 * ****************************/
                switch (Current.Content.Name)
                {
                    case "不":
                        handBu();
                        continue;
                    case "曾":
                        handCeng();
                        continue;
                    case "会":
                        handHui();
                        continue;
                    case "将":
                        handVjiang();
                        continue;
                    case "地":
                        handDi();
                        continue;
                    case "得":
                        HanAxDe();
                        continue;
                    case "处":
                        handChu();
                        continue;
                    case "为":
                        handCWei();
                        continue;
                    case "能":
                        handVCan();
                        continue;
                    case "在":
                        handPreZai();
                        continue;
                    case "均":
                        handJun();
                        continue;
                    case "同":
                        handTong();
                        continue;
                    case "约":
                        handYue();
                        continue;
                    case "的":
                        handAuxStructure();
                        continue;
                    case "之":
                        handAuxZhi();
                        continue;
                    case "上":
                        handShangXia();
                        continue;
                    case "下":
                        handShangXia();
                        continue;
                    case "来":
                        handLai();
                        continue;
                }
                if (Current.Content.MaxType == WordType.VerbDirection)
                    handVdir();
                else if (Current.Content.MaxType == WordType.VerbLink)
                    handVerbLink();
                else if (Current.Content.MaxType.IsVerb())
                    handV();
                else if (Current.Content.MaxType.IsAdjective())
                    handAdjective();
                else if (Current.Content.MaxType == WordType.NumberConcrete)
                    handConcreteNumber();
                else if (Current.Content.MaxType.IsProNoun())
                    handPronoun();
                else
                    doNothing();



            }

        }
        /// <summary>
        /// 方
        /// </summary>
        private void handFang()
        {
            if (!checkPosition())
                doNothing();
            else if (Previous.Content.MaxType.IsNumber())
                changeType(WordType.Pronoun);
            else if (Previous.Content.Contains(WordType.NounDirection))
                changeType(WordType.NounPlace);
            else
                doNothing();
        }
        /// <summary>
        /// 约
        /// </summary>
        private void handYue()
        {
            if (!checkPosition())
                doNothing();
            else if (HasNext)
            {
                if (Next.Content.MaxType.IsNumber())
                    changeType(WordType.NumberApproxiateBefore);
                else
                    doNothing();
            }
            else
                doNothing();
        }


        /// <summary>
        /// 处理动词
        /// </summary>
        /// <param name="pos"></param>
        private void handV()
        {
            if (CurrentPos == Vertexes.Count - 2)
            {
                if (Previous.Content.MaxType == WordType.AuxiliaryStructure)
                    changeType(WordType.Noun);
                else
                    doNothing();
            }
            else if (Previous.Content.MaxType == WordType.Classifier)
                changeType(WordType.VerbNoun);
            else if (Next.Content.MaxType == WordType.AuxiliaryStructure) 
                 changeType(WordType.VerbNoun);
            else
                doNothing();
        }
        private void handAuxStructure()
        {
            if (CurrentPos == Vertexes.Count - 2)
            {
                if (Previous.Content.MaxType.IsAdjective())
                    mergeWithBefore(WordType.AdJective);
                else
                    doNothing();
            }
            else
                doNothing();
        }
        private void handConcreteNumber()
        {
            if (!checkPosition())
                doNothing();
            /********************
             * 上下第 前后 左右 
             * *************************/
            else if (Previous.Content.Contains(WordType.NumOrder))
                changePreviousType(WordType.NumOrder);
            else if (Previous.Content.Contains(WordType.NounDirection))
                changePreviousType(WordType.NumOrder);
            /*******************
             * 量词
             * ********************/
            else if (Next.Content.Contains(WordType.Classifier))
                changeNextType(WordType.Classifier);
            /**************
             * 几
             * **********************/
            else if (Previous.Content.Contains(WordType.NumberApproxiate))
                changePreviousType(WordType.NumberApproxiate);
            else if (Next.Content.Contains(WordType.NumberApproxiate))
                changeNextType(WordType.NumberApproxiate);
            else
                doNothing();
        }


        private void handVerbLink()
        {
            /*******************
            * 胜利 是
            * ***************************/
            if (Previous.Content.MaxType.IsVerb() && !Previous.Content.MaxType.IsSituationism())
                changePreviousType(WordType.Noun);
            /*******************
            * 胜利 是
            * ***************************/
            else if ((Previous.Content.MaxType.IsAdjective() || Previous.Content.MaxType.IsAdverb()) && !BeforeHas(x => x.IsVerb()))
                changePreviousType(WordType.Noun);
            else
                doNothing();
        }
        private bool handClassifier()
        {
            if (Current.Content.Contains(WordType.Classifier))
            {
                if (Previous.Content.MaxType == WordType.NumberConcrete)
                {
                    changeType(WordType.Classifier);
                    return true;
                }
                else if (Previous.Content.MaxType.IsProNoun())
                {
                    changeType(WordType.Classifier);
                    return true;
                }
                return false;
            }
            return false;
        }
        private void handAdjective()
        {
            /**************************
             * 颜色
             * *****************************/
            if (Current.Content.MaxType == WordType.AdjectiveColor)
            {
                if (Previous.Content.MaxType.IsNoun())
                    changeType(WordType.NounColor);
                else
                    doNothing();
            }
            /***********************
             * 数量
             * *************************************/
            else if (Current.Content.MaxType == WordType.AdjectiveNumber)
            {
                if (Next.Content.Contains(WordType.Classifier))
                    changeNextType(WordType.Classifier);
                else
                    doNothing();
            }
            /*******************
             * 两个连续的形容词
             * *********************/
            else if (Previous.Content.MaxType.IsAdjective())
            {
                if (Current.Content.ContainsNoun())
                    changeNextType(WordType.Noun);
                /*************************
                * 原 主
                * ***********************/
                else if (Current.Content.ContainsPronoun())
                    changeType(WordType.Pronoun);
                else
                    doNothing();
            }
            else if (Previous.Content.MaxType.IsVerb() && Next.Content.MaxType.IsVerb())
                changeNextType(WordType.VerbNoun);
            else
                doNothing();

        }

        private void handPronoun()
        {
            if (Next.Content.Contains(WordType.Classifier))
                changeNextType(WordType.Classifier);
            else
                doNothing();
        }

        private void handNoun()
        {


        }
    }


}
