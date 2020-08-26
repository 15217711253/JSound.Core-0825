using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace Common.FileEx
{
    public class FileExtendFun
    {
        /// <summary>
        /// 打开文件夹并选中
        /// </summary>
        public static void OpenLocalDirAndSelect(string fileName)
        {
            if (File.Exists(fileName))
            {
                Process.Start("explorer", "/select,\"" + fileName + "\"");
            }
        }

        /// <summary>
        /// 获取所有后缀名为xxx的文件
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="lastString"></param>
        /// <returns></returns>
        public static ObservableCollection<string> GetFiles(string dir, string lastString)
        {
            ObservableCollection<string> alst = new ObservableCollection<string>();
            try
            {
                string[] files = Directory.GetFiles(dir);//得到文件
                foreach (string file in files)//循环文件
                {
                    string exname = file.Substring(file.LastIndexOf(".") + 1);//得到后缀名
                    if (lastString.IndexOf(file.Substring(file.LastIndexOf(".") + 1)) > -1)//查找.txt .aspx结尾的文件
                    //if (".mp3|.wav".IndexOf(file.Substring(file.LastIndexOf(".") + 1)) > -1)//如果后缀名为.txt文件
                    {
                        FileInfo fi = new FileInfo(file);//建立FileInfo对象

                        alst.Add(fi.FullName);//把.txt文件全名加人到FileInfo对象
                    }
                }

                return alst;
            }
            catch
            {
                return null;
            }
        }

        public static string GetFileFullname(string file)
        {
            FileInfo fi = new FileInfo(file);
            return fi.Name;
        }


        public static string GetFileSize(string filepath)
        {
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filepath);
                if (fileInfo != null && fileInfo.Exists)
                {
                    return System.Math.Ceiling(fileInfo.Length / 1024.0) + " KB";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return String.Empty;
                // 其他处理异常的代码
            }
            return string.Empty;
        }
        public static void OpenFile()
        { 

        }
    }
}