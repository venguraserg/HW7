using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public static class ConsoleHelper
    {
        

        
        public static List<Note> Autocomplete(int items, ref List<Note> notebook)
        {
            
            var random = new Random();
            for (int i = 0; i < items; i++)
            {
                notebook.Add(new Note("title" + random.Next(0, 10000000), "content" + random.Next(0, 10000000), ("creator" + (random.Next(0, 10000000) - i)), (Status)random.Next(1, 4)));
            }
            return notebook;
        }

        public static void PrintNotes(List<Note> notebook)
        {
            if (notebook.Count == 0)
            {
                Console.WriteLine("Записей нет");
            }
            else
            {
                Console.WriteLine("**********************************************************************************");
                Console.WriteLine($"  №     CreateTime            Content            Creator      Status");
                Console.WriteLine("**********************************************************************************");

                for (var i=0; i<notebook.Count();i++)
                {
                    Console.WriteLine($"{(i+1),5}   {notebook[i].CreateDate.ToLongDateString(),3}   {notebook[i].Title,-5}   {notebook[i].Creator,-5}   {notebook[i].Status,-5}");
                }
            }
            
        }
        public static List<Note> ReadFileData(string patch, ref List<Note> dataFromFile)
        {
            var fileText = File.ReadAllLines(patch);
            char[] charSeparator = new char[] { ',' };
            

            for (var i = 0; i < fileText.Length; i++)
            {

                var item = fileText[i].Split(charSeparator);
                Note newNote = new Note(DateTime.Parse(item[0]), item[1], item[2], item[3],(Status)int.Parse(item[4]));

                dataFromFile.Add(newNote);
            }

            return dataFromFile;
        }
        public static void WriteDataToFile(string patch, List<Note> notebook)
        {
            using (StreamWriter sw = new StreamWriter(patch))
            {
                Note writeNote = new Note();
                for (int i = 0; i < notebook.Count; i++)
                {
                    writeNote = notebook[i];
                    sw.WriteLine($"{writeNote.CreateDate.Date},{writeNote.Title},{writeNote.Content},{writeNote.Creator},{(int)writeNote.Status}");
                }
            }
        }

        internal static void PrintOneNote(List<Note> notebook, int numberNote)
        {
            Console.WriteLine("Название заметки  :" + notebook[numberNote].Title);
            Console.WriteLine("Дата создания     :" + notebook[numberNote].CreateDate);
            Console.WriteLine("Создатель         :" + notebook[numberNote].Creator);
            Console.WriteLine("Статус            :" + notebook[numberNote].Status);
            Console.WriteLine("Содержание заметки:" + notebook[numberNote].Content);
        }

        internal static int InputNumberNote(int amountNotes)
        {
            int number;
            bool isCorrectParse;
            do
            {
                isCorrectParse = int.TryParse(Console.ReadLine(), out number);
                if (isCorrectParse == false && (number < 0 || number > amountNotes))
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");

                }
            } while (isCorrectParse == false && (number<0|| number> amountNotes));
            return number;
        }

        internal static int InputNumber()
        {
            int number;
            bool isCorrectParse;
            do
            {
                isCorrectParse = int.TryParse(Console.ReadLine(), out number);
                if (isCorrectParse == false && number < 0 )
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                }
            } while (isCorrectParse == false && number < 0 );
            return number;
        }

        internal static void AddNotes(ref List<Note> notebook)
        {
            Console.WriteLine("Введите название заметки:");
            string title = Console.ReadLine();
            Console.WriteLine("Введите вашу заметку:");
            string content = Console.ReadLine();
            Console.WriteLine("Введите создателя заметки:");
            string creator = Console.ReadLine();
            Console.WriteLine($"Выберите статус 1 - Важная 2 - Актуальная 3 - Не важная");
            string status = Console.ReadLine();

            Note newNote = new Note(title,content, creator, (Status)int.Parse(status));
            notebook.Add(newNote);
            Console.WriteLine("Заявка внесена . . .");
        }

        /// <summary>
        /// Метод ввода Да/Нет
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool EnterYesNo(string text)
        {
            if (text != "") Console.WriteLine(text);
            char yn;
            bool correctParse, result = false;
            do
            {
                correctParse = char.TryParse(Console.ReadLine(), out yn);
                if (!(yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y'))
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                }
            } while (!(correctParse && (yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y')));

            if (yn == 'y' || yn == 'Y')
            {
                result = true;
            }
            else if (yn == 'n' || yn == 'N')
            {
                result = false;
            }
            return result;
        }
    }
}
