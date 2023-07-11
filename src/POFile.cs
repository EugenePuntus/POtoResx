using System;
using System.Text.RegularExpressions;

namespace POtoResx
{
    public class POFile
    {
        private readonly string _fileName;

        public POFile(string fileName)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        public Task<Dictionary<string, string>> ToDictionaryAsync()
        {
            return Task.FromResult(
                new Dictionary<string, string>()
            );
        }
    }
}

