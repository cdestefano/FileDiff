using System.Collections.Generic;

namespace FileDiff.Application.Directory
{
    public interface IFileGenerator
    {
        List<string> Process(string fullFilePath, string outputDirectory, string fileExtension);
    }
}