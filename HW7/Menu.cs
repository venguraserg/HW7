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
                // кейс просмотра всех заметок
                case "view":
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("**                        Просмотр заметок                       **");
                Console.WriteLine("*******************************************************************");
                    repository.PrintAllNotes();
                    break;
                //кейс просмотра конкретной заявки
                case "view note":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                  Просмотр конкретной заметки                  **");
                    Console.WriteLine("*******************************************************************");
                    Console.Write(">Введите номер заметки: ");
                    int numberNote = ConsoleHelper.InputNumberNote(repository.Notes.Count);
                    repository.PrintOneNote(numberNote);                    
                    break;
                //кейс добавления заметки
                case "add":                    
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                       Добавление заметки                      **");
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("Введите название заметки:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Введите вашу заметку:");
                    string content = Console.ReadLine();
                    Console.WriteLine("Введите создателя заметки:");
                    string creator = Console.ReadLine();
                    Console.WriteLine($"Выберите статус 1 - Важная 2 - Актуальная 3 - Не важная");
                    string status = Console.ReadLine();

                    repository.AddNote(title, content, creator, (Status)int.Parse(status));
                    
                    Console.WriteLine("Заявка внесена . . .");
                    break;
                //кейс автоматического добавления заметки
                case "add auto":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**               Автоматическое заполнение репозитория           **");
                    Console.WriteLine("*******************************************************************");
                    Console.Write("Введите число вносимых элементов: ");
                    var amount = InputNumber();
                    repository.AutocompliteRepository(amount);
                    Console.WriteLine("Данные успешно внесены");
                    break;
                //кейс редактирования заметки
                case "edit":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                     Редактирование заметки                    **");
                    Console.WriteLine("*******************************************************************");
                    Console.Write(">Введите номер заметки: ");
                    numberNote = ConsoleHelper.InputNumberNote(repository.Notes.Count);
                    repository.PrintOneNote(numberNote);
                    ConsoleHelper.InputStatusNote();

                    break;
                //кейс удаления заметки
                case "del":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                        Удаление заметки                       **");
                    Console.WriteLine("*******************************************************************");
                    Console.Write(">Введите номер заметки: ");
                    numberNote = ConsoleHelper.InputNumberNote(repository.Notes.Count);
                    repository.PrintOneNote(numberNote);
                    repository.DeleteNote(numberNote);
                    Console.WriteLine("Заметка удалена . . .");
                    break;

                //кейс автоматического добавления заметки
                case "clear":
                    Console.Clear();
                    break;


                //кейс "СПРАВКА"
                case "help":                    
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("**                  Cписок конманд:                  **");
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine(" - /help      - вывод списка команд");
                    Console.WriteLine(" - /view      - просмотр заметок");
                    Console.WriteLine(" - /view note - детальный просмотр заметки");
                    Console.WriteLine(" - /add       - добавить заметку");
                    Console.WriteLine(" - /add auto  - добавить заметки автоматически");
                    Console.WriteLine(" - /edit      - изменить заметку");
                    Console.WriteLine(" - /del       - удалить заметку");
                    Console.WriteLine(" - /clear     - очистить экран");


                    Console.WriteLine(" - /quit      - выход из приложения");
                    break;

                //кейс выхода из цикла
                case "quit":
                    quit = false;
                    if (ConsoleHelper.EnterYesNo("Хотите сохранить данные (Y/N):"))
                    {
                        // ConsoleHelper.WriteDataToFile(patch, notebook);
                    }
                    Console.WriteLine("");
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
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("**                       ЕЖЕДНЕВНИК v0.0.1                       **");
            Console.WriteLine("**           Для получения списка команд введите /help           **");
            Console.WriteLine("*******************************************************************");

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

       
    }
}
