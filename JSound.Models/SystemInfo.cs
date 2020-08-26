/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.Models
*文件名称   ：SystemInfo.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/21 星期五 16:10:01 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/21 星期五 16:10:01 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JSound.Models
{
    [DataContract]
    [KnownType(typeof(XRoomPlyer))]
    [KnownType(typeof(XPlayList))]
    [KnownType(typeof(XAudio))]
    [KnownType(typeof(XSoundAd))]
    public class SystemInfo : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SystemInfo()
        {

        }

        #region 参数

        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _usbkey = string.Empty;
        private int _room_limit = 0;
        private string _opentime = string.Empty;
        private string _closetime = string.Empty;

        private ObservableCollection<XPlayList> _playlists = new ObservableCollection<XPlayList>();
        private ObservableCollection<XRoomPlyer> _roomplyers = new ObservableCollection<XRoomPlyer>();
        private ObservableCollection<XAudio> _audios = new ObservableCollection<XAudio>();
        private ObservableCollection<XSoundAd> _soundad = new ObservableCollection<XSoundAd>();

        /// <summary>
        /// 项目ID
        /// </summary>
        /// 
        [DataMember]
        public string id
        {
            get { return _id; }
            set
            {
                _id = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("id"));
                }

            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        [DataMember]
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("name"));
                }

            }
        }
        /// <summary>
        /// 授权KEY
        /// </summary>
        [DataMember]
        public string usbkey
        {
            get { return _usbkey; }
            set
            {
                _usbkey = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("usbkey"));
                }

            }
        }

        /// <summary>
        /// 房间信息
        /// </summary>
        [DataMember]
        public ObservableCollection<XRoomPlyer> roomplyers
        {
            get { return _roomplyers; }
            set
            {
                _roomplyers = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("roomplyers"));
                }

            }
        }
        [DataMember]
        public ObservableCollection<XPlayList> playlists
        {
            get { return _playlists; }
            set
            {
                _playlists = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("playlists"));
                }

            }
        }

        [DataMember]
        public ObservableCollection<XAudio> audios
        {
            get { return _audios; }
            set
            {
                _audios = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("audios"));
                }

            }
        }



        /// <summary>
        /// 播放器数量限制
        /// </summary>
        [DataMember]
        public int room_limit
        {
            get { return _room_limit; }
            set
            {
                _room_limit = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("room_limit"));
                }

            }
        }


        /// <summary>
        /// 开机时间
        /// </summary>
        [DataMember]
        public string opentime
        {
            get { return _opentime; }
            set
            {
                _opentime = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("opentime"));
                }

            }
        }

        /// <summary>
        /// 关机时间
        /// </summary>
        [DataMember]
        public string closetime
        {
            get { return _closetime; }
            set
            {
                _closetime = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("closetime"));
                }

            }
        }

        /// <summary>
        /// 声卡
        /// </summary>
        [DataMember]
        public ObservableCollection<XSoundAd> soundad
        {
            get { return _soundad; }
            set
            {
                _soundad = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("soundad"));
                }

            }
        }


        #endregion

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return base.MemberwiseClone();
        }



    }
}
