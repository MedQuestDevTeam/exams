using System;
using SimpleFileSystemApp;
public class Program
{
    public static void Main()
    {
        string workingDir = Path.Combine(Directory.GetCurrentDirectory(), "MyFiles");
        var fs = new SimpleFileSystem(workingDir);

        while (true)
        {
            Console.WriteLine("\n--- Simple File System ---");
            Console.WriteLine("1. Create File");
            Console.WriteLine("2. Write to File");
            Console.WriteLine("3. Read File");
            Console.WriteLine("4. Delete File");
            Console.WriteLine("5. List Files");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter file name: ");
                    fs.CreateFile(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Enter file name: ");
                    string writeFile = Console.ReadLine();
                    Console.Write("Enter content: ");
                    string content = Console.ReadLine();
                    fs.WriteToFile(writeFile, content);
                    break;
                case "3":
                    Console.Write("Enter file name: ");
                    fs.ReadFile(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter file name: ");
                    fs.DeleteFile(Console.ReadLine());
                    break;
                case "5":
                    fs.ListFiles();
                    break;
                case "6":
                    Console.WriteLine("Exiting.");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

