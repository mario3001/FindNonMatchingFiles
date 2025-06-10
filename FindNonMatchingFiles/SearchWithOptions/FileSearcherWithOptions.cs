using FindNonMatchingFiles.Search;

namespace FindNonMatchingFiles.SearchWithOptions;

public class FileSearcherWithOptions
{
    private readonly FileSearcher _searcher = new();

    public void Execute(Options options, Action<FileInfo>? action = null)
    {
        _searcher.Execute(options.Path, options.SearchPatterns, options.Excludes, options.ExcludeFolderRegExPatterns, options.ExcludeFileRegExPatterns, options.MaxAgeYears, options.FilePatternRegex, action);
    }
}