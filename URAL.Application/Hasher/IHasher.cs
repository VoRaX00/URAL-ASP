namespace URAL.Application.Hasher;

public interface IHasher
{
    public string Encode(string value);
    public string Decode(string value);
}
