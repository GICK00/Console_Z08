using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Console_Z08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("| Находение максимального числа.");
            bool repit = true;
            while (repit == true)
            {
                try
                {
                    Console.WriteLine("| Введите строку которую нужно прочитать.");
                    Console.Write("| : ");
                    StringBuilder str = new(Convert.ToString(Console.ReadLine()));
                    Console.WriteLine("|-------------------------------------------------");
                    if (str.Length == 0)
                        throw new Exception("Строка должна содержать хотябы 1 символ!");

                    max(str);
                    rep(out repit);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"| {e.Message}");
                    rep(out repit);
                }
            }
        }
        static void max(StringBuilder str)
        {
            int max = 0;
            Regex reg = new(@"(?<!\d+)-?\d+");
            MatchCollection maxNum = reg.Matches(str.ToString());
            foreach(Match match in maxNum)
            {
                if (int.Parse(match.Value) > max)
                {
                    max = int.Parse(match.Value);
                }
            }
            Console.WriteLine("| Максимально число в строке: {0}", max);
        }
        static void rep(out bool repit)
        {
            Console.WriteLine("| Попробовать снова? Да / Нет");
            Console.Write("| : ");
            string repitTxT = Convert.ToString(Console.ReadLine());

            if (repitTxT == "Да")
            {
                repit = true;
                Console.WriteLine("|-------------------------------------------------");
            }
            else if (repitTxT == "Нет")
                repit = false;
            else
            {
                Console.WriteLine("|-------------------------------------------------");
                Console.WriteLine("| Некорректный ввод данных!");
                repit = false;
            }
        }
    }
}
