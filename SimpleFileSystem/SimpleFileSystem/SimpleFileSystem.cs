using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileSystemApp
{
    public class SimpleFileSystem
    {
        private readonly string baseDirectory;

        public SimpleFileSystem(string directory)
        {
            baseDirectory = directory;

            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
        }

        private string GetFilePath(string fileName)
        {
            return Path.Combine(baseDirectory, fileName);
        }

        public void CreateFile(string fileName)
        {
            string path = GetFilePath(fileName);
            if (File.Exists(path))
            {
                Console.WriteLine("File already exists.");
                return;
            }

            File.Create(path).Dispose();
            Console.WriteLine($"File '{fileName}' created.");
        }

        public void WriteToFile(string fileName, string content)
        {
            string path = GetFilePath(fileName);
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            File.WriteAllText(path, content);
            Console.WriteLine($"Content written to '{fileName}'.");
        }

        public void ReadFile(string fileName)
        {
            string path = GetFilePath(fileName);
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            string content = File.ReadAllText(path);
            Console.WriteLine($"\n--- Contents of '{fileName}' ---\n{content}\n");
        }

        public void DeleteFile(string fileName)
        {
            string path = GetFilePath(fileName);
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            File.Delete(path);
            Console.WriteLine($"File '{fileName}' deleted.");
        }

        public void ListFiles()
        {
            var files = Directory.GetFiles(baseDirectory);
            if (files.Length == 0)
            {
                Console.WriteLine("No files found.");
                return;
            }

            Console.WriteLine("\n--- Files in Directory ---");
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
    }

}
