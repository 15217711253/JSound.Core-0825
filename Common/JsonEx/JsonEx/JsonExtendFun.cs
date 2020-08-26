using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.JsonEx
{
    public class JsonExtendFun
    {
        /// <summary>
        /// 序列化Josn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string CoverseJsonString<T>(T t)
        {
            //序列化
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            MemoryStream msObj = new MemoryStream();
            //将序列化之后的Json格式数据写入流中


            js.WriteObject(msObj, t);
            msObj.Position = 0;
            //从0这个位置开始读取流中的数据
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string json = sr.ReadToEnd();
            sr.Close();
            msObj.Close();

            return json;
        }

        /// <summary>
        /// 反序列化Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T CoverseJsonObject<T>(string json)
        {
            try
            {
                //反序列化
                string toDes = json;



                //string to = "{\"ID\":\"1\",\"Name\":\"曹操\",\"Sex\":\"男\",\"Age\":\"1230\"}";
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
                {
                    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(T));
                    T model = (T)deseralizer.ReadObject(ms);// //反序列化ReadObject
                    return model;
                }
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                Console.WriteLine(e.ToString());
                return default;
            }
            
        }

        public static string ReadJsonFile(string path1)
        {
            try
            {
                //System.IO.Directory.GetCurrentDirectory() + 
                string path = path1;
                StreamReader streamReader = new StreamReader(path);
                string jsonStr = streamReader.ReadToEnd();
                return jsonStr;

                //string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                //File.WriteAllText(path, output);

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message + "/r/n" + e.StackTrace);
                return "";
            }
        }


        public static void WriteJsonFile(string path,string jsonstr)
        {
            try
            {
                var dir = path.Substring(0, path.LastIndexOf("\\")) + "\\";
                if (File.Exists(path) == false)
                {
                    Directory.CreateDirectory(dir);
                }
                File.WriteAllText(path, jsonstr);


            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message + "/r/n" + e.StackTrace);
                return;
            }
        }
    }
}
