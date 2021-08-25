using System;

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
                    var amount = ConsoleHelper.InputNumber();
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
                    repository.UpdateNote(numberNote);


                    //ConsoleHelper.InputStatusNote();

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
                        ConsoleHelper.SerializeRepository(repository, "xmlRep.xml");
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

        
        

       
    }
}
