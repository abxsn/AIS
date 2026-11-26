using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    static class ValidatedConsoleInput
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prompt">Выводимая методом строка</param>
        /// <param name="validValues">значение необходимые для возвращения значения</param>
        /// <returns>преобразованное в int изначальное значение</returns>
        public static int ValidateInt(string prompt, List<int> validValues)
        {
            while(true)
            {
                Console.WriteLine(prompt);
                if(int.TryParse(Console.ReadLine(), out int a) && validValues.Contains(a))
                {
                    return a;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prompt">Выводимая методом строка</param>
        /// <param name="min">Минимальное значение необходимое для возвращения значения</param>
        /// <param name="max">Максимальное значение необходимое для возвращения значения</param>
        /// <returns>преобразованное в int изначальное значение</returns>
        public static int ValidateInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int a) && a >= min && a <= max)
                {
                    return a;
                }
            }
        }
    }
}
