# FindNonMatchingDocuments
## Overview
FindNonMatchingDocuments is a .NET application designed to identify and process files within a directory that do not adhere to a predefined naming convention or criteria. It leverages the flexibility of appsettings.json for configuration, allowing users to specify directories, file patterns, exclusion rules, and actions on identified documents.

## Configuration
The application's behavior is driven by parameters defined in the appsettings.json file. Below is a detailed description of these parameters:
appsettings.json Parameters
•	FilePath: The root directory path where the document search begins.
•	FileSearchPatterns: An array of file patterns (e.g., *.pdf, *.docx, *.jpg, *.mpg) to search for within the specified directory.
•	FilePatternRegex: A regular expression pattern that documents must match to be considered for processing. This pattern is used to identify documents that do not adhere to a specific naming convention.
  - The sample ist for a date pattern in the format e.g. "2022-01-01 Something" or "2022-01--- Something" or "198x-12--- Something" or "19xx------ Something"
•	MaxAgeYears: The maximum age (in years) of the documents to be considered. Documents older than this age will be flagged.
•	Excludes: An array of objects specifying exclusion rules for folders and their subfolders, with different levels of exclusion.
  - Keys: 
    Substring that is contained in the full file path. Folders are splitted with \\
  - Values:
    0 = Excluding Folder
    1 = Including Files in Folder, but Excluding Subfolders
    2 = Including Files in Subfolders, but Excluding SubFolders of Subfolders
•	ExcludeFolderNameRexExPatterns: An array of regular expressions to match folder names that should be excluded from the search.
•	ExecuteCommand: The command to be executed for each document that meets the search criteria. For example a command to rename the file or open the file. The FilePath will be added as argument to the command.

## Example appsettings.json
´´´
{
  "FilePath": "Z:\\Dokumente",
  "FileSearchPatterns": ["*.pdf", "*.doc", "*.docx"],
  "FilePatternRegex": "^(19xx|194[0-9x]|195[0-9x]|196[0-9x]|197[0-9x]|198[0-9x]|199[0-9x]|200[0-9x]|201[0-9x]|202[0-9x])-(0[1-9]|1[0-2]|-[-])-(0[1-9]|1[0-9]|2[0-9]|3[0-1]|-[-])",
  "MaxAgeYears": 3,
  "Excludes": [
    { "key": "\\Dokumente\\Hobbies", "value": 0 },
    { "key": "\\Dokumente\\Familie", "value": 1 },
    { "key": "\\Dokumente\\Steuern", "value": 2 }
  ],
  "ExcludeFolderNameRexExPatterns": [
    "^-.*-$", // Example: - Archiv - 
    "^_.*_$"  // Example: _Irgendwtwas_ 
  ],
  "ExecuteCommand": "PdfFileRenameFromContent.Rules.Specific.exe"
}
´´´

## Getting Started for development
1.	Ensure you have .NET 8.0 Runtime SDK installed on your machine.
2.	Clone the repository or download the source code.
3.	Navigate to the application's root directory in your terminal.
4.	Update the appsettings.json file with your desired configuration.
5.	Run the application by executing dotnet run.

## Dependencies
•	Microsoft.Extensions.Configuration (8.0.0)
•	Microsoft.Extensions.Configuration.FileExtensions (8.0.0)
•	Microsoft.Extensions.Configuration.Json (8.0.0)

## Contributing
Contributions are welcome. Feel free to submit pull requests or open issues to suggest improvements or report bugs.

## License
FindNonMatchingDocuments is licensed under the MIT License. The MIT License is a popular choice for open-source projects due to its permissive nature, allowing for great freedom in software use, modification, and distribution.

For more details, see the LICENSE file in the project repository.
