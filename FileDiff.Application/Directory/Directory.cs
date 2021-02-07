namespace FileDiff.Application.Directory
{
    public class Directory : IDirectory
    {
        public string[] GetDirectories(string path) => System.IO.Directory.GetDirectories(path);

        public string[] GetFiles(string path, string searchPattern, System.IO.SearchOption searchOption) => System.IO.Directory.GetFiles(path, searchPattern, searchOption);
    }
}