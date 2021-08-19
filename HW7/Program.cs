using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW7
{
    class Program
    {
        private const string VIEW_NOTELIST = "1";
        private const string ADD_NOTE = "2";
        private const string MENU_3 = "3";
        private const string MENU_4 = "4";
        private const string QUIT = "x";


        static void Main(string[] args)
        {
            List<Note> notebook = new List<Note>();
            //notebook = ConsoleHelper.Autocomplete(100);
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("");
                switch (Console.ReadLine().ToLower())
                {
                    case VIEW_NOTELIST:
                        Console.Clear();
                        Console.WriteLine("Menu_1");
                        ConsoleHelper.PrintNotes(notebook);


                        break;
                    case ADD_NOTE:
                        notebook = ConsoleHelper.Autocomplete(10);
                        Console.Clear();
                        Console.WriteLine("Menu_2");
                        break;
                    case MENU_3:
                        Console.Clear();
                        Console.WriteLine("Menu_3");
                        break;
                    case MENU_4:
                        Console.Clear();
                        //Console.WriteLine("Menu_4");
                        break;
                    case QUIT:
                        quit = true;
                        break;
                    default:
                        break;
                }
            }


            

            
            Console.WriteLine("Конец программы. Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
        }
        
        
    }
}
