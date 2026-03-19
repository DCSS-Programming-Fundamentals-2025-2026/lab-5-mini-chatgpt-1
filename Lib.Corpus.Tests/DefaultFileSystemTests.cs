using System.IO;

namespace Lib.Corpus.Tests;
public class FakeFileSystem : IFileSystem
{
    public bool Exists(string path) => false;

    public string ReadAllText(string path)
    {
        if (path == null || path == " " || path == "")
        {
            throw new FileNotFoundException("Couldn't find directory");
        }
        return File.ReadAllText(path);
    }
}

public class DefaultFileSystemTests
{
    private string path;
    FakeFileSystem fakeFileSystem = new();

    [Test]
    public void ReadAllText_Success()
    {
        path = "testFile.txt";
        string content = " ";
        File.WriteAllText(path, content);

        string expectedText = " ";
        string actualText = fakeFileSystem.ReadAllText(path);

        Assert.That(expectedText, Is.EqualTo(actualText));
    }

    [Test]
    public void ReadAllText_PathIsIncorrect()
    {
        string pathNull = null;
        string pathEmpty = "";
        string pathWhiteSpace = " ";

        Assert.Throws<FileNotFoundException>(() => fakeFileSystem.ReadAllText(pathNull));
        Assert.Throws<FileNotFoundException>(() => fakeFileSystem.ReadAllText(pathEmpty));
        Assert.Throws<FileNotFoundException>(() => fakeFileSystem.ReadAllText(pathWhiteSpace));
    }

    [Test]
    public void ReadAllText_PathIsIncorrect_ThrowsCorrectMessage()
    {
        path = "";
        string expectedMessage = "Couldn't find directory";

        FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => fakeFileSystem.ReadAllText(path));

        Assert.That(expectedMessage, Is.EqualTo(ex.Message));
    }

    [Test]
    public void Exists_Fail_PathIsIncorrect()
    {
        path = "";
        bool exists = fakeFileSystem.Exists(path);

        Assert.That(exists, Is.False);
    }
}
