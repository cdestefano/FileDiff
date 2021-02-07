using System.IO;
using System.Linq;

namespace FileDiff.Application.Directory
{
    public class Validator : IValidator
    {
        private readonly IDirectory _directory;

        public Validator(IDirectory directory)
        {
            _directory = directory;
        }

        public bool Validate(string filePath, string fileExtension)
        {
            return _directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories)
                .Any(file => file.EndsWith(fileExtension));
        }
    }
}