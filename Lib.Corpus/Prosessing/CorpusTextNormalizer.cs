public class CorpusTextNormalizer
{
    public string  Normilize(bool Lowercase, string text)
    {
        if (Lowercase) text = text.ToLower();
        return text;
    }
}