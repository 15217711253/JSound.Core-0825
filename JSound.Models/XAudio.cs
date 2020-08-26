using Common.FileEx;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using WMPLib;

namespace JSound.Models
{
    [DataContract]
    public class XAudio : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public XAudio()
        {
        }
        public XAudio(string path)
        {
            this.id = Guid.NewGuid().ToString("N");
            InitMedia(path);
        }

        private void InitMedia(string path)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            this.Media = wmp.newMedia(path);

            this.name = Media.name;
            this.url = Media.sourceURL;
            this.fullname = FileExtendFun.GetFileFullname(Media.sourceURL);
            this.size = FileExtendFun.GetFileSize(Media.sourceURL);
            this.totaltime = Media.durationString;
        }

        #region 参数
        private IWMPMedia Media;
        private string _id;
        private string _name;
        private string _fullname;
        private string _url;
        private string _size;
        private string _totaltime;

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
        /// 文件名称
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
        [DataMember]
        public string url
        {
            get { return _url; }
            set
            {

                _url = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("url"));
                }

            }
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        [DataMember]
        public string size
        {
            get { return _size; }
            set
            {
                _size = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("size"));
                }

            }
        }

        /// <summary>
        /// 带后缀名全称
        /// </summary>
        /// 
        [DataMember]
        public string fullname
        {
            get { return _fullname; }
            set
            {
                _fullname = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("fullname"));
                }

            }
        }

        /// <summary>
        /// 时长
        /// </summary>
        /// 
        [DataMember]
        public string totaltime
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

        #endregion

        public object Clone()
        {
            return base.MemberwiseClone();
        }


    }

}
