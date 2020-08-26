/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.ViewModels.Providers
*文件名称   ：AnsycProvider.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/24 星期一 14:59:22 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/24 星期一 14:59:22 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSound.ViewModels.Providers
{
    public class AsyncProvider
    {

        public static async void RunAsync(Action function, Action callback)
        {
            Func<Task> taskFunc = () =>
            {
                return Task.Run(function);
            };
            await taskFunc();
            callback?.Invoke();
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="function">异步方法，该方法没有参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        public static async void RunAsync<TResult>(Func<TResult> function, Action<TResult> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(function);
            };
            //function的返回值作为callback的参数
            TResult rlt = await taskFunc();
            callback?.Invoke(rlt);
        }
    }

}
