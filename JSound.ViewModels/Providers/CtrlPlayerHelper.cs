/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.ClientService
*文件名称   ：CtrlPlayerHelper.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/23 星期日 3:49:28 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/23 星期日 3:49:28 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight.Ioc;
using JSound.ClientService;
using JSound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSound.ViewModels.Providers
{
    public class CtrlPlayerHelper
    {
        /*---------------------------------- Public Methods ------------------------------------*/

        /// <summary>
        /// 远程控制播放器
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="epcmd"></param>
        /// <param name="data"></param>
        public static PlayerCtrlCmd RunCmd(SocketManager sokManager, string pid, EnumPlyerCmd epcmd, object data)
        {
            SocketManager socketManager = SimpleIoc.Default.GetInstance<SocketManager>();
            PlayerCtrlCmd x = new PlayerCtrlCmd
            {
                id = pid,
                cmd = epcmd
            };

            switch (epcmd)
            {
                case EnumPlyerCmd.Play:
                    x.data = "";
                    break;
                case EnumPlyerCmd.Pause:
                    x.data = "";
                    break;
                case EnumPlyerCmd.Stop:
                    x.data = "";
                    break;
                case EnumPlyerCmd.SetCurrTime:
                    x.data = ((TimeSpan)data).ToString();
                    break;
                case EnumPlyerCmd.SetVol:
                    x.data = ((float)data).ToString();
                    break;
                default:
                    break;
            }

            socketManager.SendCmd<PlayerCtrlCmd>(JSoundClientCmd.CtrlPlyer, x);
            return x;
        }
    }
}
