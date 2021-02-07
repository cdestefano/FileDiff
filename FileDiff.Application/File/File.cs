using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileDiff.Application.File
{
    public class File : IFile
    {
        public async Task WriteAllLinesAsync(string fileDirectory, IEnumerable<string> lines) =>
            await System.IO.File.WriteAllLinesAsync(fileDirectory, lines);

        public async Task<IEnumerable<string>> ReadAllLinesAsync(string fileDirectory) =>
            await System.IO.File.ReadAllLinesAsync(fileDirectory);
    }
}