using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileDiff.Application.FileGenerator
{
    public interface IFileGenerator
    {
        Task<List<string>> Process(string fullFilePath, string outputDirectory, string fileExtension);
    }
}