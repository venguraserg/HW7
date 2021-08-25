using System;
using System.IO;

namespace HW7
{
    class Init
    {
        internal static void Initialization(ref Repository repository)
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("**                       ЕЖЕДНЕВНИК v0.0.1                       **");
            Console.WriteLine("**           Для получения списка команд введите /help           **");
            Console.WriteLine("*******************************************************************");

            string patch = "xmlRep.xml";
            if (File.Exists(patch) == false)
            {
                using (File.Create(patch)) { };
            }
            bool isFileEmpty = string.IsNullOrEmpty(File.ReadAllText(patch));

            if (!isFileEmpty)
            {
                repository = ConsoleHelper.DeserializeRepository(patch);
            }
            else 
            {
                if (ConsoleHelper.EnterYesNo("Ежедневник пуст, желаете заполнить случайными значениями (Y/N)"))
                {
                    Console.Write("Введите количество элементов списка: ");
                    repository.AutocompliteRepository(ConsoleHelper.InputNumber());
                }
            }


        }
    }
}
