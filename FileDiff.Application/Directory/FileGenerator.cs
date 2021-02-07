using System;
using System.Collections.Generic;
using System.Linq;
using FileDiff.Application.Validation;

namespace FileDiff.Application.Directory
{
    public class FileGenerator : IFileGenerator
    {
        private readonly IDirectory _directory;
        private readonly IErrorLogger _errorLogger;
        private readonly IValidator _validator;

        private readonly List<string> _validDirectories = new List<string>();
        private string _fileExtension;

        private string _fullFilePath;
        private string _outputDirectory;

        public FileGenerator(IDirectory directory, IErrorLogger errorLogger, IValidator validator)
        {
            _directory = directory;
            _errorLogger = errorLogger;
            _validator = validator;
        }

        public List<string> Process(string fullFilePath, string outputDirectory, string fileExtension)
        {
            SetFileValues(fullFilePath, outputDirectory, fileExtension);

            ProcessDirectories();

            OutputFiles();

            return _validDirectories;
        }

        private void SetFileValues(string fullFilePath, string outputDirectory, string fileExtension)
        {
            _fullFilePath = fullFilePath;
            _outputDirectory = outputDirectory;
            _fileExtension = fileExtension;
        }

        private void ProcessDirectories()
        {
            var directories = _directory.GetDirectories(_fullFilePath);
            foreach (var directory in directories)
            {
                ProcessSingleDirectory(directory);
            }
        }

        private void ProcessSingleDirectory(string directory)
        {
            if (_validator.Validate(directory, _fileExtension))
            {
                _validDirectories.Add(directory);
            }
        }

        private void OutputFiles()
        {
            var results = _validDirectories.OrderBy(x => x);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}