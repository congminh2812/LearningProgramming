using System.Security.Cryptography;
using System.Text;

namespace LearningProgramming.Application.Extensions
{
    public class PasswordManager
    {
        // Method to hash a password using MD5
        public static string GetMd5Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash
            byte[] data = MD5.HashData(Encoding.UTF8.GetBytes(input));

            // Create a StringBuilder to collect the bytes
            var stringBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format it as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
                stringBuilder.Append(data[i].ToString("x2"));

            // Return the hexadecimal string
            return stringBuilder.ToString();
        }

        // Method to verify a password against a hash
        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input
            string inputHash = GetMd5Hash(input);

            // Compare the hash values
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(inputHash, hash) == 0;
        }

    }
}
