using ConsoleApp1.Chinese._Sentence;
using ConsoleApp1.Chinese.WordInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Chinese.Grammer.Graphic;
using Test.Chinese.Grammer.RelationAnalnizer.TypeAnalnizer;
using Test.Chinese.Helpers;

namespace Test.Chinese.Grammer.RelationAnalnizer
{
    /// <summary>
    /// 完成 一些确定的 语法的 分析
    /// 红 苹果  a => n
    /// 很 美    ad=>a
    /// 快 说    ad=>v
    /// 我 爸    pn=>n
    /// 第 五    nmo=> nm 
    /// 五 个    nm =>cla        
    /// </summary>
    public class FirstAnalnizer : BasicAnlnizer
    {
        public override void Analnize(List<Vertex> input)
        {
            Worked = false;
            Reset(input);
            /**************************
             * 按词性 依次分发
             * *******************************/

            while (CurrentPos < Vertexes.Count)
            {

                switch (Current.Content.MaxType.GetBigType())
                {
                    case Fal.Nlp.Chinese.WordType.Verb:
                        VerbAnalnizer.Analnize(Current.Content.MaxType, this);
                        break;
                    case Fal.Nlp.Chinese.WordType.Noun:
                        NounAnalnizer.Analnize(Current.Content.MaxType, this);
                        break;
                    case Fal.Nlp.Chinese.WordType.AdJective:
                        AdjectiveAnalnizer.Analnize(Current.Content.MaxType, this);
                        break;
                    case Fal.Nlp.Chinese.WordType.Conjunction:
                        DoNothing();
                        break;
                    case Fal.Nlp.Chinese.WordType.Adverb:
                        AdverbAnalnizer.Analnize(Current.Content.MaxType, this);
                        break;
                    case Fal.Nlp.Chinese.WordType.Number:
                        NumberAnalizer.Analnize(Current.Content.MaxType, this);
                        break;
                    case Fal.Nlp.Chinese.WordType.Classifier:
                        ClassifierAnalnizer.Analnize((Current.Content.MaxType), this);
                        break;
                    case Fal.Nlp.Chinese.WordType.Pronoun:
                        DoNothing();
                        break;
                    case Fal.Nlp.Chinese.WordType.Preposition:
                        DoNothing();
                        break;
                    case Fal.Nlp.Chinese.WordType.Auxiliary:
                        AuxliaryAnalnizer.Analnize(Current.Content.MaxType, this);
                        break;
                    case Fal.Nlp.Chinese.WordType.Onomatopoetic:
                        DoNothing();
                        break;
                    case Fal.Nlp.Chinese.WordType.Idiom:
                        DoNothing();
                        break;
                    case Fal.Nlp.Chinese.WordType.Abbreviation:
                        DoNothing();
                        break;
                    case Fal.Nlp.Chinese.WordType.Mark:
                        DoNothing();
                        break;
                    case Fal.Nlp.Chinese.WordType.Unknow:
                    default:
                        DoNothing();
                        break;
                }

            }
        }


    }
}
