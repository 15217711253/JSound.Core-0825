/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSoundApp.Entities
*文件名称   ：XRoomPlyer.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/7 星期五 16:00:09 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/7 星期五 16:00:09 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace JSound.Models
{
    [DataContract]
    public class XRoomPlyer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public XRoomPlyer()
        {
        }

        #region 属性

        private string _id = string.Empty;
        private XRoom _xroom  = new XRoom();
        private XPlayer _xplayer = new XPlayer();

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
        public XRoom xroom
        {
            get { return _xroom; }
            set
            {
                _xroom = value as XRoom;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("xroom"));
                }

            }
        }




        [DataMember]
        public XPlayer xplayer
        {
            get => _xplayer;
            set
            {
                _xplayer = value as XPlayer;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("xplayer"));
                }
            }
        }



        #endregion
    }
}
