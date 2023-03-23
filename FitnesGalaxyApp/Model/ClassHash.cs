using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FitnesGalaxyApp.Model
{
   public class ClassHash
    {
        public ClassHash() { }
        public string GetHash(string stringhash)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(stringhash));

            return Convert.ToBase64String(hash);
        }
    }
}
