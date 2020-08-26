using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using JSound.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JSound.App
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //var catalog = new AssemblyCatalog(this.GetType().Assembly);
            //var container = new CompositionContainer(catalog);
            //var modules = container.GetExportedValues<IModule>();
            
            SimpleIoc.Default.Register(GetModules);
        }


        private static List<IModule> Modules = new List<IModule>();
        private  List<IModule> GetModules()
        {
            if (Modules.Count == 0)
            { 
                var catalog = new AssemblyCatalog(this.GetType().Assembly);
                var container = new CompositionContainer(catalog);
                var modules = container.GetExportedValues<IModule>();
                Modules = modules.OrderBy(x=>x.Index).ToList();
            }

           Console.WriteLine("GetModules " + Modules.GetHashCode());
            return Modules;
        }
    }
}
