using FileDiff.Application.Directory;
using FileDiff.Application.Validation;
using Moq;
using Xunit;

namespace FileDiff.Application.Test.Directory
{
    public class DirectoryTests
    {
        public DirectoryTests()
        {
            _directory = new Mock<IDirectory>();
            _errorLogger = new Mock<IErrorLogger>();
            _validator = new Mock<IValidator>();

            SetupDirectory();

            _fileGenerator = new FileGenerator(_directory.Object, _errorLogger.Object, _validator.Object);
        }

        private readonly Mock<IDirectory> _directory;
        private readonly Mock<IErrorLogger> _errorLogger;
        private readonly Mock<IValidator> _validator;

        private const string DIRECTORY = "initial/directory/path/";
        private const string OUTPUT_DIRECTORY = "output/directory/";
        private const string FILE_EXTENSION = "flac";

        private readonly FileGenerator _fileGenerator;

        private void SetupDirectory()
        {
            _directory.Setup(x => x.GetDirectories(It.IsAny<string>())).Returns(new[]
            {
                DIRECTORY + "Directory1/file.txt",
                DIRECTORY + "Directory2/file.flac"
            });
        }

        [Fact]
        public void Process_DirectoryContainsFileExtension_FileIsOutput()
        {
            // Arrange
            _validator.Setup(x => x.Validate(DIRECTORY + "Directory1/file.txt", FILE_EXTENSION)).Returns(false);
            _validator.Setup(x => x.Validate(DIRECTORY + "Directory2/file.flac", FILE_EXTENSION)).Returns(true);

            // Act
            var result = _fileGenerator.Process(DIRECTORY, OUTPUT_DIRECTORY, FILE_EXTENSION);

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, x => x == DIRECTORY + "Directory2/file.flac");
            Assert.DoesNotContain(result, x => x == DIRECTORY + "Directory1/file.txt");
        }
    }
}