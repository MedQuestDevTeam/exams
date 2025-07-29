using System;
using System.IO;

class FileSystem
{
    static void Main()
    {
        Console.WriteLine("欢迎使用文件系统！");
        
        while (true)
        {
            Console.Write("\n你想进行什么操作？（创建/读取/写入/删除/退出）：");
            string action = Console.ReadLine().Trim().ToLower();

            if (action == "创建")
                CreateFile();
            else if (action == "读取")
                ReadFile();
            else if (action == "写入")
                WriteFile();
            else if (action == "删除")
                DeleteFile();
            else if (action == "退出")
                break;
            else
                Console.WriteLine("无效操作，请重新输入。");
        }
    }

    static void CreateFile()
    {
        Console.Write("请输入文件名（如 test.txt）：");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
            Console.WriteLine("文件已存在！");
        else
        {
            File.Create(filename).Close();
            Console.WriteLine("文件已创建！");
        }
    }

    static void ReadFile()
    {
        Console.Write("请输入要读取的文件名：");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
            Console.WriteLine("文件不存在！");
        else
        {
            string content = File.ReadAllText(filename);
            Console.WriteLine("文件内容如下：\n" + content);
        }
    }

    static void WriteFile()
    {
        Console.Write("请输入要写入的文件名：");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("文件不存在！");
            return;
        }

        Console.Write("请输入内容：");
        string content = Console.ReadLine();

        File.WriteAllText(filename, content);
        Console.WriteLine("写入成功！");
    }

    static void DeleteFile()
    {
        Console.Write("请输入要删除的文件名：");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
            Console.WriteLine("文件不存在！");
        else
        {
            File.Delete(filename);
            Console.WriteLine("文件已删除！");
        }
    }
}
