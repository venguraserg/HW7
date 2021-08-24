using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW7
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Инициализация параметров
            Menu.Init();
            Repository repository = new Repository();

            repository.AutocompliteRepository(25);


            // Запуск цикла программы 
            while (Menu.Start(repository))
            {

            }
            
            Console.WriteLine("Конец программы. Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
        }

        
    }
}
