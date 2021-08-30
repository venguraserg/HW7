using System;

namespace HW7
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Инициализация параметров
            Repository repository = new Repository();
            Init.Initialization(ref repository);
              

            // Запуск цикла программы 
            while (Menu.Start(repository))
            {

            }
            
            Console.WriteLine("Конец программы. Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
        }

        
    }
}
