using System;
using GeekBrainsLib;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI consoleUI = new ConsoleUI("Мельников Александр", "Практическое задание №2", 7);
            
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();          
                consoleUI.PrintUserInfo();
                consoleUI.PrintMenu();

                int menuIndex = int.Parse(Console.ReadLine());
                switch (menuIndex)
                {
                    default:
                        break;
                    case 1:
                        {
                            Console.Clear();
                            Exercise1();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Exercise2();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Exercise3();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Exercise4();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Exercise5();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Exercise6();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Exercise7();
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            isWork = false;
                            break;
                        }
                }
            }
        }

        static void Exercise1()
        {
            Console.WriteLine("Нахождение минимального числа");
            Console.Write("Первое число: ");
            float num1 = float.Parse(Console.ReadLine());
            Console.Write("Второе число: ");
            float num2 = float.Parse(Console.ReadLine());
            Console.Write("Третье число: ");
            float num3 = float.Parse(Console.ReadLine());

            Console.WriteLine($"Минимальное число: {FindMin(new float[] { num1, num2, num3 })}");

            Console.ReadKey();
        }

        static void Exercise2()
        {
            Console.WriteLine("Подсчет количество цифр в числе");
            Console.Write("Введите число: ");

            int digit = int.Parse(Console.ReadLine());

            int count = 0;
            while (digit != 0)
            {
                digit /= 10;
                count++;
            }

            Console.WriteLine($"Количество цифр: {count}");
            Console.ReadKey();
        }

        static void Exercise3()
        {
            Console.WriteLine("Введите ниже числа");
            int num = int.Parse(Console.ReadLine());
            int numSum = 0;
            while (num != 0)
            {
                if (num % 2 != 0 && num > 0) numSum += num;
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Сумма нечетно-положительных числа равна: {numSum}");
            Console.ReadKey();
        }

        static void Exercise4()
        {
            int count = 3;
            do 
            {
                Console.WriteLine("Введите логи и пароль:");
                Console.Write("Логин:");
                string login = Console.ReadLine();
                Console.Write("Пароль:");
                string password = Console.ReadLine();
                if (Authentication((login, password)))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Доступ разрешен!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Неправельно введен логин или пароль!");
                Console.WriteLine($"Осталось {--count} попыток входа.");
                Console.ReadKey();
                Console.Clear();
            }
            while (count > 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Превышен лимит попыток. Доступ заблокирован!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        static void Exercise5()
        {
            Console.WriteLine("Расчет ИМТ");
            Console.Write("Вес: ");
            float weight = float.Parse(Console.ReadLine());
            Console.Write("Рост(см): ");
            float height = float.Parse(Console.ReadLine()) / 100;

            float bmi = GetBMI(weight, height);
            float reqWeight;
            Console.Clear();
            switch (bmi)
            {
                default:
                    break;
                case float n when (n >= 1 && n < 18.5):
                    {
                        Console.WriteLine("Ваш ИМТ = {0:f2}", n);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Недостаток веса!");
                        Console.ForegroundColor = ConsoleColor.White;

                        reqWeight = 18.5f * (float)Math.Pow(height, 2);
                        Console.WriteLine("Необходимо набрать {0:f2} кг.", reqWeight - weight);
                        break;
                    }
                case float n when (n >= 18.5 && n <= 25):
                    {
                        Console.WriteLine("Ваш ИМТ = {0:f2}", n);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Норма!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                case float n when (n > 25 && n <= 40):
                    {
                        Console.WriteLine("Ваш ИМТ = {0:f2}", n);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Избыточный вес!");
                        Console.ForegroundColor = ConsoleColor.White;

                        reqWeight = 25f * (float)Math.Pow(height, 2);
                        Console.WriteLine("Необходимо сбросить {0:f2} кг.",  weight - reqWeight);
                        break;
                    }
            }
            Console.ReadKey();
        }

        static void Exercise6()
        {
            Console.WriteLine("Подсчет хороших чисел");
            DateTime start = DateTime.Now;
            int count = 0;
            for(int i = 1; i < 1000000; i++)
            {
                if (IsGoodNumber(i))
                {
                    count++;
                }
            }
            Console.WriteLine($"Количество хороших числе в диапозоне 1 - 1000000: {count}");
            Console.WriteLine($"Затраченное время: {(DateTime.Now - start).Milliseconds} мс");
            Console.ReadKey();
        }
        
        static void Exercise7()
        {
            Console.Write($"Число а = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write($"Число b = ");
            int b = int.Parse(Console.ReadLine());
            WriteRange(a, b);
            Console.WriteLine($"Сумма чисел от {a} до {b} = {GetSumm(a, b)}");
            Console.ReadKey();
        }

        /// <summary>
        /// Нахождение минимального числа в массиве
        /// </summary>
        /// <param name="numMass"></param>
        /// <returns></returns>
        static float FindMin(float[] numMass)
        {
            float min = float.MaxValue;
            for (int i = 0; i < numMass.Length; i++)
            {
                if (numMass[i] < min) min = numMass[i];
            }
            return min;
        }

        /// <summary>
        /// Метод аутентификации
        /// </summary>
        /// <param name="newData"></param>
        /// <param name="rightData"></param>
        /// <returns></returns>
        static bool Authentication((string l, string p)newData)
        {
            string rightLogin = "root";
            string rightPass = "GeekBrains";

            if (newData.l != rightLogin)
            {
                return false;
            }
            else
            {
                if (newData.p != rightPass)
                {
                    return false;
                }            
            }

            return true;
        }

        /// <summary>
        /// Расчет ИМТ
        /// </summary>
        /// <param name="weight">вес</param>
        /// <param name="height">рост</param>
        /// <returns></returns>
        static float GetBMI(float weight, float height) => weight / (float)Math.Pow(height, 2);

        static bool IsGoodNumber(int n)
        {
            int summ = 0;
            int range = n;
            while (range != 0)
            {
                summ += range % 10;
                range /= 10;
            }   
            if (n % summ == 0)
                return true;

            return false;
        }


        static void WriteRange(int a, int b)
        {
            Console.WriteLine(a);
            if (a == b) return;
            WriteRange(++a, b);
        }

        static int GetSumm(int a, int b)
        {
            if (a == b) return b;
            return a += GetSumm(++a, b);
        }

    }
}
