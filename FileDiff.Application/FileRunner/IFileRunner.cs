using System.Threading.Tasks;

namespace FileDiff.Application.FileRunner
{
    public interface IFileRunner
    {
        Task Process(string firstFilePath, string secondFilePath, string outputDirectory);
    }
}