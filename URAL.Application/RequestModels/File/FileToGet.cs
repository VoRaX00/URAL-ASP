namespace URAL.Application.RequestModels.File;

public class FileToGet
{
    public long ChatId { get; set; }
    public string Username { get; set; }
    public string FileName { get; set; }
    public byte[] FileContent { get; set; }
}