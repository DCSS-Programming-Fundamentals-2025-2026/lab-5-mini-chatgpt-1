public class CorpusSplitter
{
    public string[] Splitter(string path, double ValidateFraction)
    {
        int Validate = (int)(path.Length * ValidateFraction);
        int TrainPart = path.Length - Validate;

        string TrainText = path.Substring(0, TrainPart);
        string ValidatePart = path.Substring(TrainPart);

        string[] parts = { TrainText, ValidatePart };
        return parts;
    }
}


