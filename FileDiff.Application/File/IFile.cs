using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileDiff.Application.File
{
    public interface IFile
    {
        Task WriteAllLines(string fileDirectory, IEnumerable<string> lines);
    }
}