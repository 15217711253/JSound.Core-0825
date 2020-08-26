/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSoundApp.Entities
*文件名称   ：XSoundAd.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/7 星期五 16:04:23 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/7 星期五 16:04:23 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JSound.Models
{
    [DataContract]
    public class XSoundAd : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region 参数

        private string _id;
        private string _cardid;
        private string _panning;
        private string _description;


        /// <summary>
        /// id
        /// </summary>
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
        /// cardid
        /// </summary>
        [DataMember]
        public string cardid
        {
            get { return _cardid; }
            set
            {
                _cardid = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("cardid"));
                }

            }
        }

        /// <summary>
        /// 平衡
        /// </summary>
        [DataMember]
        public string panning
        {
            get { return _panning; }
            set
            {
                _panning = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("panning"));
                }

            }
        }

        /// <summary>
        /// 声卡描述
        /// </summary>
        [DataMember]
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("description"));
                }

            }
        }


        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
