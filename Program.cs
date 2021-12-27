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
            Output();
            Console.ReadLine();

        }
        static void Output()
        {
            string address = Console.ReadLine();
            Console.WriteLine("*************************************");

            string[] list = Directory.GetFileSystemEntries(address, "*", SearchOption.AllDirectories);

            int level = int.Parse(Console.ReadLine());

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
    }
}
//Вывод дерева файловой системы с условием “пейджинга” - только два уровня!