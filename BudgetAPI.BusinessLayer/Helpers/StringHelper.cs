using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.BusinessLayer.Helpers
{
    public static class StringHelper
    {
        private const string prefix = "smartmoney";
        public static string GetHash(string baseString)
        {
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(prefix + baseString)));
        }
    }
}
