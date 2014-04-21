using System;
using System.IO;
using System.Security.Cryptography;

namespace CloudKeysController
{
    public class CryptoHelper
    {

        static private byte[] aesKey = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 };
        static private byte[] aesIV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 };

        public static byte[] Encrypt(byte[] PlainBytes)
        {

            RijndaelManaged Crypto = null;
            MemoryStream ms = null;
            ICryptoTransform Encryptor = null;
            CryptoStream cryptoStream = null;

            using (Crypto = new RijndaelManaged())
            {
                Crypto.Key = aesKey;
                Crypto.IV = aesIV;

                ms = new MemoryStream();
                Encryptor = Crypto.CreateEncryptor(Crypto.Key, Crypto.IV);
                cryptoStream = new CryptoStream(ms, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainBytes, 0, PlainBytes.Length);
                if (Crypto != null)
                    Crypto.Clear();
                cryptoStream.Close();
            }
            return ms.ToArray();
        }

        public static byte[] Decrypt(byte[] cipherBytes)
        {
            RijndaelManaged Crypto = null;
            MemoryStream ms = null;
            ICryptoTransform Decryptor = null;
            CryptoStream cryptoStream = null;

            Byte[] plainTextBytes = new byte[cipherBytes.Length];

            using (Crypto = new RijndaelManaged())
            {
                Crypto.Key = aesKey;
                Crypto.IV = aesIV;
                ms = new MemoryStream(cipherBytes);
                Decryptor = Crypto.CreateDecryptor(Crypto.Key, Crypto.IV);
                cryptoStream = new CryptoStream(ms, Decryptor, CryptoStreamMode.Read);
                cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                if (Crypto != null)
                    Crypto.Clear();

                ms.Flush();
                ms.Close();

            }


            int i = plainTextBytes.Length - 1;
            while (plainTextBytes[i] == 0)
                --i;

            byte[] finalResule = new byte[i + 1];
            Array.Copy(plainTextBytes, finalResule, i + 1);

            return finalResule;
        }






        /*
        public static Byte[] Decrypt(Byte[] data)
        {
            if ((data == null) || (data.Length == 0))
            {
                return data;
            }
            Aes myAes = Aes.Create();
            //myAes.Padding = PaddingMode.None;
            myAes.KeySize = 128;
            myAes.Key = aesKey;
            myAes.IV = aesIV;
            myAes.Mode = CipherMode.ECB;

            using (MemoryStream stream = new MemoryStream(data))
            using (ICryptoTransform Decryptor = myAes.CreateDecryptor())
            using (CryptoStream decrypt = new CryptoStream(stream, Decryptor, CryptoStreamMode.Read))
            {
                byte[] PlainTextBytes = new byte[1000];
                int ByteCount = 0;
                ByteCount = decrypt.Read(PlainTextBytes, 0, PlainTextBytes.Length);
                return PlainTextBytes;
            }
        }


        public static Byte[] Encrypt(Byte[] data)
        {
            if ((data == null) || (data.Length == 0))
            {
                return data;
            }
            //myAes.Padding = PaddingMode.None;
            Aes myAes = Aes.Create();
            myAes.KeySize = 128;
            myAes.Key = aesKey;
            myAes.IV = aesIV;
            myAes.Mode = CipherMode.ECB;

            Byte[] plainTextBytes;
            Byte[] cypher

            using (MemoryStream stream = new MemoryStream())
            using (ICryptoTransform encryptor = myAes.CreateEncryptor())
            using (CryptoStream encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(data, 0, data.Length);
                plainTextBytes = stream.ToArray();
            }


            return plainTextBytes;
        }
         * */
    }
}
