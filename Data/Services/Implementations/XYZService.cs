using System.Security.Cryptography;
using System.Text;

namespace URLShortener.Data.Service.Implementations
{
    public class XYZService
    {
        public string HashGenerate(string url)
        {
            byte[] hashValue = SHA256.HashData(Encoding.UTF8.GetBytes(url));
            return Convert.ToBase64String(hashValue)[..6];
        }
    }
}
