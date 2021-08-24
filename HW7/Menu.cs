using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public static class Menu
    {
        public static bool Start(Repository repository)
        {
            // Меню 
            bool quit = true;

            Console.Write(">/");
            switch (Console.ReadLine().ToLower())
            {
                case "view all":
                //Console.Clear();


                Console.WriteLine("********************************************************");
                Console.WriteLine("**                  Просмотр заметок                  **");
                Console.WriteLine("********************************************************");
                    //ConsoleHelper.PrintNotes(notebook);
                    break;

                case "view note":
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("**           Просмотр конкретной заметки             **");
                    Console.WriteLine("*******************************************************");
                    //int numberNote = ConsoleHelper.InputNumberNote(notebook.Count);
                    //ConsoleHelper.PrintOneNote(notebook, numberNote);
                    break;

                case "add":
                    //Console.Clear();
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("**               Добавление заметки                  **");
                    Console.WriteLine("*******************************************************");
                    //ConsoleHelper.AddNotes(ref notebook);
                    break;

                case "add auto":
                    Console.Write("Введите число вносимых элементов: ");
                    var amount = InputNumber();
                    Autocomplete(amount, ref repository); 
                    //notebook = ConsoleHelper.Autocomplete(amount, ref notebook);
                    Console.WriteLine("Данные успешно внесены");
                    break;

                case "quit":
                    quit = false;
                    if (ConsoleHelper.EnterYesNo("Хотите сохранить данные (Y/N):"))
                    {
                       // ConsoleHelper.WriteDataToFile(patch, notebook);
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

            return quit;
        }

        internal static void Init()
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("**                 ЕЖЕДНЕВНИК v0.0.1                 **");
            Console.WriteLine("**     Для получения списка команд введите /help     **");
            Console.WriteLine("*******************************************************");

            //string patch = "db.csv";
            //if (File.Exists(patch) == false)
            //{
            //    using (File.Create(patch)) { };
            //}
            //bool isFileEmpty = string.IsNullOrEmpty(File.ReadAllText(patch));

            //List<Note> notebook = new List<Note>();

            //if (!isFileEmpty)
            //{
            //    ConsoleHelper.ReadFileData(patch, ref notebook);
            //}

            
        }
        /// <summary>
        /// Метод ввода положительного числа
        /// </summary>
        /// <returns></returns>
        internal static int InputNumber()
        {
            int number;
            bool isCorrectParse;
            do
            {
                isCorrectParse = int.TryParse(Console.ReadLine(), out number);
                if (isCorrectParse == false && number < 0)
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                }
            } while (isCorrectParse == false && number < 0);

            return number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="repository"></param>
        public static void Autocomplete(int items, ref Repository repository)
        {

            var random = new Random();
            for (int i = 0; i < items; i++)
            {
                repository.Notes.Add(new Note("title" + random.Next(0, 10000000), "content" + random.Next(0, 10000000), ("creator" + (random.Next(0, 10000000) - i)), (Status)random.Next(1, 4)));
            }
            
        }
    }
}
