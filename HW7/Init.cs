﻿using System;
using System.IO;

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
