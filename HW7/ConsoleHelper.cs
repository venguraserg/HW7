using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace HW7
{
    /// <summary>
    /// Статический класс обеспечивающий ввод/вывод через консоль
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Метод вывода всех записей в коротком, с заголовками без содержания
        /// </summary>
        internal static void PrintAllNotes(Repository repository)
        {
            if (repository.Notes.Count == 0)
            {
                Console.WriteLine("Записей нет");
            }
            else
            {
                Console.WriteLine("*******************************************************************");
                Console.WriteLine($"|  №  | Дата создания |     Заголовок    |  Создатель |   Статус   |");
                Console.WriteLine("*******************************************************************");

                for (var i = 0; i < repository.Notes.Count; i++)
                {
                    Console.WriteLine($"|{(i + 1),5}|{repository.Notes[i].CreateDate.ToShortDateString(),15}|{repository.Notes[i].Title,18}|{repository.Notes[i].Creator,12}|{repository.Notes[i].Status,12}|");
                }
            }
        }


        /// <summary>
        /// Метод вывода одной записи в развернутом виде
        /// </summary>
        internal static void PrintOneNote(Repository repository,int noteIndex)
        {
            if (repository.Notes.Count == 0)
            {
                Console.WriteLine("Записей нет");
            }
            else
            {

                Console.WriteLine($"Заметка  №: {(noteIndex + 1)}");
                Console.WriteLine($"Создана   : {repository.Notes[noteIndex].CreateDate.ToShortDateString()}");
                Console.WriteLine($"Статус    : {repository.Notes[noteIndex].Status}");
                Console.WriteLine($"Создатель : {repository.Notes[noteIndex].Creator}");
                Console.WriteLine($"Заголовок : {repository.Notes[noteIndex].Title}");
                Console.WriteLine("Текст Заметки:");
                Console.WriteLine($"{repository.Notes[noteIndex].Content}");

            }
        }

        /// <summary>
        /// Метод изменения записи
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="noteIndex"></param>
        internal static void UpdateNote(Repository repository ,int noteIndex)
        {
            DateTime createData = repository.Notes[noteIndex].CreateDate;
            string title = repository.Notes[noteIndex].Title;
            string content = repository.Notes[noteIndex].Content;
            Status status = repository.Notes[noteIndex].Status;
            string creator = repository.Notes[noteIndex].Creator;

            if (EnterYesNo("Желаете изменить заголовок? (Y/N)"))
            {
                Console.WriteLine("Введите новый заголовок");
                title = Console.ReadLine();
            }
            if (EnterYesNo("Желаете изменить текст заметки? (Y/N)"))
            {
                Console.WriteLine("Введите новый заголовок");
                content = Console.ReadLine();
            }
            if (EnterYesNo("Желаете изменить статус? (Y/N)"))
            {

                status = InputStatusNote();
            }
            repository.UpdateNote(new Note(createData, title, content, creator, status), noteIndex);
                        
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
        /// Серилизация в XML
        /// </summary>
        /// <param name="rep">репозиторий который серилизуем</param>
        /// <param name="path">путь к файлу</param>
        internal static void XmlSerializeRepository(Repository rep, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (Repository));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fStream, rep);
            fStream.Close();
        }

        /// <summary>
        /// Десерилизация из XML
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns></returns>
        internal static Repository XmlDeserializeRepository(string path)
        {
            Repository tempRepository = new Repository();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Repository));
            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            tempRepository = xmlSerializer.Deserialize(fStream) as Repository;
            fStream.Close();
            return tempRepository;
        }

        /// <summary>
        /// Серилизация в Json
        /// </summary>
        /// <param name="rep">репозиторий который серилизуем</param>
        /// <param name="path">путь к файлу</param>
        internal static void JsonSerializeRepository(Repository rep, string path)
        {
            string json = JsonConvert.SerializeObject(rep);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Десерилизация из json
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns></returns>
        internal static Repository JsonDeserializeRepository(string path)
        {
            Repository tempRepository = new Repository();

            string json = File.ReadAllText(path);
            tempRepository = JsonConvert.DeserializeObject<Repository>(json);
            
            return tempRepository;
        }

    }
}
