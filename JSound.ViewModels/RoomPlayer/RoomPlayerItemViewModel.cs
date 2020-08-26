/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.ViewModels.RoomPlayer
*文件名称   ：RoomPlayerItemViewModel.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/23 星期日 3:46:23 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/23 星期日 3:46:23 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using JSound.ClientService;
using JSound.Models;
using JSound.ViewModels.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JSound.ViewModels
{
    public class RoomPlayerItemViewModel : ViewModelBase,IDisposable
    { /*-------------------------------------- Fields ----------------------------------------*/
        private XRoomPlyer _source;
        private int _volume = 0;
        private bool _PlayStatue = false;
        private readonly SocketManager socketManager = null;

        private RelayCommand _PlayCommand;
        /*-------------------------------------Properties --------------------------------------*/

        /// <summary>
        /// 数据源
        /// </summary>
        public XRoomPlyer Source
        {
            get
            {
                if (_source != null)
                    if (_source.id == null)
                        Console.WriteLine("id is null");
                return _source;

            }
            set => Set(ref _source, value);
        }



        /// <summary>
        /// 房间信息
        /// </summary>
        public XRoom Room
        {
            get { return Source.xroom; }
        }
        /// <summary>
        /// 播放器信息
        /// </summary>
        public XPlayer Player
        {
            get { return Source.xplayer; }
        }
        /// <summary>
        /// 播放列表
        /// </summary>
        //public XPlayList PlaylistInfo
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<Task<SystemInfo>>()
        //            .Result.playlists
        //            .Where(x => x.id == Source.xplayer.plid)
        //            .First();
        //    }
        //}
        /// <summary>
        /// 控制/反馈播放器音量
        /// </summary>
        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value != _volume)
                {
                    _volume = value;
                    var ctrl_vol = (_volume / 100.0f);

                    CtrlPlayerHelper.RunCmd(socketManager,Source.id, EnumPlyerCmd.SetVol, ctrl_vol);
                    this.RaisePropertyChanged("Volume");
                }
            }
        }


        /// <summary>
        /// 播放状态
        /// </summary>
        public bool PlayStatue
        {
            get => _PlayStatue;
            set => Set(ref _PlayStatue, value);
        }






        /*----------------------------------- Constructors -------------------------------------*/
        public RoomPlayerItemViewModel()
        {
            if (Source == null)
                Source = new XRoomPlyer() { id = string.Empty, xplayer = new XPlayer(), xroom = new XRoom() };

            socketManager = SimpleIoc.Default.GetInstance<SocketManager>();
            socketManager.ReceviceDataHandler += SocketManager_ReceviceDataHandler;
        }
        public RoomPlayerItemViewModel(XRoomPlyer r)
        {

            SetRoomPlayer(r);
        }

        /*---------------------------------- Public Methods ------------------------------------*/

        /// <summary>
        /// Gets the PlayCommand.
        /// </summary>
        public RelayCommand PlayCommand => _PlayCommand
                    ?? (_PlayCommand = new RelayCommand(
                    () =>
                    {
                        var auds = Source.xplayer.audioid;
                        if (Source.id == null)
                            return;
                        //DONE 反馈播放状态
                        if (PlayStatue == true)
                            CtrlPlayerHelper.RunCmd(socketManager, Source.id, EnumPlyerCmd.Stop, "");
                        else
                            CtrlPlayerHelper.RunCmd(socketManager, Source.id, EnumPlyerCmd.Play, "");


                    }));


        /*---------------------------------- Private Method ------------------------------------*/
        private void SocketManager_ReceviceDataHandler(object sender, EventArgs e)
        {
            Volume = (int)(Player.volume * 100.0f);
            this.RaisePropertyChanged("Source");
            this.RaisePropertyChanged("Room");
            this.RaisePropertyChanged("Player");
            PlayStatue = GetPlayerStatue((PlayerStatue)Player.playstate);


            this.RaisePropertyChanged("PlaylistInfo");
        }

        private bool GetPlayerStatue(PlayerStatue statue)
        {
            switch (statue)
            {
                case PlayerStatue.Playing:
                    return true;
                case PlayerStatue.Pause:
                case PlayerStatue.Stop:
                case PlayerStatue.Ready:
                case PlayerStatue.Error:
                    break;
            }
            return false;
        }
        public void SetRoomPlayer(XRoomPlyer r)
        {
            if (Source != r)
                Source = r;
        }

        public void Dispose()
        {
            return;
        }
    }


    public enum PlayerStatue
    {
        Playing = 1,
        Pause = 2,
        Stop = 3,
        Ready = 0,
        Error = -1
    }
}
