using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDiff.Application.Directory;
using FileDiff.Application.File;
using FileDiff.Application.Validation;

namespace FileDiff.Application.FileGenerator
{
    public class FileGenerator : IFileGenerator
    {
        private readonly IDirectory _directory;
        private readonly IErrorLogger _errorLogger;
        private readonly IValidator _validator;
        private readonly IFile _file;

        private readonly List<string> _validDirectories = new List<string>();
        private string _fileExtension;

        private string _fullFilePath;
        private string _outputDirectory;

        public FileGenerator(IDirectory directory, IErrorLogger errorLogger, IValidator validator, IFile file)
        {
            _directory = directory;
            _errorLogger = errorLogger;
            _validator = validator;
            _file = file;
        }

        public async Task<List<string>> Process(string fullFilePath, string outputDirectory, string fileExtension)
        {
            SetFileValues(fullFilePath, outputDirectory, fileExtension);

            ProcessDirectories();

            await OutputFiles();

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

        private void ProcessSingleDirectory(string fullPathToDirectory)
        {
            if (_validator.Validate(fullPathToDirectory, _fileExtension))
            {
                var directoryName = GetLocalDirectoryName(fullPathToDirectory);
                _validDirectories.Add(directoryName);
            }
        }

        private string GetLocalDirectoryName(string directory) => directory.Replace(_fullFilePath, string.Empty);

        private async Task OutputFiles()
        {
            var result = _validDirectories.OrderBy(x => x);

            try
            {
                await _file.WriteAllLinesAsync(_outputDirectory, result);
            }
            catch (Exception ex)
            {
                _errorLogger.LogError(ex);
            }
        }
    }
}