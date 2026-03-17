public class Corpus
{
    public string? TrainText { get; set; }
    public string? ValText { get; set; }

    public Corpus(string TrainText, string ValText)
    {
        this.TrainText = TrainText;
        this.ValText = ValText;
    }
}