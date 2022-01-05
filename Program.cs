using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Console.Clear();
            if (command == "ls")
            {
                Output();
            }
            else if (command == "cp")
            {
                CopyDir();
            }
            else if (command == "rm")
            {
                RemoveDir();
            }
            else if (command == "dir")
            {
                InfoDir();
            }
            else if (command == "file cp")
            {
                CopyFile();
            }
            else if (command == "file rm")
            {
                RemoveFile();
            }
            Console.ReadLine();
        }
        static void Output()
        {
            string address = Console.ReadLine();
            

            string[] list = Directory.GetFileSystemEntries(address, "*", SearchOption.AllDirectories);

            int level = int.Parse(Console.ReadLine()); //указать номер страницы, которую необходимо открыть
            Console.Clear();
            Console.WriteLine("*************************************");
            Console.WriteLine(address);
            Console.WriteLine("*************************************");
            Console.WriteLine("Page "+level);

            if (level == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(list[i]);
                }
            }
            else if (level == 2)
            {
                for (int i = 10; i < list.Length; i++)
                {
                    Console.WriteLine(list[i]);
                }
            }
        }
        static void CopyDir()
        {
            string address = Console.ReadLine(); //Вводим адрес папки, которую хотим скопировать
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданной директории
            Console.Clear();
            string targetPath = Console.ReadLine(); //Вводим адрес папки, куда мы хотим её скопировать

            Directory.CreateDirectory(targetPath); //создаем по новому адресу "скопированную" папку
        }
        static void RemoveDir()
        {
            string address = Console.ReadLine();
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданной директории
            Directory.Delete(address);
            Console.Clear();
        }
        static void InfoDir()
        {
            string address = Console.ReadLine();
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданной директории
            Console.Clear();
            Output();
            DriveInfo di = new DriveInfo(address);
            DirectoryInfo dirInfo = di.RootDirectory;
            Console.WriteLine("*************************************");
            Console.WriteLine(dirInfo.Attributes.ToString());
            Console.WriteLine("*************************************");
        }
        static void CopyFile()
        {
            string address = Console.ReadLine(); //Вводим адрес папки, которую хотим скопировать
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданной директории
            Console.Clear();
            string targetPath = Console.ReadLine(); //Вводим адрес папки, куда мы хотим её скопировать

            Directory.CreateDirectory(targetPath); //создаем по новому адресу "скопированную" папку
        }
        static void RemoveFile()
        {
            string address = Console.ReadLine();
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданной директории
            Directory.Delete(address);
            Console.Clear();
        }
    }
}
//Вывод дерева файловой системы с условием “пейджинга” - только два уровня!
//Копирование файлов и каталогов
//Удаление файлов и каталогов
//Просмотр информации о файлах и каталогах