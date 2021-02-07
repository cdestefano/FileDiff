using System.IO;

namespace FileDiff.Application.Directory
{
    public interface IDirectory
    {
        string[] GetDirectories(string path);

        string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
    }
}