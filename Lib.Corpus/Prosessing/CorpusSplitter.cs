public class CorpusSplitter
{
    public string[] Splitter(string text, double ValidateFraction)
    {
        if (text == null || text == " " || text == "")
        {
            throw new NullReferenceException("Nothing to split here");
        }

        int Validate = (int)(text.Length * ValidateFraction);
        int TrainPart = text.Length - Validate;

        string TrainText = text.Substring(0, TrainPart);
        string ValidatePart = text.Substring(TrainPart);

        string[] parts = { TrainText, ValidatePart };
        return parts;
    }
}


