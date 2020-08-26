/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.ViewModels
*文件名称   ：MainViewModel.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/21 星期五 15:56:43 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/21 星期五 15:56:43 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using JSound.ClientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JSound.ViewModels
{
    public class MainViewModel : ViewModelBase,IDisposable
    {
        /*-------------------------------------- Fields ----------------------------------------*/

        private static MainViewModel _Instance = null;
        private static readonly object _Lock = new object();
        private IModule selectedModule;

        private SocketManager socketManager;
        /*-------------------------------------Properties --------------------------------------*/

        public List<IModule> Modules 
        { 
            get=> SimpleIoc.Default.GetInstance<List<IModule>>(); 
        }
        public IModule SelectedModule
        {
            get
            {
                return selectedModule;
            }
            set
            {
                if (value != selectedModule)
                {
                    if (selectedModule != null)
                    {
                        selectedModule.Deactivate();
                    }
                    selectedModule = value;
                    this.RaisePropertyChanged("SelectedModule");
                    this.RaisePropertyChanged("UserInterface");
                }
            }
        }
        public UserControl UserInterface
        {
            get
            {
                if (SelectedModule == null) return null;
                return SelectedModule.UserInterface;
            }
        }
        /*----------------------------------- Constructors -------------------------------------*/
        public MainViewModel()
        {
            try
            {
                if (_Instance != null)
                { 
                    Console.WriteLine($"Instance Code:{_Instance.GetHashCode()}");
                    Console.WriteLine($"Instance Code:{this.GetHashCode()}");
                }
                socketManager = SimpleIoc.Default.GetInstance<SocketManager>();
                _Instance = this;
            }
            catch (System.StackOverflowException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*---------------------------------- Public Methods ------------------------------------*/
        public static MainViewModel GetInstance()
        {
            if (_Instance == null)
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new MainViewModel();
                    }
                }
            }
            return _Instance;
        }

        private RelayCommand<object> _MenuSelectedCommand;

        /// <summary>
        /// Gets the MenuSelectedCommand.
        /// </summary>
        public RelayCommand<object> MenuSelectedCommand
        {
            get
            {
                return _MenuSelectedCommand
                    ?? (_MenuSelectedCommand = new RelayCommand<object>(
                    p =>
                    {
                        this.SelectedModule = this.Modules.Where(
                            x => x.Index == int.Parse(p.ToString()))
                        .First();

                    }));
            }
        }

        public void Dispose()
        {
            return;
        }

        /*---------------------------------- Private Method ------------------------------------*/
    }
}
