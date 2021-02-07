namespace FileDiff.Application.Directory
{
    public interface IValidator
    {
        bool Validate(string filePath, string fileExtension);
    }
}