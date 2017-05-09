using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using System.IO;

namespace DoAnThucHanh
{
    public class CommonFunction
    {
        public string serverKeyToEncryptClientData = "Server/Key4096Data/public_key.hdv";
        public string serverKeyToDecryptClientData = "Server/Key4096Data/private_key.hdv";
        public string serverKeyToSignExportImport = "Server/Key4096ExportImport/private_key.hdv";
        public string serverKeyToCheckExportImport = "Server/Key4096ExportImport/public_key.hdv";
        public string userPath = "Users/";

        public string[] Algorithms = { "AES/Rijndael", "3DES", "DES", "RC2" };
        public string[] PaddingModes = { "PKCS7", "ISO10126", "ANSIX923", "Zeros", "None" };
        public string[] ModeOperations = { "CBC", "OFB", "CFB", "CTS", "ECB" };
        public int MAX_READ_BYTE = 50 * 1024 * 1024; // byte

        public PaddingMode[] __paddingmode = { PaddingMode.PKCS7, PaddingMode.ISO10126, PaddingMode.ANSIX923, PaddingMode.Zeros, PaddingMode.None };
        public CipherMode[] __modeofoperation = { CipherMode.CBC, CipherMode.OFB, CipherMode.CFB, CipherMode.CTS, CipherMode.ECB };
              

        public bool Compare2Array(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            else
            {
                for (int i = 0; i < a.Length; ++i)
                {
                    if (a[i] != b[i]) return false;
                }
                return true;
            }
        }

        public void JoinFile(string[] sourcePath, string destPath)
        {            
            BinaryWriter bw = new BinaryWriter(new FileStream(destPath, FileMode.Create));
            
            for (int i = 0; i < sourcePath.Length; ++i)
            {
                byte[] bFile = System.IO.File.ReadAllBytes(sourcePath[i]);
                bw.Write(bFile.Length);
                bw.Write(bFile);
                //System.IO.File.Delete(sourcePath[i]);
            }
            bw.Close();
        }
        public void JoinFileAndDelete(string[] sourcePath, string destPath)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(destPath, FileMode.Create));

            for (int i = 0; i < sourcePath.Length; ++i)
            {
                byte[] bFile = System.IO.File.ReadAllBytes(sourcePath[i]);
                bw.Write(bFile.Length);
                bw.Write(bFile);
                System.IO.File.Delete(sourcePath[i]);
            }
            bw.Close();
        }

        public void JoinFile_Delete_Encrypt(string[] sourcePath, string destPath)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(destPath, FileMode.Create));

            for (int i = 0; i < sourcePath.Length; ++i)
            {
                byte[] bFile = System.IO.File.ReadAllBytes(sourcePath[i]);
                bw.Write(bFile.Length);
                bw.Write(bFile);
                System.IO.File.Delete(sourcePath[i]);
            }
            bw.Close();

            // Encrypt File .data
            (new EncryptDecrypt()).EncryptFileRSA(destPath, destPath + "en", (new CommonFunction().serverKeyToEncryptClientData));
            // Delete file .data
            System.IO.File.Delete(destPath);
        }

        public void SplitFile(string sourcePath, string[] destPath)
        {
            BinaryReader br = new BinaryReader(new FileStream(sourcePath, FileMode.Open));

            int l;
            long fileLength = br.BaseStream.Length;
            int i = 0;
            do
            {
                l = br.ReadInt32();
                byte[] b = br.ReadBytes(l);
                System.IO.File.WriteAllBytes(destPath[i], b);
                ++i;

                if (br.BaseStream.Position >= fileLength)
                {
                    br.Close();
                    break;
                }
            }
            while (true);
            br.Close();
        }

        public void SplitFileAndDelete(string sourcePath, string[] destPath)
        {
            BinaryReader br = new BinaryReader(new FileStream(sourcePath, FileMode.Open));

            int l;
            long fileLength = br.BaseStream.Length;
            int i = 0;
            do
            {
                l = br.ReadInt32();
                byte[] b = br.ReadBytes(l);
                System.IO.File.WriteAllBytes(destPath[i], b);
                ++i;

                if (br.BaseStream.Position >= fileLength)
                {
                    br.Close();
                    break;
                }
            }
            while (true);
            br.Close();
            System.IO.File.Delete(sourcePath);
        }

        public void SplitFile_Delete_Decrypt(string sourcePath, string[] destPath)
        {
            (new EncryptDecrypt()).DecryptFileRSA(sourcePath + "en", sourcePath, (new CommonFunction()).serverKeyToDecryptClientData);
            System.IO.File.Delete(sourcePath + "en");

            BinaryReader br = new BinaryReader(new FileStream(sourcePath, FileMode.Open));

            int l;
            long fileLength = br.BaseStream.Length;
            int i = 0;
            do
            {
                l = br.ReadInt32();
                byte[] b = br.ReadBytes(l);
                System.IO.File.WriteAllBytes(destPath[i], b);
                ++i;

                if (br.BaseStream.Position >= fileLength)
                {
                    br.Close();
                    break;
                }
            }
            while (true);
            br.Close();
            System.IO.File.Delete(sourcePath);            
        }
    }
    public class HashSalt 
    {
        const int SIZE_SALT = 16;
        public byte[] CreateHashSalt(byte[] data)
        {
            byte[] saltBytes = new byte[SIZE_SALT];
            (new Random()).NextBytes(saltBytes);

            byte[] dataToHash = new byte[2 * SIZE_SALT + data.Length];
            Array.Copy(saltBytes, 0, dataToHash, 0, SIZE_SALT);
            Array.Copy(data, 0, dataToHash, SIZE_SALT, data.Length);
            Array.Copy(saltBytes, 0, dataToHash, SIZE_SALT + data.Length, SIZE_SALT);

            byte[] hash = (new SHA256CryptoServiceProvider()).ComputeHash(dataToHash);

            byte[] ret = new byte[2 * SIZE_SALT + hash.Length];
            Array.Copy(saltBytes, 0, ret, 0, SIZE_SALT);
            Array.Copy(hash, 0, ret, SIZE_SALT, hash.Length);
            Array.Copy(saltBytes, 0, ret, SIZE_SALT + hash.Length, SIZE_SALT);

            return ret;
        }

        public bool CheckHashSalt(byte[] data, byte[] hashsaltdata)
        {
            int lenHash = hashsaltdata.Length - 2 * SIZE_SALT;

            byte[] saltByte1 = new byte[SIZE_SALT];
            byte[] saltByte2 = new byte[SIZE_SALT];
            byte[] hash = new byte[lenHash];

            Array.Copy(hashsaltdata, 0, saltByte1, 0, SIZE_SALT);
            Array.Copy(hashsaltdata, SIZE_SALT, hash, 0, lenHash);
            Array.Copy(hashsaltdata, SIZE_SALT + lenHash, saltByte2, 0, SIZE_SALT);

            byte[] dataToHash = new byte[2 * SIZE_SALT + data.Length];
            Array.Copy(saltByte1, 0, dataToHash, 0, SIZE_SALT);
            Array.Copy(data, 0, dataToHash, SIZE_SALT, data.Length);
            Array.Copy(saltByte2, 0, dataToHash, SIZE_SALT + data.Length, SIZE_SALT);

            if ((new CommonFunction()).Compare2Array(saltByte1, saltByte2))
            {
                if ((new CommonFunction()).Compare2Array(hash, (new SHA256CryptoServiceProvider()).ComputeHash(dataToHash))) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public void CreateFileHashSalt(byte[] data, string path)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create));
            bw.Write(CreateHashSalt(data));
            bw.Close();
        }

        public bool CheckFileHashSalt(byte[] data, string path)
        {
            return CheckHashSalt(data, System.IO.File.ReadAllBytes(path));
        }
    }    
    public class SignatureSalt
    {
        const int SIZE_SALT = 16;

        RSACryptoServiceProvider _RSA;
        public SignatureSalt(RSACryptoServiceProvider RSA)
        {
            _RSA = RSA;
        }

        public byte[] CreateSignatureSalt(byte[] data)
        {
            byte[] saltBytes = new byte[SIZE_SALT];
            (new Random()).NextBytes(saltBytes);

            byte[] dataToSign = new byte[2 * SIZE_SALT + data.Length];
            Array.Copy(saltBytes, 0, dataToSign, 0, SIZE_SALT);
            Array.Copy(data, 0, dataToSign, SIZE_SALT, data.Length);
            Array.Copy(saltBytes, 0, dataToSign, SIZE_SALT + data.Length, SIZE_SALT);

            byte[] signature = _RSA.SignData(dataToSign, new SHA256CryptoServiceProvider());
            
            byte[] ret = new byte[2 * SIZE_SALT + signature.Length];
            Array.Copy(saltBytes, 0, ret, 0, SIZE_SALT);
            Array.Copy(signature, 0, ret, SIZE_SALT, signature.Length);
            Array.Copy(saltBytes, 0, ret, SIZE_SALT + signature.Length, SIZE_SALT);

            return ret;
        }

        public bool CheckSignatureSalt(byte[] data, byte[] signsaltdata)
        {
            int lenSig = signsaltdata.Length - 2 * SIZE_SALT;

            byte[] saltByte1 = new byte[SIZE_SALT];
            byte[] saltByte2 = new byte[SIZE_SALT];
            byte[] signature = new byte[lenSig];

            Array.Copy(signsaltdata, 0, saltByte1, 0, SIZE_SALT);
            Array.Copy(signsaltdata, SIZE_SALT, signature, 0, lenSig);
            Array.Copy(signsaltdata, SIZE_SALT + lenSig, saltByte2, 0, SIZE_SALT);

            byte[] dataToSign = new byte[2 * SIZE_SALT + data.Length];
            Array.Copy(saltByte1, 0, dataToSign, 0, SIZE_SALT);
            Array.Copy(data, 0, dataToSign, SIZE_SALT, data.Length);
            Array.Copy(saltByte2, 0, dataToSign, SIZE_SALT + data.Length, SIZE_SALT);

            if ((new CommonFunction()).Compare2Array(saltByte1, saltByte2))
            {
                if (_RSA.VerifyData(dataToSign, new SHA256CryptoServiceProvider(), signature)) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public void CreateFileSignatureSalt(byte[] data, string path)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create));
            bw.Write(CreateSignatureSalt(data));
            bw.Close();
        }
        
        public bool CheckFileSignatureSalt(byte[] data, string path)
        {
            return CheckSignatureSalt(data, System.IO.File.ReadAllBytes(path));
        }
    }
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string DOB { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int keysize { get; set; }
        public string passphrase { get; set; }
        public string publickey { get; set; }
        public string privatekey { get; set; }
    }  
   
    public class RSA
    {
        private int _keySize;
        private string _publicKey;
        private string _privateKey;

        public string publicKey
        {
            get { return _publicKey; }
        }
        public string privateKey
        {
            get { return _privateKey; }
        }
        public int keySize
        {
            get { return _keySize; }
            set { _keySize = value; }
        }

        public RSA(int keySize)
        {
            _keySize = keySize;
        }
        public void Generate()
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(_keySize);

                _publicKey = rsa.ToXmlString(false);
                _privateKey = rsa.ToXmlString(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }

    public class EncryptDecrypt
    {
        public PaddingMode[] __paddingmode = { PaddingMode.PKCS7, PaddingMode.ISO10126, PaddingMode.ANSIX923, PaddingMode.Zeros, PaddingMode.None };
        public CipherMode[] __modeofoperation = { CipherMode.CBC, CipherMode.OFB, CipherMode.CFB, CipherMode.CTS, CipherMode.ECB };
        const int MAX_READ_BYTE = 50 * 1024 * 1024; // byte

        public byte[] RSA_Encrypt(byte[] data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public byte[] RSA_Decrypt(byte[] data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public byte[] RSA_Encrypt(byte[] data, string XMLpublicKey, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider ersa = new RSACryptoServiceProvider();            
            ersa.FromXmlString(XMLpublicKey);

            return RSA_Encrypt(data, ersa.ExportParameters(false), DoOAEPPadding);
        }

        public byte[] RSA_Decrypt(byte[] data, string XMLprivateKey, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider drsa = new RSACryptoServiceProvider();
            drsa.FromXmlString(XMLprivateKey);

            return RSA_Decrypt(data, drsa.ExportParameters(true), DoOAEPPadding);
        }

        // Encrypt algorithms implementation
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);

                    if (IV == null) AES.IV = key.GetBytes(AES.BlockSize / 8);
                    else AES.IV = IV;
                    AES.Padding = __paddingmode[padMode];
                    AES.Mode = __modeofoperation[ciMode];

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);

                    if (IV == null) AES.IV = key.GetBytes(AES.BlockSize / 8);
                    else AES.IV = IV;
                    AES.Padding = __paddingmode[padMode];
                    AES.Mode = __modeofoperation[ciMode];

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public byte[] TDES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider())
                {
                    TDES.KeySize = 128;
                    TDES.BlockSize = 64;

                    TDES.Mode = __modeofoperation[ciMode];
                    TDES.Padding = __paddingmode[padMode];
                    //TDES.IV = IV;
                    //TDES.Key = passwordBytes;

                    using (var cs = new CryptoStream(ms, TDES.CreateEncryptor(passwordBytes, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        public byte[] TDES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider())
                {
                    TDES.KeySize = 128;
                    TDES.BlockSize = 64;

                    TDES.Mode = __modeofoperation[ciMode];
                    TDES.Padding = __paddingmode[padMode];
                    //TDES.IV = IV;
                    //TDES.Key = passwordBytes;

                    using (var cs = new CryptoStream(ms, TDES.CreateDecryptor(passwordBytes, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        public byte[] DES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
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

        public byte[] DES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
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

        public byte[] RC2_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RC2CryptoServiceProvider RC2 = new RC2CryptoServiceProvider())
                {
                    RC2.KeySize = 128;
                    RC2.BlockSize = 64;

                    RC2.Mode = __modeofoperation[ciMode];
                    RC2.Padding = __paddingmode[padMode];
                    //RC2.IV = IV;
                    //RC2.Key = passwordBytes;

                    using (var cs = new CryptoStream(ms, RC2.CreateEncryptor(passwordBytes, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        public byte[] RC2_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, int padMode, int ciMode, byte[] IV)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RC2CryptoServiceProvider RC2 = new RC2CryptoServiceProvider())
                {
                    RC2.KeySize = 128;
                    RC2.BlockSize = 64;

                    RC2.Mode = __modeofoperation[ciMode];
                    RC2.Padding = __paddingmode[padMode];
                    //RC2.IV = IV;
                    //RC2.Key = passwordBytes;

                    using (var cs = new CryptoStream(ms, RC2.CreateDecryptor(passwordBytes, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        public void EncryptFileSym(string pathInput, string pathOutput, string password, int algo, int padMode, int ciMode)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordHeader = SHA256.Create().ComputeHash(passwordBytes); // Create password hash for encrypt header

            // Hash password for using in multiple algorithm, AES using 32-character password, DES using 8, RC2 and TDES using 16
            if (algo == 0) passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            else if (algo == 1 || algo == 3) passwordBytes = MD5.Create().ComputeHash(passwordBytes);
            else
            {
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                Array.Resize(ref passwordBytes, 8);
            }

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            // Random IV
            byte[] IV = new byte[16];
            (new Random()).NextBytes(IV);

            //// Get byte of Algorithm, padding, cipher mode and IV to encrypt, then save to encrypted file.
            byte[] bAlgo = BitConverter.GetBytes(algo);
            byte[] bPad = BitConverter.GetBytes(padMode);
            byte[] bCi = BitConverter.GetBytes(ciMode);

            // Copy (algo, padMode, ciMode, IV) to header.
            byte[] header = new byte[28];
            System.Buffer.BlockCopy(bAlgo, 0, header, 0, bAlgo.Length);
            System.Buffer.BlockCopy(bPad, 0, header, bAlgo.Length, bPad.Length);
            System.Buffer.BlockCopy(bCi, 0, header, bAlgo.Length + bPad.Length, bCi.Length);
            System.Buffer.BlockCopy(IV, 0, header, bAlgo.Length + bPad.Length + bCi.Length, IV.Length);

            // Create IV for encrypt header
            byte[] headerIV = new byte[16];
            for (int i = 0; i < 16; ++i) headerIV[i] = (byte)((i * i * i + i * i - i) % 256);

            // Encrypt header using AES algorithm.            
            byte[] encryptedHeader;
            try
            {
                encryptedHeader = AES_Encrypt(header, passwordHeader, 1, 2, headerIV);
            }
            catch (Exception ex)
            {
                br.Close(); bw.Close();
                throw ex;
            }

            // Write enrypted header to file.
            bw.Write(encryptedHeader);

            // ===== Encrypt Content of File Process.
            long fileLength = br.BaseStream.Length;
            while (true)
            {
                try
                {
                    byte[] buffer = br.ReadBytes((int)MAX_READ_BYTE);
                    byte[] encryptBuff;

                    if (algo == 0) encryptBuff = AES_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 1) encryptBuff = TDES_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 2) encryptBuff = DES_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else encryptBuff = RC2_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);

                    bw.Write(encryptBuff);
                    if (br.BaseStream.Position >= fileLength)
                    {
                        br.Close(); bw.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    br.Close(); bw.Close();
                    throw ex;
                }
            }
        }

        // Encrypt File and Decrypt File
        public void DecryptFileSym(string pathInput, string pathOutput, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordHeader = SHA256.Create().ComputeHash(passwordBytes); // Create password hash for decrypt header

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));


            // Read encrypted header
            byte[] encryptedHeader = new byte[32];
            br.Read(encryptedHeader, 0, encryptedHeader.Length);

            // Create IV for decrypt header
            byte[] headerIV = new byte[16];
            for (int i = 0; i < 16; ++i) headerIV[i] = (byte)((i * i * i + i * i - i) % 256);

            // Decrypt header
            byte[] decryptedHeader;
            try
            {
                decryptedHeader = AES_Decrypt(encryptedHeader, passwordHeader, 1, 2, headerIV);
            }
            catch (Exception ex)
            {
                br.Close(); bw.Close();
                throw ex;
            }

            // Split memory to each member of (algo, padMode, ciMode, IV)            
            byte[] IV = new byte[16], bAlgo = new byte[4], bPad = new byte[4], bCi = new byte[4];
            Array.Copy(decryptedHeader, 0, bAlgo, 0, 4);
            Array.Copy(decryptedHeader, 4, bPad, 0, 4);
            Array.Copy(decryptedHeader, 8, bCi, 0, 4);
            Array.Copy(decryptedHeader, 12, IV, 0, 16);

            // Convert byte[] to int
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bAlgo);
                Array.Reverse(bPad);
                Array.Reverse(bCi);
            }
            int algo = BitConverter.ToInt32(bAlgo, 0), padMode = BitConverter.ToInt32(bPad, 0), ciMode = BitConverter.ToInt32(bCi, 0);


            // ===== Decrypt Content of File Process.        
            long fileLength = br.BaseStream.Length;

            if (algo == 0) passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            else if (algo == 1 || algo == 3) passwordBytes = MD5.Create().ComputeHash(passwordBytes);
            else
            {
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                Array.Resize(ref passwordBytes, 8);
            }

            while (true)
            {
                int plus = algo == 0 ? 16 : 8;

                try
                {
                    byte[] buffer = br.ReadBytes(MAX_READ_BYTE + plus); // SỐ 16 này có thể thay đổi tùy theo thuật toán, có thể không +16 cho buffer cuối.
                    byte[] decryptBuff;

                    if (algo == 0) decryptBuff = AES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 1) decryptBuff = TDES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 2) decryptBuff = DES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else decryptBuff = RC2_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);

                    bw.Write(decryptBuff);
                    if (br.BaseStream.Position >= fileLength)
                    {
                        br.Close(); bw.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    br.Close(); bw.Close();
                    throw ex;
                }
            }
        }

        // Hàm Encrypt và Decrypt file RSA
        public int EncryptFileRSA(string pathInput, string pathOutput, string pathKey)
        {
            RSACryptoServiceProvider ersa = new RSACryptoServiceProvider();
            ersa.FromXmlString(System.IO.File.ReadAllText(pathKey));

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            long fileLength = br.BaseStream.Length;
            while (true)
            {
                try
                {
                    byte[] buffer = br.ReadBytes(ersa.KeySize / 8 - 42);
                    byte[] encryptBuff = RSA_Encrypt(buffer, ersa.ExportParameters(false), true);

                    bw.Write(encryptBuff);
                    if (br.BaseStream.Position >= fileLength)
                    {
                        br.Close(); bw.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    br.Close(); bw.Close();
                    throw ex;
                }
            }
            return 0;
        }

        public int DecryptFileRSA(string pathInput, string pathOutput, string pathKeyFile)
        {
            RSACryptoServiceProvider drsa = new RSACryptoServiceProvider();
            drsa.FromXmlString(System.IO.File.ReadAllText(pathKeyFile));

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            long fileLength = br.BaseStream.Length;
            while (true)
            {
                try
                {
                    byte[] buffer = br.ReadBytes(drsa.KeySize / 8);
                    byte[] decryptBuff = RSA_Decrypt(buffer, drsa.ExportParameters(true), true);

                    bw.Write(decryptBuff);
                    if (br.BaseStream.Position >= fileLength)
                    {
                        br.Close(); bw.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    br.Close(); bw.Close();
                    throw ex;
                }
            }
            return 0;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSignInUp());                 
        }
    }
}
