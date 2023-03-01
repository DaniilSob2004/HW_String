using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  Необходимо проверить, является ли строка палиндромом

            /*Console.Write("Input any string: ");
            string userStr = Console.ReadLine();

            if (IsStrPalindrome(userStr))
            {
                Console.WriteLine($"Your str: \"{userStr}\" is palindrome!!!");
            }
            else
            {
                Console.WriteLine($"Your str: \"{userStr}\" is`t palindrome...");
            }*/

            #endregion

            #region  Подсчитывать количество слов, гласных и согласных букв в строке, введёной пользователем. Дополнительно выводить количество знаков пунктуации, цифр и др. символов

            Console.Write("Введите любую строку: ");
            string userStr = Console.ReadLine().Trim().ToLower();

            // для подсчёта слов удаляем лишние символы и пробелы
            StringBuilder userStrCopy = new StringBuilder(userStr);
            userStrCopy.Replace(",", "").Replace("!", "").Replace("?", "").Replace(".", "").Replace("-", "").Replace("  ", " ");

            char[] vowelsLetters = new char[] { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            char[] consonantsLetters = new char[] { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
            int nVowelsLetter = 0, nConsLetter = 0, nPunctSymbol = 0, nDigit = 0, nAnotherSymbol = 0;

            foreach (char ch in userStr)
            {
                if (char.IsLetter(ch) && vowelsLetters.Contains(ch))
                {
                    nVowelsLetter++;
                }
                if (char.IsLetter(ch) && consonantsLetters.Contains(ch))
                {
                    nConsLetter++;
                }
                if (char.IsPunctuation(ch))
                {
                    nPunctSymbol++;
                }
                if (char.IsDigit(ch))
                {
                    nDigit++;
                }
                if (!char.IsDigit(ch) && !char.IsLetter(ch) && !char.IsPunctuation(ch))
                {
                    nAnotherSymbol++;
                }
            }

            Console.WriteLine($"Всего символов - {userStr.Length}");
            Console.WriteLine($"Слов - {userStrCopy.ToString().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Length}");
            Console.WriteLine($"Гласных - {nVowelsLetter}");
            Console.WriteLine($"Согласных - {nConsLetter}");
            Console.WriteLine($"Знаков пунктуации - {nPunctSymbol}");
            Console.WriteLine($"Цифр - {nDigit}");
            Console.WriteLine($"Др. символов - {nAnotherSymbol}");

            #endregion

            #region  Является ли одна строка анаграммой для другой строки

            /*Console.Write("Input first string: ");
            string userStr = Console.ReadLine();
            Console.Write("Input second string: ");
            string userStr2 = Console.ReadLine();

            if (IsStrAnagram(userStr, userStr2))
            {
                Console.WriteLine("Is anagram!!!");
            }
            else
            {
                Console.WriteLine("Is`t anagram...");
            }*/

            #endregion
        }

        // метод проверяет строку на палиндром
        static bool IsStrPalindrome(string str)
        {
            // создём объект StringBuilder, чтобы при вызове метода Replace() не возвращалась постоянно копия объекта string
            StringBuilder sb = new StringBuilder(str.Trim().ToLower());
            sb.Replace(" ", "").Replace(",", "").Replace("-", "").Replace("!", "");
            string newStr = new string(sb.ToString().Reverse().ToArray());

            return (sb.ToString() == newStr);
        }

        // метод проверяет строку на анаграмой
        static bool IsStrAnagram(string str1, string str2)
        {
            // создём объект StringBuilder, чтобы при вызове метода Replace() не возвращалась постоянно копия объекта string
            StringBuilder sb1 = new StringBuilder(str1.Trim().ToLower());
            sb1.Replace(" ", "").Replace("-", "").Replace("!", "").Replace("?", "").Replace(",", "").Replace(".", "");

            StringBuilder sb2 = new StringBuilder(str2.Trim().ToLower());
            sb2.Replace(" ", "").Replace("-", "").Replace("!", "").Replace("?", "").Replace(",", "").Replace(".", "");

            if (sb1.Length != sb2.Length) return false;

            // преобразовываем в массив и сортируем
            char[] arr1 = sb1.ToString().ToArray();
            Array.Sort(arr1);
            char[] arr2 = sb2.ToString().ToArray();
            Array.Sort(arr2);

            // сравниваем два отсортированных массива
            return (arr1.SequenceEqual(arr2));
        }
    }
}
