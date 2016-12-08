using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt
{
    class Decrypt
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of parameters, please provide a file and a password");
                return;
            }

            var filePath = args[0];
            var password = args[1];

            byte[] salt;
            byte[] IV;

            string decryptedContent = "";

            using (FileStream inputStream = File.OpenRead(filePath))
            using (StreamReader reader = new StreamReader(inputStream))
            {
                salt = Encoding.UTF8.GetBytes(reader.ReadLine());
                IV = Encoding.UTF8.GetBytes(reader.ReadLine());

                Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(password, salt);
                byte[] key = hasher.GetBytes(16);

                using (Aes algorithm = Aes.Create())
                using (CryptoStream encryptedStream = new CryptoStream(inputStream,
                    algorithm.CreateEncryptor(key, IV),
                    CryptoStreamMode.Read))
                using (StreamReader read = new StreamReader(encryptedStream))
                {
                    read.ReadLine();
                    read.ReadLine();
                    decryptedContent = read.ReadToEnd();
                }
            }

            using (FileStream inputStream = File.OpenWrite(filePath))
            using (StreamWriter writer = new StreamWriter(inputStream))
            {
                writer.Write(decryptedContent);
            }
        }
    }
}
