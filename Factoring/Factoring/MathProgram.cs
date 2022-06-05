using System;

namespace Factoring
{
    class MathProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!\nЭта программа находит факториал числа,\nсумму всех чисел и максимальное чётное число до Вашего числа!");
            while (true)
            {
                try
                {
                    Intersect();
                    Console.WriteLine("Пожалуйста введите целое число... ");
                    Intersect();

                    int N = Convert.ToInt32(Console.ReadLine());

                    FindNFactorial(N);
                    FindSumToN(N);
                    FindMaxToN(N);

                    Console.WriteLine("Благодарим за использование...\nДо свидания! ");
                    Console.ReadLine();
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильный ввод...\n");
                }
            }//cycle
        }

        //Методы
        static void Intersect()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
        }
        static int FindNFactorial(int N)
        {
            int result = 1;
            for (int i = 1; i <= N; i++) result = result * i;
            Console.WriteLine($"Факториал числа {N} равен: " + result);
            return result;
            
        }
        static int FindSumToN(int N)
        {
            int result = 0;
            for (int i = 1; i <= N; i++) result = result + i;
            Console.WriteLine($"Сума всех чисел от 1 до {N} равна: " + result);
            return result;
        }
        static int FindMaxToN(int N)
        {
            int result = 0;
            for (int i = 1; i <= N; i++)
            {
                if (i % 2 == 0) result = i;
            }
            Console.WriteLine($"Максимальное четное число меньше {N} равно: " + result);
            return result;
        }
    }//class

}//namespace
