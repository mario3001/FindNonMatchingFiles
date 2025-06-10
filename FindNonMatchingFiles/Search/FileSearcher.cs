using System.Text.RegularExpressions;

namespace FindNonMatchingFiles.Search
{
    public class FileSearcher
    {
        public void Execute(
            string path,
            ICollection<string> searchPatterns,
            IDictionary<string, int> excludes,
            List<string> excludeFolderRegExPatterns,
            List<string> excludeFileRegExPatterns,
            int maxAgeYears,
            string filePatternRegex,
            Action<FileInfo>? action = null)
        {
            var minDateTime = DateTime.Today.AddYears(-maxAgeYears);

            var filePaths = searchPatterns
                .SelectMany(searchPattern => Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly))
                .Where(filePath => !excludeFileRegExPatterns.Any(x => Regex.IsMatch(Path.GetFileNameWithoutExtension(filePath), x, RegexOptions.Multiline)));

            foreach (var filePath in filePaths)
            {
                MatchingFile(excludes, filePatternRegex, action, filePath, minDateTime);
            }

            var subDirectories = Directory.GetDirectories(path);

            foreach (var subDirectoryPath in subDirectories)
            {
                SearchFolderPath(searchPatterns, excludes, excludeFolderRegExPatterns, excludeFileRegExPatterns, filePatternRegex, action, subDirectoryPath);
            }
        }

        private static void MatchingFile(
            IDictionary<string, int> excludes,
            string filePatternRegex,
            Action<FileInfo>? action,
            string filePath,
            DateTime minDateTime)
        {
            var matchingExclude = excludes.SingleOrDefault(x => filePath.Contains(x.Key));
            var subfolderDepth = !matchingExclude.IsDefault() ? filePath[matchingExclude.Key.Length..].Count(x => x == '\\') : 0;

            if (!matchingExclude.IsDefault() && subfolderDepth > matchingExclude.Value)
            {
                return;
            }

            var fileInfo = new FileInfo(filePath);

            if (fileInfo.CreationTime.Year <= minDateTime.Year &&
                fileInfo.LastWriteTime.Year <= minDateTime.Year)
            {
                return;
            }

            var fileName = fileInfo.Name;

            if (Regex.IsMatch(fileName, filePatternRegex, RegexOptions.Multiline))
            {
                return;
            }

            Console.WriteLine($"Found a non match in {filePath}");
            action?.Invoke(fileInfo);
        }

        private void SearchFolderPath(ICollection<string> searchPatterns, IDictionary<string, int> excludes, List<string> excludeFolderRegExPatterns,
            List<string> excludeFileRegExPatterns, string filePatternRegex, Action<FileInfo>? action, string subDirectoryPath)
        {
            var subDirectory = Path.GetFileName(subDirectoryPath);
            var matchExcludeFolderRegEx = excludeFolderRegExPatterns.Any(x => Regex.IsMatch(subDirectory, x, RegexOptions.Multiline));

            if (matchExcludeFolderRegEx)
            {
                return;
            }

            var matchingExclude = excludes.SingleOrDefault(x => subDirectoryPath.Contains(x.Key));
            var subfolderDepth = !matchingExclude.IsDefault() ? subDirectoryPath.Substring(matchingExclude.Key.Length).Count(x => x == '\\') : 0;

            if (!matchExcludeFolderRegEx && (matchingExclude.IsDefault() || subfolderDepth < matchingExclude.Value))
            {
                Execute(subDirectoryPath, searchPatterns, excludes, excludeFolderRegExPatterns, excludeFileRegExPatterns, 3, filePatternRegex, action);
            }
        }
    }
}