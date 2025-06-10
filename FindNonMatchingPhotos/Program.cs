using FindNonMatchingFiles.SearchWithOptions;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Search for non matching photos in progress...");

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, false);

var configuration = builder.Build();

var options = new OptionsParser().GetOptionsFromSettings(configuration);

var fileSearcherWithOptions = new FileSearcherWithOptions();
fileSearcherWithOptions.Execute(options);

Console.WriteLine("Search done. PRESS ENTER");
Console.ReadLine();