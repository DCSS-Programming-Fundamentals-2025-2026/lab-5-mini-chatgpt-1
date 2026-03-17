public interface ICorpusLoader
{
    Corpus Load(string path, CorpusLoadOptions options);
}