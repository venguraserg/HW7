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

        
        /// <summary>
        /// Метод ввода номер заметки
        /// </summary>
        /// <param name="amountNotes">размер списка заметок</param>
        /// <returns></returns>
        internal static int InputNumberNote(int amountNotes)
        {
            int number;
            bool isCorrectParse;
            do
            {
                isCorrectParse = int.TryParse(Console.ReadLine(), out number);
                if (isCorrectParse == false || (number < 1 || number > amountNotes))
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");

                }
            } while (isCorrectParse == false || (number<1|| number> amountNotes));
            return number-1;
        }
        
        
        
        /// <summary>
         /// Метод ввода номер заметки
         /// </summary>
         /// <param name="amountNotes">размер списка заметок</param>
         /// <returns></returns>
        internal static Status InputStatusNote()
        {
            Status status;
            bool isCorrectParse;
            do
            {
                Console.WriteLine($"Выберите статус 1 - Важная 2 - Актуальная 3 - Не важная");
                isCorrectParse = Status.TryParse(Console.ReadLine(), out status);
                if (isCorrectParse == false || (status < Status.Important || status > Status.NotRelevant))
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");

                }
            } while (isCorrectParse == false || (status < Status.Important || status > Status.NotRelevant));
            return status;
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
        /// <summary>
        /// Получение случайной строки
        /// </summary>
        /// <param name="сharacters">количество символов</param>
        /// <param name="r">Обьект класса Random</param>
        /// <returns></returns>
        public static string GetRandomString(int сharacters, Random r)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            
            //Random r = new Random();

            string text = string.Empty;

            for (int i = 0; i < сharacters; i++)
            {
                
                char a = letters[r.Next(0, 25)];
                text += a.ToString(); 
            }
            return text;
        }

    }
}
