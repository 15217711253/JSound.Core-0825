using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using JSound.ClientService;
using JSound.ViewModels.Providers;
using System;
using System.Collections.ObjectModel;

namespace JSound.ViewModels
{
    public class RoomPlayerViewModel : ViewModelBase, IDisposable
    {
        /*-------------------------------------- Fields ----------------------------------------*/

        private SocketManager socketManager;

        private ObservableCollection<RoomPlayerItemViewModel> roomPlayerVM
            = new ObservableCollection<RoomPlayerItemViewModel>();
        private RoomPlayerItemViewModel _SelectedPlayer;

        private RelayCommand<object> _RoomItemSelectedCommand;
        /*-------------------------------------Properties --------------------------------------*/

        public ObservableCollection<RoomPlayerItemViewModel> RoomPlayerVM
        {
            get { return roomPlayerVM; }
            set
            {
                roomPlayerVM = value;
                this.RaisePropertyChanged("RoomPlayerVM");
            }
        }

        /*----------------------------------- Constructors -------------------------------------*/

        public RoomPlayerViewModel()
        {
            try
            {
          

                AsyncProvider.RunAsync(GetIoCSocketManager,null);


            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }

        private void GetIoCSocketManager()
        {
            socketManager = SimpleIoc.Default.GetInstance<SocketManager>();
            socketManager.ReceviceDataHandler += Socket_ReceviceDataHandler;
        }





        /*---------------------------------- Public Methods ------------------------------------*/



        public RoomPlayerItemViewModel SelectedPlayer
        {
            get { return _SelectedPlayer; }
            set { Set(ref _SelectedPlayer, value); }
        }





        /// <summary>
        /// Gets the RoomItemSelectedCommand.
        /// </summary>
        public RelayCommand<object> RoomItemSelectedCommand
        {
            get
            {
                return _RoomItemSelectedCommand
                    ?? (_RoomItemSelectedCommand = new RelayCommand<object>(
                    p =>
                    {
                        //TODO 01:选中播放器
                        SelectedPlayer = p as RoomPlayerItemViewModel;
                        //MainViewModel.GetInstance.SelectedRoomPlayer = SelectedPlayer;

                    }));
            }
        }
        /*---------------------------------- Private Method ------------------------------------*/
        private void Socket_ReceviceDataHandler(object sender, EventArgs e)
        {
            try
            {
                RoomPlayerVM = SimpleIoc.Default.GetInstance<
                    ObservableCollection<RoomPlayerItemViewModel>>();


                Console.WriteLine($"RoomPlayer Count ：{roomPlayerVM.Count}"); //播放器数量 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;

            }
        }

        public void Dispose()
        {
            return;
        }
    }
}