/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.ClientService
*文件名称   ：SocketManager.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/21 星期五 16:06:39 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/21 星期五 16:06:39 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using Common.JsonEx;
using JSound.Models;
using SocketHeartEx.DotnetSocket;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;

namespace JSound.ClientService
{
    public class SocketManager
    {
        /*-------------------------------------- Fields ----------------------------------------*/
        private static DotnetSocketClient client;
        public DispatcherTimer hearttimer;
        public DispatcherTimer tcmdtimer;

        private ObservableCollection<TransferCmd> transferCmds = new ObservableCollection<TransferCmd>();

        /*-------------------------------------Properties --------------------------------------*/

        public string devKey { get; set; }
        public static JSoundClientCmd clientCmd { get; set; }

        public string host { get; set; }
        public int port { get; set; }

        public event ReceiveDataDelegate ReceviceDataHandler;
        public delegate void ReceiveDataDelegate(object sender, EventArgs e);

        /*----------------------------------- Constructors -------------------------------------*/
        public SocketManager(SystemInfo iService)
        {
            this.dataService = iService;
        }

        private SystemInfo dataService;

        /*---------------------------------- Public Methods ------------------------------------*/

        // 开始连接
        public void ConntectSrv(string host, int p, string dk)
        {
            this.host = host;
            this.port = p;

            ConntectSrv();
        }
        public void ConntectSrv()
        {
            clientCmd = JSoundClientCmd.GetAllInfo;
            devKey = "0000";
            //新建一个连接
            if (client == null)
                client = new DotnetSocketClient();
            else if (client.Connected == true)
                return;
            client.ConnToServer(RevMsg, this.host, this.port);
            Thread.Sleep(500);
            //var json = JsonExtendFun.ReadJsonFile(path);
            //SendCmd(JSoundClientCmd.GetAllInfo, "");

            //获取播放器信息
            tcmdtimer = new DispatcherTimer();
            tcmdtimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            tcmdtimer.Tick += TCmdTimer_Tick;
            tcmdtimer.Start();

            //发送命令定时器
            hearttimer = new DispatcherTimer();
            hearttimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            hearttimer.Tick += HeartTimer_Tick;
        }

        // 关闭连接
        public void SrvClose()
        {
            client.Close();
            System.Environment.Exit(0);
        }

        // 接收事件
        private void RevMsg(object obj)
        {
            var str = obj as string;

            if (this.ReceviceDataHandler != null && str != string.Empty)
                this.ReceviceDataHandler(obj, new EventArgs());
        }

        // 发送操作命令
        public void SendCmd<T>(JSoundClientCmd cmd, T obj)
        {
            TransferCmd tcmd = new TransferCmd()
            {
                devkey = devKey,
                funtion = (int)cmd,
                datas = obj != null ? JsonExtendFun.CoverseJsonString(obj) : string.Empty
            };

            try
            {
                var nid = ViewModelHelper.GetPropertyValue(obj, "id");
                var ncmd = ViewModelHelper.GetPropertyValue(obj, "cmd");

                if (nid == null || ncmd == null)
                    return;
                List<TransferCmd> tempitem = new List<TransferCmd>();
                tempitem.AddRange(transferCmds);

                foreach (var item in transferCmds)
                {

                    var _obj = JsonExtendFun.CoverseJsonObject<T>(item.datas);

                    var oid = ViewModelHelper.GetPropertyValue(_obj, "id");

                    var ocmd = ViewModelHelper.GetPropertyValue(_obj, "cmd");



                    if (oid.Equals(nid) && ocmd.Equals(ncmd))
                    {
                        tempitem.Remove(item);
                    }
                }
                transferCmds = new ObservableCollection<TransferCmd>(tempitem);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            transferCmds.Add(tcmd);
        }

        // 发送查询命令
        private void Send(TransferCmd tcmd)
        {
            if (client != null && client.Connected)
                client.Send(JsonExtendFun.CoverseJsonString<TransferCmd>(tcmd));
        }


        #region 定时器

        // 心跳包线程
        public void HeartTimer_Tick(object sender, EventArgs e)
        {
            JSoundClientCmd jcCmd;
            if (dataService.id == string.Empty)
                jcCmd = JSoundClientCmd.GetAllInfo;
            else
                jcCmd = JSoundClientCmd.GetPlayerMessage;

            TransferCmd tcmd = new TransferCmd
            {
                devkey = "0000",
                funtion = (int)jcCmd,
                datas = ""
            };

            GC.Collect();
            Send(tcmd);
        }

        // 发送代码线程
        public void TCmdTimer_Tick(object sender, EventArgs e)
        {
            if (transferCmds.Count() > 0)
            {
                hearttimer.Stop();

                Console.WriteLine("-------------------");
                foreach (var item in transferCmds)
                {
                    Console.WriteLine("SendData:" + item.datas);
                }

                //JsonExtendFun.CoverseJsonObject<>(transferCmds[0].datas);
                Send(transferCmds[0]);
                transferCmds.RemoveAt(0);

            }
            else
            {
                hearttimer.Start();
            }

        }

        #endregion

        /*---------------------------------- Private Method ------------------------------------*/

    }
    /// <summary>
    /// 通讯传输类
    /// </summary>
    public class TransferCmd
    {
        public string devkey { get; set; }
        public int funtion { get; set; }
        public string datas { get; set; }
    }
}
