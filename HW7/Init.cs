using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW7
{
    class Init
    {
        internal static void Initialization(ref Repository repository)
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("**                       ЕЖЕДНЕВНИК v0.0.1                       **");
            Console.WriteLine("**                         Инициализация                         **");
            Console.WriteLine("*******************************************************************");
            string patchXml = "xmlRep.xml";
            string patchJson = "jsonRep.json";

            Console.WriteLine("Чтобы работать с ЕЖЕДНЕВНИКОМ определите тип файла, где будут зранится данные");
            Console.WriteLine("Мы можем работать с XML и JSON");

            string patch = ConsoleHelper.EnterYesNo("Хотите выбрать XML (Y/N)") ? patchXml : patchJson;
                     

            
            if (File.Exists(patch) == false)
            {
                using (File.Create(patch)) { };
            }
            bool isFileEmpty = string.IsNullOrEmpty(File.ReadAllText(patch));

            if (!isFileEmpty)
            {
                switch (patch)
                {
                    case "xmlRep.xml":
                        repository = ConsoleHelper.XmlDeserializeRepository(patch);
                        break;
                    case "jsonRep.json":
                        repository = ConsoleHelper.JsonDeserializeRepository("jsonRep.json");
                        break;
                }

                if(!ConsoleHelper.EnterYesNo("Загрузить ВСЕ записи (Y/N)"))
                {
                    Console.WriteLine("Загрузим по диапазону дат.");
                    var temp1 = from note in repository.Notes
                             orderby note.CreateDate
                             select note.CreateDate;

                    var minDateRepos = temp1.Min();
                    var maxDateRepos = temp1.Max();
                    Console.WriteLine($"В ежедневнике записи с {minDateRepos.ToShortDateString()}по {maxDateRepos.ToShortDateString()}");
                    Console.WriteLine("Введите даты из этого диапазона");
                    Console.WriteLine("Введите начало диапазона: ");
                    var minDate = ConsoleHelper.InputDate(minDateRepos, maxDateRepos);
                    Console.WriteLine("Введите конец диапазона: ");
                    var maxDate = ConsoleHelper.InputDate(minDateRepos, maxDateRepos);

                    var tempRepo = from note in repository.Notes
                                   where note.CreateDate > minDate
                                   where note.CreateDate < maxDate
                                   select note;


                    List<Note> tempNotes = new List<Note>();

                    foreach (var i in tempRepo)
                    {
                        tempNotes.Add(i);
                    }

                    repository = new Repository(tempNotes);


                    //Console.ReadKey();
                }
                
               

            }
            else 
            {
                if (ConsoleHelper.EnterYesNo("Ежедневник пуст, желаете заполнить случайными значениями (Y/N)"))
                {
                    Console.Write("Введите количество элементов списка: ");
                    repository.AutocompliteRepository(ConsoleHelper.InputNumber());
                }
            }




            Console.Clear();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("**                       ЕЖЕДНЕВНИК v0.0.1                       **");
            Console.WriteLine("**           Для получения списка команд введите /help           **");
            Console.WriteLine("*******************************************************************");

        }
    }
}
