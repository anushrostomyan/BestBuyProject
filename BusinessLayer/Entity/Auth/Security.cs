using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Entity.Auth
{
    public class Security
    {
        public string CalculateMD5Hash(string passowrd)
        {
            try
            {
                StringBuilder sb = null;
                // step 1, calculate MD5 hash from input
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.ASCII.GetBytes(passowrd);

                    byte[] hash = md5.ComputeHash(inputBytes);
                    // step 2, convert byte array to hex string
                    sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }

                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
