namespace dz__21._10._23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //8.1
            BankAccount account1 = new BankAccount(1232321, 1962, BankType.Сберегательный);
            BankAccount account2 = new BankAccount(5166155, 500, BankType.Сберегательный);

            Console.WriteLine("Перед переводом:");
            Console.WriteLine($"Баланс первого аккаунта: {account1.GetAccountBalance()}");
            Console.WriteLine($"Баланс второго аккаунта: {account2.GetAccountBalance()}");

            decimal Amount = 500;
            account1.TransferMoney(account2, Amount);

            Console.WriteLine("\nПосле перевода: ");
            Console.WriteLine($"Баланс первого аккаунта:: {account1.GetAccountBalance()}");
            Console.WriteLine($"Баланс второго аккаунта: {account2.GetAccountBalance()}");

            Console.WriteLine("------------------------------------------------------------------------------------");
            //8.2 
            Console.WriteLine();
            Console.WriteLine("Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает\r\nстроку string, возвращает строку типа string, буквы в которой идут в обратном порядке.\r\nПротестировать метод.");
            Console.WriteLine();
            Console.WriteLine("Введите строку, состояющую ТОЛЬКО из букв: ");
            string str = Console.ReadLine();

            static bool IsOnlyLetters(string str) // проверка наличия букв
            {
                foreach (char c in str)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            static string Reverse(string str) // метод, который возвращает данную строку в обратном порядке
            {
                if (IsOnlyLetters(str))
                {
                    char[] chars = str.ToCharArray();
                    Array.Reverse(chars);
                    return new string(chars);
                }
                else
                {
                    Console.WriteLine("Введены не только буквы! Слово в обратном порядке не выводится..");
                    return str;
                }
            }
            Console.WriteLine(Reverse(str));
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine();

            // 8.3
            Console.WriteLine("Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. Если\r\nтакого файла не существует, то программа выдает пользователю сообщение и заканчивает\r\nработу, иначе в выходной файл записывается содержимое исходного файла, но заглавными\r\nбуквами.");
            Console.WriteLine("(если что заранее созданные файлы File1.txt и File2.txt)");
            Console.WriteLine();

            Console.WriteLine("Введите имя файла:");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не существует.");
                return;
            }

            else
            {
                Console.WriteLine("Введите имя выходного файла:");
                string outputFileName = Console.ReadLine();
                if (File.Exists(outputFileName))
                {

                    string content = File.ReadAllText(fileName);
                    string contentToUpper = content.ToUpper();
                    StreamWriter sw = new StreamWriter(outputFileName, true);
                    sw.WriteLine();
                    sw.WriteLine(contentToUpper);
                    sw.Close();
                    Console.WriteLine("Содержимое файла записано в выходной файл в заглавных буквах.");
                }
                else
                {
                    Console.WriteLine("Выходной файл не существует.");
                }
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------------");

            // 8.4
            Console.WriteLine("");
            Console.WriteLine("Введите что-либо: ");
            object input = Console.ReadLine();

            // is
            if (input is IFormattable)
            {
                Console.WriteLine("Входной параметр реализует интерфейс IFormattable.");
            }
            else
            {
                Console.WriteLine("Входной параметр не реализует интерфейс IFormattable.");
            }
            // as
            Console.WriteLine("Реализация с подходом as: ");
            object Input = input as IFormattable;
            if (Input != null)
            {
                Console.WriteLine("Входной параметр реализует интерфейс IFormattable.");
            }
            else
            {
                Console.WriteLine("Входной параметр не реализует интерфейс IFormattable.");
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine();

            // домашняя работа 8.1

            // извините, я не прочитала задание, решение реализовано полностью неправильно, поэтому можете
            // не читать код (если не хотите), так как он даже не работает((((
            using (StreamReader sr = new StreamReader("namesandemails.txt"))
            {
                string Content = sr.ReadToEnd();
                var people = new List<string>();
                string[] linesarray = Content.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
                );
                List<string> lines = linesarray.ToList<string>();

                List<string> Lines = new List<string>(); // список, куда мы будем добавлять email-ы

                char ch = '#';
                for (int line = 0; line < lines.Count; line++)
                {
                    int indexOfChar = lines[line].IndexOf(ch);
                    for (int i = 0; i < lines[line].Length; i++)
                    {
                        lines[line] = lines[line].Substring(indexOfChar + 1, lines[line].Length);
                    }
                    Lines.Add(lines[line]);

                }
                //
                using (StreamWriter tw = new StreamWriter("emails.txt"))
                {
                    foreach (string line in Lines)
                    {
                        tw.WriteLine(line);
                    }
                }
            }
        }
    }
}