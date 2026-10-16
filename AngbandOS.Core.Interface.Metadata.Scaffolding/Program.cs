using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AngbandOS.Core.Interface.Configuration;

namespace AngbandOS.ConfigurationMetadataGenerator;

internal static class Program
{
    private static int Main(string[] args)
    {
        try
        {
            string outputPath = args.Length > 0 ? Path.GetFullPath(args[0]) : Path.Combine(AppContext.BaseDirectory, "configuration.json");

            Assembly configurationAssembly = typeof(NonCompositeSingletonGameConfiguration).Assembly;

            MetadataGenerator generator = new(configurationAssembly);

            ConfigurationDocument document = generator.Generate();

            JsonSerializerOptions options = new() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

            string json = JsonSerializer.Serialize(document, options);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

            File.WriteAllText(outputPath, json);

            Console.WriteLine($"Generated configuration metadata: {outputPath}");

            Console.WriteLine($"  Classes: {document.Classes.Count}");

            Console.WriteLine($"  Properties: {document.Classes.Sum(x => x.Properties.Count)}");

            return 0;
        }
        catch (MetadataGenerationException exception)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("Configuration metadata generation failed.");
            Console.Error.WriteLine();

            foreach (string error in exception.Errors)
            {
                Console.Error.WriteLine($"ERROR: {error}");
            }

            return 1;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine(
                $"Configuration metadata generation failed: {exception}");

            return 1;
        }
    }
}
