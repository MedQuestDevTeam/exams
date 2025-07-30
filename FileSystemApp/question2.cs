using System;
using System.IO;

class FileSystem
{
    static void Main()
    {
        Console.WriteLine("Welcome to the File System!");
        
        while (true)
        {
            Console.Write("\nWhat operation would you like to perform? (create/read/write/delete/exit): ");
            string action = Console.ReadLine().Trim().ToLower();

            if (action == "create")
                CreateFile();
            else if (action == "read")
                ReadFile();
            else if (action == "write")
                WriteFile();
            else if (action == "delete")
                DeleteFile();
            else if (action == "exit")
                break;
            else
                Console.WriteLine("Invalid operation, please try again.");
        }
    }

    static void CreateFile()
    {
        Console.Write("Please enter the filename (e.g., test.txt): ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
            Console.WriteLine("File already exists!");
        else
        {
            File.Create(filename).Close();
            Console.WriteLine("File created successfully!");
        }
    }

    static void ReadFile()
    {
        Console.Write("Please enter the filename to read: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
            Console.WriteLine("File does not exist!");
        else
        {
            string content = File.ReadAllText(filename);
            Console.WriteLine("File content:\n" + content);
        }
    }

    static void WriteFile()
    {
        Console.Write("Please enter the filename to write to: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist!");
            return;
        }

        Console.Write("Please enter the content: ");
        string content = Console.ReadLine();

        File.WriteAllText(filename, content);
        Console.WriteLine("Write successful!");
    }

    static void DeleteFile()
    {
        Console.Write("Please enter the filename to delete: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
            Console.WriteLine("File does not exist!");
        else
        {
            File.Delete(filename);
            Console.WriteLine("File deleted successfully!");
        }
    }
}
