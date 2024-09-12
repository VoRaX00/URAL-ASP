using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

namespace URAL.Application.Hasher;

public class AesHasher : IHasher
{
    private readonly Aes _aes;

    public AesHasher()
    {
        _aes = Aes.Create();
        _aes.GenerateKey();
        _aes.GenerateIV();
    }
    

    public string Encode(string value)
    {
        var encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
        var msEncrypt = new MemoryStream();
        var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        var swEncrypt = new StreamWriter(csEncrypt);
        swEncrypt.Write(value);
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decode(string value)
    {
        var decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);
        var msDecrypt = new MemoryStream(Convert.FromBase64String(value));
        var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        var srDecrypt = new StreamReader(csDecrypt);
        return srDecrypt.ReadToEnd();
    }
}
