using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManager.MyClass
{
    public class RandomKey
    {
        public static string CreateRandomKey(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }
    }
}