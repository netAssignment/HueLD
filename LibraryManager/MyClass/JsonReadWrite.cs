using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LibraryManager.MyClass
{
    public class JsonReadWrite <T>
    {
        #region Quản lý ý kiến khách hàng về sản phẩm
        public void ObjectToJsonFile(string FileName, List<T> list,string path)
        {
            StreamWriter str = null;
            if (FileName != null && FileName != "")
            {
                try
                {
                    string fileName = FileName + ".txt";//Lay ten san pham la ten file
                    string pathF = System.IO.Path.Combine(path, fileName);//tim duong dan toi thu muc chua project
                    //List<T> list = danhsach.LayDSYKienTheoIdSP(sanPhamId);
                    str = new StreamWriter(pathF, true);//cho phep ghi tiep vao file da co san, neu file ko ton tai thi tao file moi
                    string str1;
                    foreach (T item in list)
                    {
                        str1 = JsonConvert.SerializeObject(item);
                        str.WriteLine(str1);
                    }
                    str.Close();
                }
                catch
                {
                    try
                    {
                        if (str != null)
                            str.Close();
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }
        public List<T> JsonFileToObject(string FileName, string path,int numRow)
        {
            StreamReader reader = null;
            List<T> list = new List<T>();
            try
            {
                string fileName = FileName + ".txt";
                string pathF = System.IO.Path.Combine(path, fileName);

                if (numRow > 1)
                {
                    int start = 1;
                    int end = numRow;

                    reader = new StreamReader(pathF);
                    List<string> lines = System.IO.File.ReadLines(pathF).Skip(start - 1).Take(end - start + 1).ToList();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        list.Add(JsonConvert.DeserializeObject<T>(lines[i]));
                    }
                    reader.Close();
                }
                else
                    throw new Exception("numRow must higher than 1");
            }
            catch
            {
                try
                {
                    if (reader != null)
                        reader.Close();
                }
                catch
                {
                    return list;
                }
            }
            return list;
        }
        public List<T> JsonFileToObject(string FileName, string path)
        {
            StreamReader reader = null;
            List<T> list = new List<T>();
            try
            {
                string fileName = FileName + ".txt";
                string pathF = System.IO.Path.Combine(path, fileName);
                reader = new StreamReader(pathF);
                string json = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<T>>(json);
                reader.Close();
            }
            catch
            {
                try
                {
                    if (reader != null)
                        reader.Close();
                }
                catch
                {
                    return list;
                }
            }
            return list;
        }
        #endregion
    }
}