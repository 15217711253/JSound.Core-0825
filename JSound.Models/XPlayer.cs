/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSoundApp.Entities
*文件名称   ：XPlayer.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/7 星期五 15:56:37 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/7 星期五 15:56:37 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace JSound.Models
{
    [DataContract]
    public class XPlayer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region 属性
        private string _id;
        private string _scardid;
        private int _playstate;
        private TimeSpan _currtime;
        private TimeSpan _totaltime;
        private float _volume;
        private float[] _meterVolume;
        private string _audioid;
        private string _plid;


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


        [DataMember]
        public string scardid
        {
            get { return _scardid; }
            set
            {
                _scardid = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("scardid"));
                }

            }
        }

        [DataMember]
        public int playstate
        {
            get { return _playstate; }
            set
            {
                _playstate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("playstate"));
                }

            }
        }

        [DataMember]
        public TimeSpan currtime
        {
            get { return _currtime; }
            set
            {
                _currtime = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("currtime"));
                }

            }
        }

        [DataMember]
        public TimeSpan totaltime
        {
            get { return _totaltime; }
            set
            {
                _totaltime = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("totaltime"));
                }

            }
        }

        [DataMember]
        public float volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("volume"));
                }

            }
        }

        [DataMember]
        public float[] meterVolume
        {
            get { return _meterVolume; }
            set
            {
                _meterVolume = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("meterVolume"));
                }

            }
        }

        [DataMember]
        public string plid
        {
            get { return _plid; }
            set
            {
                _plid = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("plid"));
                }

            }
        }

        [DataMember]
        public string audioid
        {
            get { return _audioid; }
            set
            {
                _audioid = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("audioid"));
                }

            }
        }


        #endregion
    }
}
