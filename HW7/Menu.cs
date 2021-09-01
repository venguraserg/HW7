using System;
using System.Linq;
using System.Collections.Generic;

namespace HW7
{
    public static class Menu
    {
        
        public static bool Start(ref Repository repository)
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
                    ConsoleHelper.PrintAllNotes(repository);
                    break;
                //кейс просмотра конкретной заявки
                case "view note":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                  Просмотр конкретной заметки                  **");
                    Console.WriteLine("*******************************************************************");
                    Console.Write(">Введите номер заметки: ");
                    int numberNote = ConsoleHelper.InputNumberNote(repository.Notes.Count);
                    ConsoleHelper.PrintOneNote(repository, numberNote);                    
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
                    ConsoleHelper.PrintOneNote(repository, numberNote);
                    ConsoleHelper.UpdateNote(repository,numberNote);
                    break;

                //кейс удаления заметки
                case "dell":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                        Удаление заметки                       **");
                    Console.WriteLine("*******************************************************************");
                    if(ConsoleHelper.EnterYesNo("Удалить по номеру? (Y/N)"))
                    {
                        Console.Write(">Введите номер заметки: ");
                        numberNote = ConsoleHelper.InputNumberNote(repository.Notes.Count);
                        ConsoleHelper.PrintOneNote(repository, numberNote);
                        repository.DeleteNote(numberNote);
                        Console.WriteLine("Заметка удалена . . .");
                    }
                    else
                    {
                        Console.WriteLine(">Выберите поле, по которому будем удалять запись");
                        Console.WriteLine("0 - по дате, 1 - по заголовку, 2 - по создателю, 3 - по статусу, Другой символ - Отмена: ");

                        var fildNumber = ConsoleHelper.FildSelection();
                        Console.WriteLine("*******************************************************************");
                        switch (fildNumber)
                        {
                            case 0:
                                Console.WriteLine("Удалим все заметки по определенной дате.");
                                var repDateDiapason = from note in repository.Notes
                                                      orderby note.CreateDate
                                                      select note.CreateDate;
                                                                
                                var tempDate = ConsoleHelper.InputDate(repDateDiapason.Min(), repDateDiapason.Max());

                                var tempRepos = repository.Notes.Where(i => i.CreateDate == tempDate).ToList<Note>();

                                repository = new Repository(repository.Notes.Except(tempRepos).ToList<Note>());
                                
                                break;
                            case 1:
                                Console.WriteLine("Удалим все заметки по заголовку.");
                                Console.Write("Введите заголовок заметки: ");
                                string tempTitle = Console.ReadLine();

                                tempRepos = repository.Notes.Where(i => i.Title == tempTitle).ToList<Note>();

                                if(tempRepos.Count==0)
                                {
                                    Console.WriteLine($"Заметки с заголовком {tempTitle} не найдена. . .");
                                }
                                else
                                {
                                    repository = new Repository(repository.Notes.Except(tempRepos).ToList<Note>());
                                }
                                break;

                            case 2:
                                Console.WriteLine("Удалим все заметки по имени создателя.");
                                Console.Write("Введите создателя заметки: ");
                                string tempCreator = Console.ReadLine();

                                tempRepos = repository.Notes.Where(i => i.Creator == tempCreator).ToList<Note>();

                                if (tempRepos.Count == 0)
                                {
                                    Console.WriteLine($"Создатель с именем {tempCreator} не найден. . .");
                                }
                                else
                                {
                                    repository = new Repository(repository.Notes.Except(tempRepos).ToList<Note>());
                                }
                                break;
                            case 3:
                                Console.WriteLine("Удалим все заметки по статусу.");
                                Console.Write("Введите статус заметки: ");
                                var tempStatus = ConsoleHelper.InputStatusNote();

                                tempRepos = repository.Notes.Where(i => i.Status == tempStatus).ToList<Note>();

                                if (tempRepos.Count == 0)
                                {
                                    Console.WriteLine($"Заметка со статусом {tempStatus} не найдена. . .");
                                }
                                else
                                {
                                    repository = new Repository(repository.Notes.Except(tempRepos).ToList<Note>());
                                }
                                break;

                            default:
                                break;
                        }
                        
                        //Console.ReadKey();
                        //ConsoleHelper.PrintAllNotes(repository);

                    }

                    break;

                    //кейс сортировки
                case "sort":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                    Сортировка всех заметки                    **");
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("Выберите столбец по которому нужно отсортировать");
                    Console.WriteLine("0 - по дате, 1 - по заголовку, 2 - по создателю, 3 - по статусу, Другой символ - отмена: ");

                    var numberField = ConsoleHelper.FildSelection();

                    repository.Notes = repository.SortRepository(numberField);

                    if (numberField >= 0 && numberField < 4)
                    {
                        ConsoleHelper.PrintAllNotes(repository);
                    }

                    break;

                //кейс удаления заметки
                case "dell all":
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                     Удаление всех заметки                     **");
                    Console.WriteLine("*******************************************************************");
                    
                    repository.DeleteAllNote();

                    Console.WriteLine("Все заметки удалены . . .");
                    break;

                //кейс автоматического добавления заметки
                case "clear":
                    Console.Clear();
                    break;

                //кейс сохранения данных в файл
                case "save":
                    ConsoleHelper.SaveData(repository);
                    Console.WriteLine("Данные успешно сохранены . . .");
                    break;

                //кейс "СПРАВКА"
                case "help":                    
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                         Cписок конманд:                       **");
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine(" - /help      - вывод списка команд");
                    Console.WriteLine(" - /view      - просмотр заметок");
                    Console.WriteLine(" - /view note - детальный просмотр заметки");
                    Console.WriteLine(" - /add       - добавить заметку");
                    Console.WriteLine(" - /add auto  - добавить заметки автоматически");
                    Console.WriteLine(" - /edit      - изменить заметку");
                    Console.WriteLine(" - /sort      - сортировка ежедневника");
                    Console.WriteLine(" - /save      - сохранить данные");
                    Console.WriteLine(" - /dell      - удалить заметку");
                    Console.WriteLine(" - /dell all  - удалить все заметки");
                    Console.WriteLine(" - /clear     - очистить экран");
                    Console.WriteLine(" - /quit      - выход из приложения");
                    break;

                    
                //кейс выхода из цикла
                case "quit":
                    quit = false;
                    ConsoleHelper.SaveData(repository);
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
