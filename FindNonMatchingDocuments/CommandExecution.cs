using System.Diagnostics;
using FindNonMatchingFiles.SearchWithOptions;

namespace FindNonMatchingDocuments;

public class CommandExecution
{
    public void Execute(List<FileInfo> fileInfos, Options options)
    {
        if (fileInfos.Count <= 0 || options.ExecuteCommands.Length == 0)
        {
            return;
        }

        foreach (var foundFile in fileInfos)
        {
            foreach (var optionsExecuteCommand in options.ExecuteCommands)
            {
                try
                {
                    var process = Process.Start(optionsExecuteCommand, $" \"{foundFile.FullName}\"");
                    while (!process.HasExited)
                    {
                        // waiting for command to finish.
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        Console.WriteLine();
    }
}