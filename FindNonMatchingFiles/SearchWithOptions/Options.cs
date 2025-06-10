namespace FindNonMatchingFiles.SearchWithOptions;

public class Options
{
    public string Path { get; set; } = "";
    public int MaxAgeYears { get; set; }
    public Dictionary<string, int> Excludes { get; set; } = [];
    public List<string> ExcludeFolderRegExPatterns { get; set; } = [];
    public List<string> SearchPatterns { get; set; } = [];
    public string[] ExecuteCommands { get; set; } = [];
    public string FilePatternRegex { get; set; } = "";
    public List<string> ExcludeFileRegExPatterns { get; set; } = [];
}