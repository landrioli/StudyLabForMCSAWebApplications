using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace StudyLab._11___Criptography
{
    class CryptographExercises : IExerciseContent
    {
        public void Execute()
        {
            //CryptoSymmetricKey();
            //DecryptAsymmetricKey();
            //ProtectedMethod();
            //HashPassword();
            // SaltHashPassword();
            SecureString();
        }

        private void CryptoSymmetricKey()
        {
            //specify the data
            string plainData = "Secret Message";
            //convert into bytes of array
            byte[] plainDataInBytes = Encoding.UTF8.GetBytes(plainData);
            //Create a default cryptography object used to perform symmetric encryption
            SymmetricAlgorithm symmetricAlgo = SymmetricAlgorithm.Create();
            //Create encryptor with key and IV (Optional)
            ICryptoTransform encryptor = symmetricAlgo.CreateEncryptor(symmetricAlgo.Key, symmetricAlgo.IV);
            byte[] cipherDataInBytes = encryptor.TransformFinalBlock(plainDataInBytes, 0, plainDataInBytes.Length);
            //get the bytes of encrypted data into string
            string cipherData = Encoding.UTF8.GetString(cipherDataInBytes);
            Console.WriteLine("Encrypted Data is: " + cipherData);
            //Decrypt
            ICryptoTransform decryptor = symmetricAlgo.CreateDecryptor(symmetricAlgo.Key,
                symmetricAlgo.IV);
            plainDataInBytes = decryptor.TransformFinalBlock(cipherDataInBytes, 0,
                cipherDataInBytes.Length);
            plainData = Encoding.UTF8.GetString(plainDataInBytes);
            Console.WriteLine("Decrypted Data is: " + plainData);

        }

        private void DecryptAsymmetricKey()
        {
            //Creation of asymmetric algo object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //saving the key information to RSAParameters structure
            RSAParameters RSAKeyInfo = rsa.ExportParameters(false);
            //generating both keys( public and private)
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            //data to encrypt
            string data = "Secret Message";
            //convert into bytes
            byte[] dataInBytes = Encoding.UTF8.GetBytes(data);
            //Specify the public key obtained from receiver
            rsa.FromXmlString(publicKey);
            //Use Encrypt method for encryption
            byte[] encryptedDataInBytes = rsa.Encrypt(dataInBytes, true);
            //get the bytes of encrypted data into string
            string encryptedData = Encoding.UTF8.GetString(encryptedDataInBytes);
            Console.WriteLine("\nEncrypted Data is: " + encryptedData);
            //Decrpyting Code (on receiver side)
            //Specify the private key
            rsa.FromXmlString(privateKey);
            //Use Decrypt method for encryption
            byte[] decryptedDataInBytes = rsa.Decrypt(encryptedDataInBytes, true);
            //get the bytes of decrypted data into string
            string decryptedData = Encoding.UTF8.GetString(decryptedDataInBytes);
            Console.WriteLine("Decrypted Data is: " + decryptedData);
        }

        private void CryptoStream()
        {
            string message = "SECRET MESSAGE";
            SymmetricAlgorithm symmetric = SymmetricAlgorithm.Create();
            ICryptoTransform encryptor = symmetric.CreateEncryptor(symmetric.Key, symmetric.IV);
            MemoryStream memoryStream = new MemoryStream();
            //crptoStream know encrptor and stream in which data to written
            CryptoStream crptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.
                Write);
            //writer has reference of cryptoStream (what to encrypt and where)
            using (StreamWriter streamWriter = new StreamWriter(crptoStream))
            {
                //write the ecrypted message into memeory stream
                streamWriter.Write(message);
            }
            //close cryptoStream
            crptoStream.Close();
            //Close memoryStream
            memoryStream.Close();

            ICryptoTransform decryptor = symmetric.CreateDecryptor(symmetric.Key, symmetric.IV);
            //memoryStream = new MemoryStream(CIPER_TEXT_HERE); ToDo: Fix because it is necessary
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.
                Read);
            using (StreamReader streamReader = new StreamReader(cryptoStream))
            {
                string decryptedData = streamReader.ReadToEnd();
            }
        }

        private void ProtectedMethod()
        {
            string message = "Hello World";
            //Convert data into a byte array
            byte[] userData = Encoding.UTF8.GetBytes(message);
            //encrypt the data by using ProtectedData.Protect method
            byte[] encryptedDataInBytes = ProtectedData.Protect(userData, null, DataProtectionScope.
                CurrentUser);
            string encryptedData = Encoding.UTF8.GetString(encryptedDataInBytes);
            Console.WriteLine("Encrypted Data is: " + encryptedData);

            byte[] decryptedDataInBytes = ProtectedData.Unprotect(encryptedDataInBytes, null,
                DataProtectionScope.CurrentUser);
            string decryptedData = Encoding.UTF8.GetString(decryptedDataInBytes);
            Console.WriteLine("Decrypted Data is: " + decryptedData);
        }

        private void HashPassword()
        {
            //password to be hashed
            string password = "HelloWorld";
            //password in bytes
            var passwordInBytes = Encoding.UTF8.GetBytes(password);
            //Create the SHA512 object
            HashAlgorithm sha512 = SHA512.Create();
            //generate the hash
            byte[] hashInBytes = sha512.ComputeHash(passwordInBytes);
            var hashedData = new StringBuilder();
            foreach (var item in hashInBytes)
            {
                hashedData.Append(item);
            }
            Console.WriteLine("Hashed Password is: " + hashedData.ToString());
        }

        private void SaltHashPassword()
        {
            //password to be hashed
            string password = "HelloWorld";
            //generate Salt (GUID is globally uniqe identifer)
            Guid salt = Guid.NewGuid();
            //Merge password with random value
            string saltedPassword = password + salt;
            //password in bytes
            var passwordInBytes = Encoding.UTF8.GetBytes(saltedPassword);
            //Create the SHA512 object
            HashAlgorithm sha512 = SHA512.Create();
            //generate the hash
            byte[] hashInBytes = sha512.ComputeHash(passwordInBytes);
            var hashedData = new StringBuilder();
            foreach (var item in hashInBytes)
            {
                hashedData.Append(item);
            }
            Console.WriteLine("Unique hashed Password is: " + hashedData.ToString());
        }

        private void SecureString()
        {
            SecureString secureString = new SecureString();
            Console.Write("Please enter your Credit Card Number: ");
            while (true)
            {
                ConsoleKeyInfo enteredKey = Console.ReadKey(true);
                if (enteredKey.Key == ConsoleKey.Enter)
                    break;
                secureString.AppendChar(enteredKey.KeyChar);
                Console.Write("#");
            }
            secureString.MakeReadOnly();
            //When done with SecureString, Dispose the content so that it does not remain in memory
            secureString.Dispose();
            //Read SecureString
            IntPtr plainTextAsIntPtr = IntPtr.Zero;
            try
            {
                //Decrypt string (as a IntPtr)
                plainTextAsIntPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                Marshal.PtrToStringUni(plainTextAsIntPtr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //This method CLeared dycrypted string from memory
                Marshal.ZeroFreeGlobalAllocUnicode(plainTextAsIntPtr);
                Console.WriteLine("Memory Cleared.");
            }
        }
    }
}
