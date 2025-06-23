# FindNonMatchingFiles

## Overview
FindNonMatchingFiles is a  .NET solution containing multiple applications designed to identify and process files within directories that do not adhere to predefined naming conventions or criteria. The solution provides specialized tools for different file types and use cases.

## Projects

### [FindNonMatchingDocuments](FindNonMatchingDocuments/Readme.md)
A .NET application specifically designed for document files (PDF, DOC, DOCX, etc.) that:
- Identifies documents not following date-based naming conventions
- Uses regex patterns to validate file naming formats
- Supports execution of custom commands on matching files
- Ideal for document organization and compliance checking

### [FindNonMatchingPhotos](FindNonMatchingPhotos/Readme.md)
A .NET application tailored for photo and video files that:
- Processes various media formats (JPG, PNG, MP4, AVI, etc.)
- Focuses on file organization without strict naming pattern requirements
- Supports batch processing of multimedia content
- Useful for media library organization

### FindNonMatchingFiles
The core project providing shared functionality and base components for file searching and processing.

## Key Features

- **Flexible Configuration**: All applications use `appsettings.json` for easy configuration management
- **Pattern Matching**: Support for file pattern matching and regex validation
- **Exclusion Rules**: Advanced folder and file exclusion capabilities with hierarchical levels
- **Age Filtering**: Filter files based on age criteria
- **Command Execution**: Execute custom commands on identified files
- **Cross-Platform**: Built on .NET 8.0 for cross-platform compatibility

## Common Configuration Parameters

All applications share similar configuration patterns:

- **FilePath**: Root directory for file searching
- **FileSearchPatterns**: Array of file patterns to search for
- **MaxAgeYears**: Maximum age of files to consider
- **Excludes**: Hierarchical exclusion rules for folders
- **ExcludeFolderNameRexExPatterns**: Regex patterns for folder exclusion
- **ExecuteCommand**: Command to execute on non matching files

For detailed configuration examples, see the individual project README files:
- [FindNonMatchingDocuments Configuration](FindNonMatchingDocuments/Readme.md#configuration)
- [FindNonMatchingPhotos Configuration](FindNonMatchingPhotos/Readme.md#configuration)

## Getting Started

### Prerequisites
- .NET 8.0 SDK installed on your machine
- Visual Studio 2022 or Visual Studio Code (recommended)

## Configuration Examples

### Basic Document Search
All parameters described under: [FindNonMatchingDocuments Configuration](FindNonMatchingDocuments/Readme.md#configuration)
```json
{
  "FilePath": "C:\\Documents",
  "FileSearchPatterns": ["*.pdf", "*.docx"],
  "FilePatternRegex": "^\\d{4}-\\d{2}-\\d{2}",
  "MaxAgeYears": 5,
  "ExecuteCommand": "rename-doc.exe"
}
```

### Media Collection Processing
All parameters described under: [FindNonMatchingPhotos Configuration](FindNonMatchingPhotos/Readme.md#configuration)
```json
{
  "FilePath": "D:\\Photos",
  "FileSearchPatterns": ["*.jpg", "*.mp4", "*.png"],
  "MaxAgeYears": 10
}
```

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues to suggest improvements or report bugs.

## License

This project is licensed under the MIT License. The MIT License allows for great freedom in software use, modification, and distribution.
