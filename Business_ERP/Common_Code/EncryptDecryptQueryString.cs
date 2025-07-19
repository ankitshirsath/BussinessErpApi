using System.Security.Cryptography;
using System.Text;

namespace Business_ERP.Common_Code
{
    public class EncryptDecryptQueryString
    {
        public static string EncryptionKey = "r0b1nr0y";

        private byte[] _key = { };

        private readonly byte[] _iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

        public string Decrypt(string stringToDecrypt)

        {

            try

            {

                _key = Encoding.UTF8.GetBytes(EncryptionKey);

                var des = new DESCryptoServiceProvider();

                byte[] inputByteArray = Convert.FromBase64String(stringToDecrypt);

                var ms = new MemoryStream();

                var cs = new CryptoStream(ms,

                  des.CreateDecryptor(_key, _iv), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;

                return encoding.GetString(ms.ToArray());

            }

            catch (Exception e)

            {

                return e.Message;

            }

        }

        public string Encrypt(string stringToEncrypt)

        {

            try

            {

                _key = Encoding.UTF8.GetBytes(EncryptionKey);

                var des = new DESCryptoServiceProvider();

                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);

                var ms = new MemoryStream();

                var cs = new CryptoStream(ms, des.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());

            }

            catch (Exception e)

            {

                return e.Message;

            }

        }
    }
}
