using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Minor.Dag52.Cryptography
{
    class Encrypt
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

            var fileContent = "";

            using (FileStream inputStream = File.OpenRead(filePath))
            using (StreamReader reader = new StreamReader(inputStream))
            {
                fileContent = reader.ReadToEnd();
            }

            byte[] IV = new byte[16];
            byte[] salt = new byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(IV);
            rng.GetBytes(salt);

            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(password, salt);
            byte[] key = hasher.GetBytes(16);

            File.WriteAllText(filePath, $"{salt}\n{IV}\n", Encoding.UTF8);

            using (Aes algorithm = Aes.Create())
            using (FileStream outputStream = File.OpenWrite(filePath))
            using (CryptoStream encryptedStream = new CryptoStream(outputStream, algorithm.CreateEncryptor(key, IV), CryptoStreamMode.Write))
            using (StreamWriter writer = new StreamWriter(encryptedStream))
            {
                writer.Write(fileContent);
            }

            Console.WriteLine($"{filePath} encrypted");

        }
    }
}
