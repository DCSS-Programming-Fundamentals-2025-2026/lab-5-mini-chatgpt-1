public class CorpusLoad : ICorpusLoader
{
    private readonly CorpusTextNormalizer textNormalizer;
    private readonly CorpusSplitter corpusSplitter;
    private readonly IFileSystem defaultFileSystem;

    public CorpusLoad(CorpusTextNormalizer textNormalizer, CorpusSplitter corpusSplitter, DefaultFileSystem defaultFileSystem)
    {
        this.textNormalizer = textNormalizer;
        this.corpusSplitter = corpusSplitter;
        this.defaultFileSystem = defaultFileSystem;
    }
    public Corpus Load(string path, CorpusLoadOptions? options)
    {
        if (options == null) options = new CorpusLoadOptions();
        bool exist = defaultFileSystem.Exists(path);
        string content;
        if (exist)
        {
            content = defaultFileSystem.ReadAllText(path);
        }
        else
        {
            content = options.FallBack;
        }
        return LoadFromText(content, options);
    }

    public Corpus LoadFromText(string text, CorpusLoadOptions? options)
    {
        if (options == null) options = new CorpusLoadOptions();
        text = textNormalizer.Normilize(options.LowerCase, text);

        string[] parts = corpusSplitter.Splitter(text, options.ValidateFraction);
        string TrainText = parts[0];
        string ValidatePart = parts[1];

        return new Corpus(TrainText, ValidatePart);
    }
}







