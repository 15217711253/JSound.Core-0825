/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSoundApp.Entities
*文件名称   ：XPlaylist.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/7 星期五 10:27:21 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/7 星期五 10:27:21 
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
    public class XPlayList : INotifyPropertyChanged, ICloneable
    {
        #region 参数

        private string _id;
        private string _name;
        private ObservableCollection<string> _audios = new ObservableCollection<string>();

        /// <summary>
        /// id
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
        /// 名称
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
        /// 音频文件
        /// </summary>
        [DataMember]
        public ObservableCollection<string> audios
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

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
