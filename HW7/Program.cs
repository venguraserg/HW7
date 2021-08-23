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
            
            Console.WriteLine("*******************************************************");
            Console.WriteLine("**                 ЕЖЕДНЕВНИК v0.0.1                 **");
            Console.WriteLine("**     Для получения списка команд введите /help     **");
            Console.WriteLine("*******************************************************");

            string patch = "db.csv";
            if (File.Exists(patch) == false)
            {
                using (File.Create(patch)) { };                
            }
            bool isFileEmpty = string.IsNullOrEmpty(File.ReadAllText(patch));
            
            List<Note> notebook = new List<Note>();
                      
            if(!isFileEmpty)
            {
                ConsoleHelper.ReadFileData(patch, ref notebook);
            }

            Repository repository = new Repository();
            repository.AddNote();


            repository.Notes.Add(new Note());
            // Меню 

            bool quit = false;
            while (!quit)
            {
                Console.Write(">/");
                switch (Console.ReadLine().ToLower())
                {
                    case "view all":
                        //Console.Clear();
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine("**                 Просмотр заметок                  **");
                        Console.WriteLine("*******************************************************");
                        ConsoleHelper.PrintNotes(notebook);
                        break;

                    case "view note":
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine("**           Просмотр конкретной заметки             **");
                        Console.WriteLine("*******************************************************");
                        int numberNote = ConsoleHelper.InputNumberNote(notebook.Count);
                        ConsoleHelper.PrintOneNote(notebook, numberNote);
                        break;

                    case "add":
                        //Console.Clear();
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine("**               Добавление заметки                  **");
                        Console.WriteLine("*******************************************************");
                        ConsoleHelper.AddNotes(ref notebook);
                        break;

                    case "add auto":
                        Console.Write("Введите число вносимых элементов: ");
                        var amount = ConsoleHelper.InputNumber();
                        notebook = ConsoleHelper.Autocomplete(amount, ref notebook);
                        Console.WriteLine("Данные успешно внесены");
                        break;

                    case "quit":
                        quit = true;
                        if(ConsoleHelper.EnterYesNo("Хотите сохранить данные (Y/N):"))
                        {
                            ConsoleHelper.WriteDataToFile(patch,notebook);
                        }
                        Console.WriteLine("");
                        break;
                    case "help":
                        //Console.Clear();
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine("**                  Cписок конманд:                  **");
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine(" - /help      - вывод списка команд");
                        Console.WriteLine(" - /view all  - просмотр заметок");
                        Console.WriteLine(" - /view note - детальный просмотр заметки");
                        Console.WriteLine(" - /add       - добавить заметку");
                        Console.WriteLine(" - /add auto  - добавить заметки автоматически");

                        Console.WriteLine(" - /quit      - выход из приложения");
                        break;
                    default:
                        //Console.Clear();
                        Console.WriteLine("Такой команды не существует, для получения информации введите /help ");
                        break;
                }
            }


            

            
            Console.WriteLine("Конец программы. Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
        }

        
    }
}
