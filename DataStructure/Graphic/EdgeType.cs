using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Chinese.Grammer.Graphic
{
    /// <summary>
    /// 边类型
    /// </summary>
  public  enum EdgeType
    {
        /// <summary>
        /// 核心此为名词
        /// </summary>
        Noun,
        /// <summary>
        /// 核心词为动词
        /// </summary>
        Verb,
        /// <summary>
        /// 核心词为时间
        /// </summary>
        Time,
        /// <summary>
        /// 核心词为地点
        /// </summary>
        Place,
        /// <summary>
        /// 56个民族
        /// </summary>
        Count,
        /// <summary>
        /// 第一次去上海
        /// </summary>
        Order,
        /// <summary>
        /// 和的节点
        /// </summary>
        And,
        /*********************************************************/
        /// <summary>
        /// 购买 力
        /// 选择 性
        /// 流通 业
        /// 监察 机构
        /// 发展 大业
        /// 这类词一般可以合并
        /// </summary>
        VN,





        /// <summary>
        /// 这 个
        /// 那 个
        /// 这 只
        /// 那 些
        /// </summary>
        PNC,


        /// <summary>
        /// 张 学友
        /// </summary>
        NameName,
        /// <summary>
        /// 五朵 花
        /// </summary>
        CN,
        
        /// <summary>
        /// 故乡城市
        /// </summary>
        NN,
       /// <summary>
       /// 这 花
       /// </summary>
       PNN,
        /// <summary>
        /// 我 爸
        /// </summary>
        PNCal,
       
        /// <summary>
        /// 合川 桃片
        /// </summary>
        NameN,



        /// <summary>
        /// 赵薇导演
        /// 主席 习近平
        /// </summary>
        NNameOcupation,

        /// <summary>
        /// 蓝 莲花
        /// </summary>
        AN,

       /// <summary>
       /// 五月 三日
       /// </summary>
        NTT,
        

        /// <summary>
        /// 故事里面
        /// </summary>
        NScope,

        /// <summary>
        /// NdirN
        /// 北京 生活
        /// </summary>
        NplaceN,

        /// <summary>
        /// 四川 省
        /// 西昌 市
        /// </summary>
        NounAdmin,
        /**********************
         * pre
         * ***********************************************/

        /// <summary>
        /// 
        /// </summary>
        PreDuiObjext,


        /***************************
         * 在 明天
         * 在 开会 时
         * 
         * *********************************/
        PreTime,
        /// <summary>
        /// 通过学习获取成功
        /// </summary>
        PreBy,



        
        /***************************************
         * verb
         * ************************************/
         /// <summary>
         /// 有 说
         /// 没 有 做
         /// </summary>
         HaV,
         /// <summary>
         /// 是 去
         /// </summary>
         LinVir,
         /// <summary>
         /// 上 来
         /// </summary>
         VirVir,
         /// <summary>
         /// 来 说
         /// </summary>
         VirV,
         /// <summary>
         /// 和我 说话
         /// </summary>
        VWith,
        /// <summary>
        /// 会 唱歌
        /// </summary>
        VSit,
        /// <summary>
        ///  耐心  等待
        /// </summary>
        AdV,
        /// <summary>
        /// 否定
        /// 不说话
        /// </summary>
        VNot,
        /// <summary>
        /// 肯定说话
        /// </summary>
        VYes,
        /// <summary>
        /// 打 两下
        /// </summary>
        CountVerb,
        
        /***************
         * Adj
         * ************************/
        /// <summary>
        /// 很 好
        /// </summary>
        AdvAdj,
        /// <summary>
        /// 减少 5
        /// </summary>
        VNM,
        /**************
         * number
         * *********************************/
         /// <summary>
         /// 第 一
         /// </summary>
         NmONm,
         /********************
          * 五 次
          * *********************************/
         NumC,
         /// <summary>
         /// 五 月
         /// </summary>
         NMT,
         /// <summary>
         /// 五 人
         /// </summary>
         NMN,
         /// <summary>
         /// 数十个
         /// </summary>
         NmANm,
        None,
        /// <summary>
        /// 猴子们
        /// </summary>
        NmpN,
        /// <summary>
        /// 我们
        /// </summary>
        NmpPn,
        /// <summary>
        /// 水果等食品
        /// </summary>
        NNmd,
    }
}
