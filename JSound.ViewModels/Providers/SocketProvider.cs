/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.ViewModels.Providers
*文件名称   ：SocketRecvicer.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/24 星期一 16:35:07 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/24 星期一 16:35:07 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using Common.JsonEx;
using GalaSoft.MvvmLight.Ioc;
using JSound.ClientService;
using JSound.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

namespace JSound.ViewModels.Providers
{
    public class SocketProvider
    {
        /*-------------------------------------- Fields ----------------------------------------*/

        private static SocketManager socketManager;
        private static SystemInfo _dataService = new SystemInfo();

        /*-------------------------------------Properties --------------------------------------*/

        /*---------------------------------- Public Methods ------------------------------------*/


        public static SystemInfo GetDataService()
        {
            if (_dataService == null)
            {
                _dataService = new SystemInfo();
            }
            return _dataService;
        }
        public static SocketManager GetSocketManager()
        {
            socketManager = new SocketManager(_dataService);
            AsyncProvider.RunAsync<SocketManager>(ConntectSrvAsync, ContectSrvAsyncFinished);
            return socketManager;
        }

        /*---------------------------------- Private Method ------------------------------------*/

        /// <summary>
        /// 开始异步连接服务器
        /// </summary>
        /// <returns></returns>
        private static SocketManager ConntectSrvAsync()
        {
            socketManager.ConntectSrv("127.0.0.1", 5012, "00000");
            return socketManager;
        }
        /// <summary>
        /// 异步连接完成
        /// </summary>
        /// <param name="manager"></param>
        private static void ContectSrvAsyncFinished(SocketManager manager)
        {
            //获取播放器信息
            socketManager.tcmdtimer = new DispatcherTimer();
            socketManager.tcmdtimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            socketManager.tcmdtimer.Tick += socketManager.TCmdTimer_Tick;
            socketManager.tcmdtimer.Start();

            //发送命令定时器
            socketManager.hearttimer = new DispatcherTimer();
            socketManager.hearttimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            socketManager.hearttimer.Tick += socketManager.HeartTimer_Tick;

            socketManager.ReceviceDataHandler += Manager_ReceviceDataHandler;

        }

        /// <summary>
        /// SocketManager 接收事件
        /// </summary>
        /// <param name="obj"></param>
        private static void Manager_ReceviceDataHandler(object sender, EventArgs e)
        {
            var str = sender as string;

            var tcmd = JsonExtendFun.CoverseJsonObject<TransferCmd>(str);

            if (tcmd == null)
                return;

            var fbfun = (JSoundServerCmd)tcmd.funtion;


            switch (fbfun)
            {
                case JSoundServerCmd.SystemInfo:
                    var NewSysValue = JsonExtendFun.CoverseJsonObject<SystemInfo>(tcmd.datas);
                    var SysValue = SimpleIoc.Default.GetInstance<SystemInfo>();
                    ViewModelHelper.BindModelValue(ref SysValue, NewSysValue);
                    break;
                case JSoundServerCmd.PlayerMessage:

                    var NewRPlayers = JsonExtendFun.CoverseJsonObject<ObservableCollection<XRoomPlyer>>(tcmd.datas);
                    var RPlayerViewModels = SimpleIoc.Default.GetInstance<ObservableCollection<RoomPlayerItemViewModel>>();
                    ViewModelHelper.SetModelListToSourceVm(RPlayerViewModels, NewRPlayers, "Source", "id");
                    break;
                default:
                    break;
            }
        }

    }
}
