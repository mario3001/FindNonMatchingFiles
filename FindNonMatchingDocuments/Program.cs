using FindNonMatchingDocuments;
using FindNonMatchingFiles.SearchWithOptions;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Search for non matching documents in progress...");

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true);

var configuration = builder.Build();

var options = new OptionsParser().GetOptionsFromSettings(configuration);

var foundFiles = new List<FileInfo>();

void FoundFileAction(FileInfo fileInfo)
{
    foundFiles.Add(fileInfo);
}

var fileSearcherWithOptions = new FileSearcherWithOptions();
fileSearcherWithOptions.Execute(options, FoundFileAction);

Console.WriteLine("Search done. PRESS ENTER");

Console.WriteLine();
Console.WriteLine("Executing commands...");

var commandExecution = new CommandExecution();
commandExecution.Execute(foundFiles, options);

Console.WriteLine("Done. PRESS ENTER");
Console.ReadLine();