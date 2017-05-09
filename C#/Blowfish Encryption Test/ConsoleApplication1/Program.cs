using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlowFishCS;
using System.Security.Cryptography;
using System.IO;

namespace ConsoleApplication1
{
    

    class Program
    {
        static PaddingMode[] __paddingmode = { PaddingMode.PKCS7, PaddingMode.ISO10126, PaddingMode.ANSIX923, PaddingMode.Zeros, PaddingMode.None };
        static CipherMode[] __modeofoperation = { CipherMode.CBC, CipherMode.CFB, CipherMode.CTS, CipherMode.ECB, CipherMode.OFB };

        public static byte[] Blowfish_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            passwordBytes = (new SHA384CryptoServiceProvider()).ComputeHash(passwordBytes);

            BlowFish bf = new BlowFish(passwordBytes);
            byte[] bytes;
            bf.IV = IV;

            if (ciMode == 0) bytes = bf.Encrypt_CBC(bytesToBeEncrypted);
            else if (ciMode == 3) bytes = bf.Encrypt_ECB(bytesToBeEncrypted);
            else throw new Exception("1");

            return bytes;
        }
        public static byte[] Blowfish_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            passwordBytes = (new SHA384CryptoServiceProvider()).ComputeHash(passwordBytes);

            BlowFish bf = new BlowFish(passwordBytes);
            byte[] bytes;
            bf.IV = IV;

            if (ciMode == 0) bytes = bf.Decrypt_CBC(bytesToBeDecrypted);
            else if (ciMode == 3) bytes = bf.Decrypt_ECB(bytesToBeDecrypted);
            else throw new Exception("1");

            return bytes;
        }

        public static byte[] DES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            passwordBytes = (new SHA256CryptoServiceProvider()).ComputeHash(passwordBytes);
            Array.Resize(ref passwordBytes, 8);

            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
                {
                    DES.KeySize = 64;
                    DES.BlockSize = 64;

                    DES.Mode = __modeofoperation[ciMode];
                    DES.Padding = __paddingmode[padMode];
                    //TDES.IV = IV;
                    //TDES.Key = passwordBytes;

                    using (var cs = new CryptoStream(ms, DES.CreateEncryptor(passwordBytes, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }
        public static byte[] DES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            passwordBytes =  (new SHA256CryptoServiceProvider()).ComputeHash(passwordBytes);
            Array.Resize(ref passwordBytes, 8);

            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
                {
                    DES.KeySize = 64;
                    DES.BlockSize = 64;

                    DES.Mode = __modeofoperation[ciMode];
                    DES.Padding = __paddingmode[padMode];
                    //TDES.IV = IV;
                    //TDES.Key = passwordBytes;

                    using (var cs = new CryptoStream(ms, DES.CreateDecryptor(passwordBytes, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        static void Main(string[] args)
        {
            string spass = "ha duc viet";
            byte[] pass = Encoding.UTF8.GetBytes(spass);
            pass = (new SHA1CryptoServiceProvider()).ComputeHash(pass);

            Console.WriteLine("{0}", pass.Length);

            string sToBeEncrypted = "123456312";
            byte[] tobeEncrypted = Encoding.UTF8.GetBytes(sToBeEncrypted);

            byte[] IV = Encoding.UTF8.GetBytes("123");
            IV = (new SHA1CryptoServiceProvider()).ComputeHash(IV);
            Array.Resize(ref IV, 8);


            byte[] encrypted = Blowfish_Encrypt(tobeEncrypted, pass, 0, 0, IV);

            byte[] decrypted = Blowfish_Decrypt(encrypted, pass, 0, 0, IV);

            string sDecrypted = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("{0}", sDecrypted);
            
            
        }
    }
}
