using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileDiff.Application.File
{
    public class File : IFile
    {
        public async Task WriteAllLines(string fileDirectory, IEnumerable<string> lines)
        {
            await System.IO.File.WriteAllLinesAsync(fileDirectory, lines);
        }
    }
}