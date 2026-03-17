public class DefaultFileSystem : IFileSystem
{
    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public bool Exists(string path)
    {
        return File.Exists(path);
    }
}