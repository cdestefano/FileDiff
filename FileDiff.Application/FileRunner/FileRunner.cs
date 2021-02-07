using System;
using System.Linq;
using System.Threading.Tasks;
using FileDiff.Application.File;
using FileDiff.Application.Validation;

namespace FileDiff.Application.FileRunner
{
    public class FileRunner : IFileRunner
    {
        private readonly IFile _file;
        private readonly IErrorLogger _errorLogger;

        private string _firstFilePath;
        private string _secondFilePath;
        private string _outputDirectory;

        public FileRunner(IFile file, IErrorLogger errorLogger)
        {
            _file = file;
            _errorLogger = errorLogger;
        }

        public async Task Process(string firstFilePath, string secondFilePath, string outputDirectory)
        {
            SetFileValues(firstFilePath, secondFilePath, outputDirectory);

            await ProcessFiles();
        }

        private void SetFileValues(string fullFilePath, string secondFilePath, string outputDirectory)
        {
            _firstFilePath = fullFilePath;
            _secondFilePath = secondFilePath;
            _outputDirectory = outputDirectory;
        }

        private async Task ProcessFiles()
        {
            var fileToCompare = await _file.ReadAllLinesAsync(_firstFilePath);
            var fileWithPotentiallyMissingDirectories = await _file.ReadAllLinesAsync(_secondFilePath);

            var missingDirectories = fileToCompare.Except(fileWithPotentiallyMissingDirectories).ToList();

            try
            {
                await _file.WriteAllLinesAsync(_outputDirectory, missingDirectories);
            }
            catch (Exception ex)
            {
                _errorLogger.LogError(ex);
            }
        }
    }
}