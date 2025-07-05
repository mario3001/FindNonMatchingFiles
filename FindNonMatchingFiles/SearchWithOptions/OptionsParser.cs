using Microsoft.Extensions.Configuration;

namespace FindNonMatchingFiles.SearchWithOptions;

public class OptionsParser
{
    public Options GetOptionsFromSettings(IConfigurationRoot configurationRoot)
    {
        var configurationSections = configurationRoot.GetChildren().ToList();

        var options = new Options
        {
            Path = configurationSections
                .First(x => x.Key == "FilePath").Value!,
            MaxAgeYears = configurationSections.First(x => x.Key == "MaxAgeYears").Value!.ToInt32(),
            Excludes = configurationRoot.GetSection("Excludes").GetChildren()
                .ToDictionary(x => x.GetChildren().First(y => y.Key == "key").Value!,
                    x => Convert.ToInt32(x.GetChildren().First(y => y.Key == "value").Value)),
            ExcludeFolderRegExPatterns = [.. configurationRoot.GetSection("ExcludeFolderNameRexExPatterns").GetChildren().Select(x => x.Value!)],
            ExcludeFileRegExPatterns = [.. configurationRoot.GetSection("ExcludeFileNameRexExPatterns").GetChildren().Select(x => x.Value!)],
            SearchPatterns = [.. configurationSections.First(x => x.Key == "FileSearchPatterns").GetChildren().Select(x => x.Value!)],
            ExecuteCommands = configurationSections.FirstOrDefault(x => x.Key == "ExecuteCommands")?.GetChildren()
                .Select(x => x.Value!)
                .ToArray() ?? [],
            FilePatternRegex = configurationSections.First(x => x.Key == "FilePatternRegex").Value!
        };

        return options;
    }
}