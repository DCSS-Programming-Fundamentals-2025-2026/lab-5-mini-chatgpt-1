

namespace Lib.Corpus.Tests
{
    public class FakeFileSystem : IFileSystem
    {
        public bool FileExists { get; set; } = true;
        public string FileContent { get; set; } = "";

        public bool Exists(string path) => FileExists;
        public string ReadAllText(string path) => FileContent;
    }

    public class LoadTests
    {
        private CorpusLoader _loader;
        private FakeFileSystem _fakeFileSystem;
        private CorpusLoadOptions _options;
        private string _content;

        [SetUp]
        public void SetUp()
        {
            CorpusTextNormalizer normalizer = new CorpusTextNormalizer();
            CorpusSplitter splitter = new CorpusSplitter();
            _fakeFileSystem = new FakeFileSystem();

            _loader = new CorpusLoader(normalizer, splitter, _fakeFileSystem);

            _options = new CorpusLoadOptions();
            _options.FallBack = "запасне значення";

            _content = "alpha beta gamma delta epsilon zeta eta theta iota kappa lambda mu nu xi omicron pi rho sigma tau up";
        }

        [Test]
        public void LoadNormalSuccess()
        {
            _fakeFileSystem.FileExists = true;
            _fakeFileSystem.FileContent = _content;

            CorpusClass corpus = _loader.Load("dummy.txt", _options);

            Assert.That(corpus, Is.Not.Null);
            Assert.That(corpus.ValText, Is.EqualTo("gma tau up"));
        }

        [Test]
        public void LoadFail_PathDoesNotExist()
        {
            _fakeFileSystem.FileExists = false;

            CorpusClass corpus = _loader.Load("dummy.txt", _options);

            Assert.That(corpus, Is.Not.Null);
            Assert.That(corpus.TrainText, Is.EqualTo("запасне значенн"));
        }

        [Test]
        public void LoadSuccess_OptionsIsNull()
        {
            _fakeFileSystem.FileExists = true;
            _fakeFileSystem.FileContent = _content;

            CorpusClass corpus = _loader.Load("dummy.txt", _options);

            Assert.That(corpus, Is.Not.Null);
            Assert.That(corpus.ValText, Is.EqualTo("gma tau up"));
        }
    }
}
