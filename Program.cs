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
            string command = Console.ReadLine(); //вводим команду с клавиатуры
            Console.Clear();

            if (command == "ls") //вывод файлов и каталогов в консоль
            {
                Output();
            }
            else if (command == "cp") //копирование каталога
            {
                CopyDir();
            }
            if (command == "rm") //удаление каталога
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
            else if(command == "file info") // вывод информации о файле - атрибуты и размер
            {
                InfoFile();
            }

            Console.ReadLine();
        }
        static void Output()
        {
            string address = Console.ReadLine(); //вводим адрес каталога
            bool correctAddress = Directory.Exists(address); //проверяем на наличие заданного каталога в компьютере

            if (correctAddress==true)
            {
                string[] list = Directory.GetFileSystemEntries(address, "*", SearchOption.AllDirectories); //создаем массив из каталогов
                int level = int.Parse(Console.ReadLine()); //указать номер страницы, которую необходимо открыть
                Console.Clear(); //чистим консоль
                Console.WriteLine("*************************************"); //выводим рамку на консоль
                Console.WriteLine(address); //выводим адрес каталога
                Console.WriteLine("*************************************"); //выводим рамку на консоль
                Console.WriteLine("Page "+level); //Выводим номер страницы

                if (level == 1) 
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(list[i]); //выводим файлы и каталоги 1 страницы
                    }
                }
                else if (level == 2)
                {
                    for (int i = 10; i < list.Length; i++)
                    {
                        Console.WriteLine(list[i]); //выводим файлы и каталоги 2 страницы
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого каталога не существует!");
            }

        }
        static void CopyDir()
        {
            string address = Console.ReadLine(); //Вводим адрес каталога, который хотим скопировать
            bool correctAddress = Directory.Exists(address); //проверяем на наличие заданного каталога в компьютере

            if (correctAddress)
            {
                Console.Clear(); //чистим консоль
                string targetPath = Console.ReadLine(); //Вводим адрес папки, куда мы хотим её скопировать

                Directory.CreateDirectory(targetPath); //создаем по новому адресу "скопированную" папку
            }
            else
            {
                Console.WriteLine("Такого каталога не существует!");
            }
        }
        static void RemoveDir()
        {
            string address = Console.ReadLine(); //вводим адрес каталога 
            bool correctAddress = Directory.Exists(address); //проверяем на наличие заданного каталога в компьютере
            if (correctAddress)
            {
                Directory.Delete(address); //удалаем каталог по заданному адресу
                Console.Clear(); //чистим консоль
            }
            else
            {
                Console.WriteLine("Такого каталога не существует!");
            }           

        }
        static void InfoDir()
        {
            string address = Console.ReadLine(); //вводим адрес каталога
            Console.Clear(); //чистим консоль

            Output(); //выводим содержимое каталога на консоль

            DriveInfo driveInfo = new DriveInfo(address); // получаем доступ к диску где находится каталог
            DirectoryInfo dirInfo = driveInfo.RootDirectory; // получаем корневой каталог
            Console.WriteLine("*************************************");
            Console.WriteLine(dirInfo.Attributes.ToString()); //выводим атрибуты каталога
            Console.WriteLine("*************************************");
        }
        static void CopyFile()
        {
            string fileName = "test.txt"; //имя файла для копирования
            string sourcePath = Console.ReadLine(); //вводим адрес файла для копирования с указанием имени и расширения файла
            bool correctFilename = File.Exists(sourcePath);

            if (correctFilename)
            {                
                string targetPath = Console.ReadLine(); //вводим новый адрес, куда файл будет скопирован
                string sourceFile = Path.Combine(sourcePath, fileName); //Указываем адрес исходного файла
                string destFile = Path.Combine(targetPath, fileName); //Указываем адрес полученного файла 
                File.Copy(sourceFile, destFile, true); //копируем файл 
            }
            else
            {
                Console.WriteLine("Такого файла не существует!");
            }
        }
        static void RemoveFile()
        {
            string address = Console.ReadLine(); //вводим адрес файла для удаления
            bool correctAddress = File.Exists(address); //проверяем на наличие заданного файла в компьютере

            if (correctAddress == true)
            {
                File.Delete(address); // удаляем файл по определенному адресу
                Console.Clear(); //чистим консоль
            }
            else
            {
                Console.WriteLine("Такого файла не существует!");
            }
        }
        static void InfoFile()
        {
            string address = Console.ReadLine(); //вводим адрес файла
            bool correctAddress = File.Exists(address); //проверяем на наличие заданного файла в компьютере

            if(correctAddress==true) 
            {
                FileInfo fileInfo = new FileInfo(address); //создаем класс
                Console.WriteLine("*************************************");
                Console.WriteLine(fileInfo.Attributes.ToString()); //выводит атрибуты файла
                Console.WriteLine(fileInfo.Length.ToString()); //выводит размер файла в байтах
                Console.WriteLine("*************************************");
            }
            else
            {
                Console.WriteLine("Такого файла не существует!");
            }     
        }
    }
}
//Вывод дерева файловой системы с условием “пейджинга” - только два уровня!
//Копирование файлов и каталогов
//Удаление файлов и каталогов
//Просмотр информации о файлах и каталогах - атрибуты и размер
///В конфигурационном файле выведена настройка вывода количества элементов на страницу
///При выходе сохраняется последнее состояние
//Комментарии в коде
///Документация к проекту в формате md
///Приложение обрабатывает непредвиденные ситуации (не падает)