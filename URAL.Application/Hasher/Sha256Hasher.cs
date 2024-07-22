using System.Security.Cryptography;
using System.Text;

namespace URAL.Application.Hasher;

public class Sha256Hasher : IHasher
{
    public string Hash(string value)
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.ASCII.GetBytes(value)));
    }
}
