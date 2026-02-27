using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeConsoleAppFileSystem
{
    // Define the contract for the file system
    public interface IFileSystem
    {
        void CreateFile(string fileName);
        void WriteToFile(string fileName, string content);
        string ReadFile(string fileName);
        void DeleteFile(string fileName);
        IEnumerable<string> ListFiles();
    }

    // Represents the metadata and content of a single file
    public class VirtualFile
    {
        public string Name { get; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime LastModified { get; set; }

        public VirtualFile(string name)
        {
            Name = name;
            Content = string.Empty;
            CreatedAt = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
        }
    }

    // The file system implementation
    public class InMemoryFileSystem : IFileSystem
    {
        // Using a dictionary for O(1) file lookups
        private readonly Dictionary<string, VirtualFile> _files;

        public InMemoryFileSystem()
        {
            // Case-insensitive file names, typical of Windows file systems
            _files = new Dictionary<string, VirtualFile>(StringComparer.OrdinalIgnoreCase);
        }

        public void CreateFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be empty.", nameof(fileName));

            if (_files.ContainsKey(fileName))
                throw new InvalidOperationException($"A file named '{fileName}' already exists.");

            _files[fileName] = new VirtualFile(fileName);
        }

        public void WriteToFile(string fileName, string content)
        {
            if (!_files.TryGetValue(fileName, out var file))
                throw new FileNotFoundException($"The file '{fileName}' does not exist.");

            file.Content = content;
            file.LastModified = DateTime.UtcNow;
        }

        public string ReadFile(string fileName)
        {
            if (!_files.TryGetValue(fileName, out var file))
                throw new FileNotFoundException($"The file '{fileName}' does not exist.");

            return file.Content;
        }

        public void DeleteFile(string fileName)
        {
            if (!_files.Remove(fileName))
                throw new FileNotFoundException($"The file '{fileName}' does not exist.");
        }

        public IEnumerable<string> ListFiles()
        {
            return _files.Keys;
        }
    }
}