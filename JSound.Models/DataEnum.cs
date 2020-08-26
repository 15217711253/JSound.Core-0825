/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.Models
*文件名称   ：DataEnum.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/21 星期五 16:12:44 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/21 星期五 16:12:44 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSound.Models
{
    /// <summary>
    /// 服务器发送命令
    /// </summary>
    public enum JSoundServerCmd
    {
        SystemInfo = 1,
        PlayerMessage = 2
    }

    /// <summary>
    /// 客户端发送命令
    /// </summary>
    public enum JSoundClientCmd
    {
        GetAllInfo = 1,
        GetPlayerMessage = 2,
        CtrlPlyer = 10
    }

    public class PlayerCtrlCmd
    {
        public PlayerCtrlCmd()
        {
        }

        public string id { get; set; }
        public EnumPlyerCmd cmd { get; set; }

        public string data { get; set; }
    }


    public enum EnumPlyerCmd
    {
        Play = 1,
        Pause = 2,
        Stop = 3,
        //----------//
        SetCurrTime = 11,
        SetVol = 12
    }
}
