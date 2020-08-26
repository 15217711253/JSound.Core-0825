using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JSound.ClientService;
using JSound.Models;
using JSound.ViewModels.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSound.ViewModels
{
    public class AudioListViewModel : ViewModelBase, IDisposable
    {

        public AudioListViewModel()
        {
            try
            {
                var SystemInfo = SimpleIoc.Default.GetInstance<
                    SystemInfo>();
                Audios = new ObservableCollection<AudioItemViewModel>();
                foreach (var item in SystemInfo.audios)
                {
                    Audios.Add(new AudioItemViewModel(item));
                }


                Console.WriteLine($"RoomPlayer Count ：{Audios.Count}"); //播放器数量 
                //AsyncProvider.RunAsync(GetIoCSocketManager, null); 
                //ObservableCollection异步报错  ：
                //不支持从调度程序线程以外的线程对其 SourceCollection 进行的更改
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }


        private SocketManager socketManager;

        private ObservableCollection<AudioItemViewModel> _audios = new ObservableCollection<AudioItemViewModel>();

        public ObservableCollection<AudioItemViewModel> Audios
        {
            get { return _audios; }
            set
            {
                _audios = value;
                this.RaisePropertyChanged("Audios");
            }
        }

        //全选按钮
        private bool _isAllItemsSelected=false;
        public bool IsAllItemsSelected
        {
            get { return _isAllItemsSelected; }
            set
            {
                if (_isAllItemsSelected == value) return;

                _isAllItemsSelected = value;

                if (_isAllItemsSelected = true)
                {
                    foreach (var item in Audios)
                    {
                        item.IsSelected = true;
                    };
                }
                else
                {
                    foreach (var item in Audios)
                    {
                        item.IsSelected = false;
                    };
                }

                    this.RaisePropertyChanged("IsAllItemsSelected");
            }
        }


        


        private void GetIoCSocketManager()
        {
            socketManager = SimpleIoc.Default.GetInstance<SocketManager>();
            socketManager.ReceviceDataHandler += Socket_ReceviceDataHandler;
        }
        private void Socket_ReceviceDataHandler(object sender, EventArgs e)
        {
            try
            {
                var SystemInfo = SimpleIoc.Default.GetInstance<
                    SystemInfo>();
                Audios = new ObservableCollection<AudioItemViewModel>();
                foreach (var item in SystemInfo.audios)
                {
                    Audios.Add(new AudioItemViewModel(item));
                }


                Console.WriteLine($"RoomPlayer Count ：{Audios.Count}"); //播放器数量 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;

            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
