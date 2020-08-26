/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.App.Views
*文件名称   ：RoomPlayPlugin.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/24 星期一 1:00:00 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/24 星期一 1:00:00 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using JSound.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace JSound.App.Views
{
    [Export(typeof(IModule))]
    public class HomePlugin : IModule
    {
       
        public int Index => 1;

        public string IconFont => "\ue657";

        public string Name => "主页";

        public UserControl UserInterface => new HomeView();

        public void Deactivate()
        {
            return;
        }
    }
}
