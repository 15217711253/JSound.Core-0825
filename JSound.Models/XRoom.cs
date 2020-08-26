/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSoundApp.Entities
*文件名称   ：XRoom.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/7 星期五 15:58:57 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/7 星期五 15:58:57 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System.ComponentModel;
using System.Runtime.Serialization;

namespace JSound.Models
{

    [DataContract]
    public class XRoom : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region 属性
        private string _id;
        private string _name;
        private string _image;

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

        [DataMember]
        public string image
        {
            get { return _image; }
            set
            {
                _image = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("image"));
                }

            }
        }
        #endregion

    }
}
