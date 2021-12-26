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
            string address = Console.ReadLine();
            Console.WriteLine("*************************************");

            string[] list = Directory.GetFileSystemEntries(address, "*", SearchOption.AllDirectories);

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.ReadLine();

        }
    }
}
//Вывод дерева файловой системы с условием “пейджинга” - только два уровня!