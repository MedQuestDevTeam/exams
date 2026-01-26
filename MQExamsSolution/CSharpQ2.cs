using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * C# Question 2: Using the FileSystem class to perform file operations
 * Author: Kevin Tian
 */

namespace MQExamsSolution
{
    public class FileSystem
    {
        public void CreateFile(string path)
        {
            File.Create(path).Close();
        }

        public void WriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
