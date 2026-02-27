using ChallengeConsoleAppFileSystem;

class Program
{
    static void Main(string[] args)
    {
        IFileSystem fileSystem = new InMemoryFileSystem();

        try
        {
            // Create files
            fileSystem.CreateFile("config.json");
            fileSystem.CreateFile("readme.txt");
            Console.WriteLine("Files created successfully.\n");

            // Write to a file
            string configData = "{ \"theme\": \"dark\", \"version\": 1.0 }";
            fileSystem.WriteToFile("config.json", configData);
            Console.WriteLine("Data written to config.json.\n");

            // Read from a file
            string readContent = fileSystem.ReadFile("config.json");
            Console.WriteLine("--- Reading config.json ---");
            Console.WriteLine(readContent);
            Console.WriteLine("---------------------------\n");

            // List all files
            Console.WriteLine("--- Files in System ---");
            foreach (var file in fileSystem.ListFiles())
            {
                Console.WriteLine($"- {file}");
            }
            Console.WriteLine("-----------------------\n");

            // Delete a file
            fileSystem.DeleteFile("readme.txt");
            Console.WriteLine("readme.txt deleted.\n");

            // Attempting to read a deleted file to show exception handling
            fileSystem.ReadFile("readme.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}