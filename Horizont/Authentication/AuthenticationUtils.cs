using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizont.Connection;

namespace Horizont.Authentication
{
    public class AuthenticationUtils
    {
        public static byte[] Encrypt(byte[] data, string password)
        {
            //ICryptoTransform encryptor = Rijndael.Create().CreateEncryptor(new PasswordDeriveBytes(password, (byte[])null).GetBytes(16), new byte[16]);
            MemoryStream memoryStream = new MemoryStream();
            //CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            //cryptoStream.Write(data, 0, data.Length);
            //cryptoStream.FlushFinalBlock();
            return memoryStream.ToArray();
        }

        public static string Encrypt(string data, string password)
        {
            if (!string.IsNullOrEmpty(data))
                return Convert.ToBase64String(AuthenticationUtils.Encrypt(Encoding.UTF8.GetBytes(data), password));
            return (string)null;
        }

       /* public static byte[] Decrypt(byte[] data, string password)
        {
            return new BinaryReader((Stream)AuthenticationUtils.InternalDecrypt(data, password)).ReadBytes(data.Length);
        }*/

       /* public static string Decrypt(string data, string password)
        {
            if (!string.IsNullOrEmpty(data))
                return new StreamReader((Stream)AuthenticationUtils.InternalDecrypt(Convert.FromBase64String(data), password)).ReadToEnd();
            return (string)null;
        }*/

       /* private static CryptoStream InternalDecrypt(byte[] data, string password)
        {
            ICryptoTransform decryptor = Rijndael.Create().CreateDecryptor(new PasswordDeriveBytes(password, (byte[])null).GetBytes(16), new byte[16]);
            return new CryptoStream((Stream)new MemoryStream(data), decryptor, CryptoStreamMode.Read);
        }*/
    }

    public class AuthenticationService
    {
        public bool ValidateUser(string login, string password)
        {
            using (Connection.ApplicationContext db = new Connection.ApplicationContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Name == login);
                if (user == null) return false;

               /* if (AuthenticationUtils.Decrypt(user.Hash, user.Name) == password)
                {
                    return true;
                }*/
            }

            return false;
        }

        public bool CreateUser(string login, string password)
        {
            using (Connection.ApplicationContext db = new Connection.ApplicationContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Name == login);
                if (user != null) return false;

               /* if (AuthenticationUtils.Decrypt(user.Hash, user.Name) == password)
                {
                    return true;
                }*/
            }

            return false;
        }
    }
}
