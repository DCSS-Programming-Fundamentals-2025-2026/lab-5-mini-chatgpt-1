namespace Lib.Corpus.Tests
{
    public class LoadTests
    {
        private string path;
        private string content;
        private CorpusLoader _loader;
        private CorpusLoadOptions _options;


        [SetUp]
        public void SetUp()
        {
            CorpusTextNormalizer normalizer = new CorpusTextNormalizer();
            CorpusSplitter splitter = new CorpusSplitter();
            DefaultFileSystem fileSystem = new DefaultFileSystem();

            _loader = new CorpusLoader(normalizer, splitter, fileSystem);
            _options = new CorpusLoadOptions();

            path = "testFile.txt";
            content = "alpha beta gamma delta epsilon zeta eta theta iota kappa lambda mu nu xi omicron pi rho sigma tau up";
            File.WriteAllText(path, content);
        }

        [Test]
        public void LoadNormalSuccess()
        {
            CorpusClass corpus = _loader.Load(path, _options);

            Assert.That(corpus, Is.Not.Null);
            Assert.That("gma tau up", Is.EqualTo(corpus.ValText));
        }

        [Test]
        public void LoadFail_PathIsNullOrNotExcist()
        {
            path = null;

            CorpusClass corpus = _loader.Load(path, _options);

            Assert.That(corpus, Is.Not.Null);
            Assert.That("запасне значення", Is.EqualTo(corpus.TrainText));
        }

        [Test]
        public void LoadSuccess_OptionsIsNull()
        {
            CorpusClass corpus = _loader.Load(path, _options);

            Assert.That(corpus, Is.Not.Null);
            Assert.That("gma tau up", Is.EqualTo(corpus.ValText));
        }
    }
}
