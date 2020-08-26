/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JSound.ClientService
*文件名称   ：ViewModelHelper.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/8/21 星期五 16:13:56 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/8/21 星期五 16:13:56 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JSound.ClientService
{
    public class ViewModelHelper
    {

        /// <summary>
        /// 类赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model1"></param>
        /// <param name="model2"></param>
        public static void BindModelValue<T>(ref T model1, T model2)
        {
            Type t1 = model1.GetType();
            Type t2 = model2.GetType();

            if (t1 != t2) return;

            PropertyInfo[] property2 = t2.GetProperties();
            //排除主键
            List<string> exclude = new List<string>() { "Id" };
            foreach (PropertyInfo p in property2)
            {
                if (exclude.Contains(p.Name)) { continue; }
                t1.GetProperty(p.Name)?.SetValue(model1, p.GetValue(model2, null));
            }
        }

        /// <summary>
        /// 将models数据赋值到 Viewmodels数据源
        /// </summary>
        /// <typeparam name="VM">Viewmodel</typeparam>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="vm_list">Viewmodel List</param>
        /// <param name="model_list">New Model List </param>
        /// <param name="sourceName">数据源的名称</param>
        /// <param name="indexName">id</param>
        public static IList<VM> SetModelListToSourceVm<VM, T>(
          IList<VM> vm_list, IList<T> model_list, string sourceName, string indexName) where VM : new()
        {
            VM FindItem;
            List<VM> RemoveItems = new List<VM>();
            List<VM> tempVm = new List<VM>();
            RemoveItems.AddRange(vm_list);
            tempVm.AddRange(vm_list);

            foreach (var model in model_list)
            {
                FindItem = (VM)GetModelValueFromList<VM, T>(vm_list, model, sourceName, indexName);

                if (FindItem != null)
                {
                    //修改内容
                    var FindItemSource = (T)GetPropertyValue(FindItem, sourceName);
                    BindModelValue(ref FindItemSource, model);


                    //记录需要删除的项

                    foreach (var i in RemoveItems)
                    {
                        if (i.GetType()
                            .GetProperty(sourceName)
                            .GetValue(i)
                            .Equals(FindItemSource)
                            )
                        {
                            tempVm.Remove(i);
                        }
                    }
                    RemoveItems.Clear();
                    RemoveItems.AddRange(tempVm);
                }
                else
                {

                    try
                    {
                        VM viewmoel = new VM();
                        viewmoel.GetType().GetProperty(sourceName).SetValue(viewmoel, model);
                        vm_list.Add(viewmoel);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.ToString());
                        continue;
                    }
                }
            }

            foreach (var vm in RemoveItems)
                vm_list.Remove(vm);

            return vm_list;
        }

        /// <summary>
        /// 在列表中按属性值查找对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="model"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetModelValueFromList<T>(IList<T> list, T model, string propertyName)
        {
            var newValue = GetPropertyValue(model, propertyName);
            foreach (var item in list)
            {
                var propertyValue = GetPropertyValue(item, propertyName);

                if (propertyValue.Equals(newValue))
                    return item;
            }
            return null;
        }

        /// <summary>
        /// 在Viewmodel列表中按数据源属性值查找对象
        /// </summary>
        /// <typeparam name="VM"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="model"></param>
        /// <param name="sourceName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetModelValueFromList<VM, T>(IList<VM> list, T model, string sourceName, string propertyName)
        {
            var newvalue = GetPropertyValue(model, propertyName);
            foreach (var item in list)
            {
                var source = GetPropertyValue(item, sourceName);
                var propertyValue = GetPropertyValue(source, propertyName);

                if (propertyValue.Equals(newvalue))
                    return item;
            }
            return null;
        }


        /// <summary>
        /// 根据对象属性名，返回属性值
        /// </summary>
        /// <param name="obj">查找对象</param>
        /// <param name="proname">要查找的属性</param>
        /// <returns></returns>
        public static object GetPropertyValue(object obj, string proname)
        {
            try
            {
                var result = obj.GetType().GetProperty(proname).GetValue(obj);
                return result;
            }
            catch (System.NullReferenceException ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
        }

    }
}
