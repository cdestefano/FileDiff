using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileDiff.Application.File
{
    public interface IFile
    {
        Task WriteAllLinesAsync(string fileDirectory, IEnumerable<string> lines);

        Task<IEnumerable<string>> ReadAllLinesAsync(string fileDirectory);
    }
}