using System.Linq;

namespace FileDiff.Application.Validation
{
    public class Input : IInput
    {
        public bool Validate(string[] input)
        {
            if (input.Length == 0)
            {
                return false;
            }

            if (!input.Contains("fileGenerator") && !input.Contains("fileRunner"))
            {
                return false;
            }

            return true;
        }
    }
}