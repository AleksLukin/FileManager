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
            if (command == "ls") //вывод файлов и каталогов в консоль
            {
                Output();
            }
            else if (command == "cp") //копирование каталога
            {
                CopyDir();
            }
            else if (command == "rm") //удаление каталога
            {
                RemoveDir();
            }
            else if (command == "dir") //вывод информации о каталоге
            {
                InfoDir();
            }
            else if (command == "file cp") //копирование файла
            {
                CopyFile();
            }
            else if (command == "file rm") //удаление файла
            {
                RemoveFile();
            }
            else if (command == "file info") // вывод информации о файле - атрибуты и размер
            {
                InfoFile();
            }
            Console.ReadLine();
        }
        static void Output()
        {
            string address = Console.ReadLine();            
            string[] list = Directory.GetFileSystemEntries(address, "*", SearchOption.AllDirectories);
            int level = int.Parse(Console.ReadLine()); //указать номер страницы, которую необходимо открыть
            Console.Clear(); //чистим консоль
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
            string address = Console.ReadLine(); //Вводим адрес каталога, который хотим скопировать
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданного каталога
            Console.Clear(); //чистим консоль
            string targetPath = Console.ReadLine(); //Вводим адрес папки, куда мы хотим её скопировать

            Directory.CreateDirectory(targetPath); //создаем по новому адресу "скопированную" папку
        }
        static void RemoveDir()
        {
            string address = Console.ReadLine(); //вводим адрес каталога 
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданного каталога
            Directory.Delete(address); //удалаем каталог по заданному адресу
            Console.Clear(); //чистим консоль
        }
        static void InfoDir()
        {
            string address = Console.ReadLine(); //вводим адрес каталога
            Console.WriteLine(Directory.Exists(address)); //проверяет на наличие заданного каталога
            Console.Clear(); //чистим консоль

            Output(); //выводим содержимое каталога на консоль

            DriveInfo driveInfo = new DriveInfo(address);
            DirectoryInfo dirInfo = driveInfo.RootDirectory;
            Console.WriteLine("*************************************");
            Console.WriteLine(dirInfo.Attributes.ToString());
            Console.WriteLine("*************************************");
        }
        static void CopyFile()
        {
            string fileName = "test.txt"; //имя файла для копирования
            string sourcePath = Console.ReadLine(); //вводим адрес файла для копирования
            string targetPath = Console.ReadLine(); // вводим новый адрес, куда файл будет скопирован

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            File.Copy(sourceFile, destFile, true); //копируем файл 
        }
        static void RemoveFile()
        {
            string address = Console.ReadLine(); //вводим адрес файла для удаления
            Console.WriteLine(File.Exists(address)); //проверяет на наличие заданной директории
            File.Delete(address); // удаляем файл по определенному адресу
            Console.Clear(); //чистим консоль
        }
        static void InfoFile()
        {
            string address = Console.ReadLine(); //вводим адрес файла
            Console.WriteLine(File.Exists(address)); //проверяет на наличие заданной директории
            FileInfo fileInfo = new FileInfo(address); //создаем класс
            Console.WriteLine("*************************************");
            Console.WriteLine(fileInfo.Attributes.ToString()); //выводит атрибуты файла
            Console.WriteLine(fileInfo.Length.ToString()); //выводит размер файла в байтах
            Console.WriteLine("*************************************");
        }
    }
}
//Вывод дерева файловой системы с условием “пейджинга” - только два уровня!
//Копирование файлов и каталогов
//Удаление файлов и каталогов
//Просмотр информации о файлах и каталогах - атрибуты и размер
///В конфигурационном файле выведена настройка вывода количества элементов на страницу
///При выходе сохраняется последнее состояние
///Комментарии в коде
///Документация к проекту в формате md
///Приложение обрабатывает непредвиденные ситуации (не падает)