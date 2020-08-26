
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JSound.ClientService;
using JSound.Models;
using JSound.ViewModels;
using JSound.ViewModels.Providers;
using System;
using System.Collections.ObjectModel;
using System.Net.Sockets;

namespace JSound.ViewModel
{
    
    public class ViewModelLocator
    {
        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            

            SimpleIoc.Default.Register(SocketProvider.GetDataService);  //SystemInfo
            SimpleIoc.Default.Register(SocketProvider.GetSocketManager); //SocketManager
            SimpleIoc.Default.Register(GetPlayerItemViewModels);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<RoomPlayerViewModel>(); //RoomplayerViewModel
            SimpleIoc.Default.Register<AudioListViewModel>();  //“Ù∆µ
        }

        private ObservableCollection<RoomPlayerItemViewModel> roomPlayerItems;
        private ObservableCollection<RoomPlayerItemViewModel> GetPlayerItemViewModels()
        {
            if (roomPlayerItems == null)
            {
                roomPlayerItems = new ObservableCollection<RoomPlayerItemViewModel>();
            }
            return roomPlayerItems;
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

         public RoomPlayerViewModel RoomPlayer
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RoomPlayerViewModel>();
            }
        }

        public AudioListViewModel AudioList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AudioListViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}