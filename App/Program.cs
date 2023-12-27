using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace App
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Magenta;

            Write("Program is started");

            WhatDoYouWantToDo();

            ReadKey();
        }

        static void WhatDoYouWantToDo()
        {
            bool activ = true;
            string status = "";

            Write("\nWhat do you want to do?" +
                    "\n\nHi! We offer you key value:" +
                    "\ngame - guess the number" +
                    "\nequation - solving a quadric equation" +
                    "\ns - simple solving a quadric equation" +
                    "\ng - izi game guess the number" +
                    "\nf - factorial" +
                    "\nu - Ugadayka0for30" +
                    "\nr - Random Password For Number" +
                    "\num - Umnojenie" +
                    "\npsl - Password Security Level" +
                    "\nfg - Fio Generator" +
                    "\n\nGive me key value -> ");

            string key = ReadLine();

            while (activ == true)
            {

                if (status == "TheEnd")
                {
                    ForegroundColor = ConsoleColor.Magenta;
                    Write("\nIt's ok, what do you want to do now? Give me key value -> ");
                    key = ReadLine();
                    status = "";
                }


                switch (key)
                {
                    case "exit":
                        activ = false;
                        break;

                    case "s":
                        activ = Solution();
                        status = "TheEnd";
                        break;

                    case "g":
                        activ = IziGame(); 
                        status = "TheEnd";
                        break;

                    case "f":
                        Write("Введите число -> ");
                        string reading = ReadLine();
                        bool err = int.TryParse(reading, out int number);
                        if (err == false)
                        {
                            WriteLine("Некорректный ввод, перезапустите программу и повторите попытку");
                            status = "TheEnd";
                            break;
                        }
                        int result = Factorial(number);
                        WriteLine($"\nФакториал {number} = {result}"); 
                        status = "TheEnd";
                        break;

                    case "u":
                        Ugadayka0for30();
                        status = "TheEnd";
                        break;

                    case "r":
                        RandomPasswordForNumber();
                        status = "TheEnd";
                        break;

                    case "um":
                        Umnojenie();
                        status = "TheEnd";
                        break;

                    case "psl":
                        PasswordSecurityLevel();
                        status = "TheEnd";
                        break;

                    case "fg":
                        FioGenerator();
                        status = "TheEnd";
                        break;

                    case "equation":
                        activ = SolvingAQuadricEquation();
                        status = "TheEnd";
                        break;

                    case "game":
                        activ = Game();
                        status = "TheEnd";
                        break;

                    default:
                        Write("Sorry, I don't know this key, please repeat one -> ");
                        key = ReadLine();
                        break;
                }
            }

            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("\nOh my God! There is Imposible! See you later! Goodbuy!");
        }


        static bool Solution()
        {
            Write("Give a -> ");
            string numberA = ReadLine();
            bool err = double.TryParse(numberA, out double a);
            if (err == false || a == 0)
            {
                WriteLine("Invalid data");
                return false;
            }


            Write("Give b -> ");
            string numberB = ReadLine();
            bool _err = double.TryParse(numberB, out double b);
            if (err == false)
            {
                WriteLine("Invalid data");
                return false;
            }

            Write("Give c -> ");
            string numberC = ReadLine();
            bool __err = double.TryParse(numberC, out double c);
            if (err == false)
            {
                WriteLine("Invalid data");
                return false;
            }

            double disk = b * b - 4 * a * c;

            if (disk == 0)
            {
                double _cor = Math.Sqrt(disk);
                double _x1 = -b / (2 * a);

                WriteLine($"\nДискриминант: {disk}" +
                $"Дискриминант = 0, поэтому всего один корень:" +
                $"\nx1 = {_x1}" +
                $"\n\nTheEnd!");
                return true;
            }
            else if (disk < 0)
            {
                WriteLine("Дискриминант < 0, решений нет");
                return true;
            }

            double cor = Math.Sqrt(disk);
            double x1 = (-b + cor) / (2 * a);
            double x2 = (-b - cor) / (2 * a);

            WriteLine($"\nДискриминант: {disk}" +
                $"\nx1 = {x1}" +
                $"\nx2 = {x2}" +
                $"\n\nTheEnd!");

            return true;
        }

        static bool IziGame()
        {
            Random random = new Random();
            int secret = random.Next(0, 11);
            int attempt = 3;
            bool winned = false;
            for (int i = 1; i <= attempt; i ++)
            {
                Write($"\nПопытка номер {i}, введите число -> ");
                string reading = ReadLine();
                if (int.TryParse(reading, out int number))
                {
                    if (secret == number)
                    {
                        winned = true;
                        WriteLine("\nПоздравляю, вы выйграли!");
                        break;
                    }
                    else
                    {
                        WriteLine("Неверно");
                        continue;
                    }
                }
                else
                {
                    attempt++;
                    WriteLine("Некорректный ввод, я дам вам дополнительную попытку");
                    continue;
                }
            }

            if (winned == false)
            {
                WriteLine("Вы проиграли :(" +
                    $"\nСекретное число: {secret}");
            }

            return true;
        }


        static int Factorial(int number)
        {
            int result = 0;

            if (number == 0)
            {
                result = 1;
            }
            else
            {
                result = number * Factorial(number - 1);
            }

            return result;
        }











        static void Ugadayka0for30()
        {
            int[] randNumbers = GenerateRandom(50, 0, 30);

            Write("Введите числа через пробел -> ");
            string input = ReadLine();
            string[] inpNumbers = input.Split(' ');

            bool allInArray = true;

            foreach (string number in inpNumbers)
            {
                int parsNumber;
                if (int.TryParse(number, out parsNumber))
                {
                    if (!randNumbers.Contains(parsNumber))
                    {
                        allInArray = false;
                        break;
                    }
                }
                else
                {
                    allInArray = false;
                    break;
                }
            }

            if (allInArray) 
            {
                WriteLine("Все числа содержатся в массиве");
            }
            else
            {
                WriteLine("Не все числа содержатся в массиве");
            }
        }

        static int[] GenerateRandom(int length, int min, int max)
        {
            Random rand = new Random();
            int[] numbers = new int[length];

            for (int i = 0; i < length; i ++)
            {
                numbers[i] = rand.Next(min, max + 1);
            }

            return numbers;
        }











        static void RandomPasswordForNumber()
        {
            Write("Введите длину пароля -> ");
            string input = ReadLine();

            bool err = int.TryParse(input, out int number);
            if (err == false)
            {
                WriteLine("Некорректный ввод");
                return;
            }

            WriteLine(GeneratePassword(number)); 
        }

        static string GeneratePassword(int length)
        {
            string args = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789!@#$%^&*()_-+=";
            string resultPassword = "";

            Random rand = new Random();

            for (int i = 0; i < length; i ++)
            {
                int index = rand.Next(0, args.Length + 1);
                resultPassword += args[index];
            }

            return resultPassword;
        }








        static void Umnojenie()
        {
            Write("Введите число -> ");
            string inpNumber = ReadLine();
            bool err = int.TryParse(inpNumber, out int number);

            if (err == false)
            {
                WriteLine("Некорректный ввод");
                return;
            }

            WriteLine($"Таблица умножения на -> {number}:" +
                $"\n{number} x 1  = {number}" +
                $"\n{number} x 2  = {number * 2}" +
                $"\n{number} x 3  = {number * 3}" +
                $"\n{number} x 4  = {number * 4}" +
                $"\n{number} x 5  = {number * 5}" +
                $"\n{number} x 6  = {number * 6}" +
                $"\n{number} x 7  = {number * 7}" +
                $"\n{number} x 8  = {number * 8}" +
                $"\n{number} x 9  = {number * 9}" +
                $"\n{number} x 10 = {number * 10}");
        }






        static void PasswordSecurityLevel() 
        {
            Write("Введите ваш пароль -> ");
            string userPassword = ReadLine();

            int minLength = 8;

            bool specialChar = false;
            bool digit = false;
            bool upperCase = false;

            foreach (char c in userPassword) 
            { 
                if (!Char.IsLetterOrDigit(c))
                {
                    specialChar = true;
                }
                else if (Char.IsDigit(c)) 
                { 
                    digit = true;
                }
                else if (Char.IsUpper(c))
                {
                    upperCase = true;
                }
            }

            if (userPassword.Length > minLength && specialChar && digit && upperCase) 
            {
                WriteLine("У вас отличный пароль, так держать!");
            }
            else if (userPassword.Length > minLength && specialChar && digit || userPassword.Length > minLength && digit && upperCase || userPassword.Length > minLength && specialChar && upperCase)
            {
                WriteLine("Средний по сложности пароль, лучше придумайте новый");
            }
            else if (userPassword.Length > minLength && specialChar || userPassword.Length > minLength && digit || userPassword.Length > minLength && upperCase)
            {
                WriteLine("Слабый по сложности пароль, лучше придумайте новый");
            }
            else if (userPassword.Length > minLength)
            {
                WriteLine("ОЧЕНЬ слабый по сложности пароль, лучше придумайте новый");
            }
            else
            {
                WriteLine("Ну это уже совсем перебор, вы хотите чтобы вас взломали? Бегом переделывать пароль!");
            }
        }






        static void FioGenerator()
        {
            Write("Введите количество -> ");
            string input = ReadLine();

            bool err = int.TryParse(input, out int num);
            if (err == false)
            {
                WriteLine("Некорректный ввод");
                return;
            }

            string[] fi = { "Лермонтов", "Пушкин", "Анастасян", "Огонёв", "Распутин", "Лапухов" };
            string[] im = { "Александр", "Олег", "Топор", "Зевс", "Том", "Дин" };
            string[] ot = { "Олегович", "Александрович", "Алексеевич", "Генадьевич", "Дминтриевич", "Юрьевич" };


            Random rand = new Random();

            for (int i = 0; i < num; i++)
            {
                WriteLine(fi[rand.Next(0, 6)] + " " + im[rand.Next(0, 6)] + " " + ot[rand.Next(0, 6)]);
            }
        }



















        static bool Game()
        {
            bool game = true;
            bool result = true;

            while (game == true)
            {
                result = BodyGame();

                if (result == false)
                {
                    return result;
                }

                Write("\nSo... You have repiate? Give me 'yes' or 'no' -> ");
                string repiate = ReadLine();

                if (repiate == "no")
                {
                    game = false;
                }
                else if (repiate == "exit")
                {
                    game = false;
                    result = false;
                }
            }

            return result;
        }

        static bool BodyGame()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n------------------------------------------------------------------\nHello, my dear player! Welcome to game! \nI giving you 3 attepms from ges number 0 to 10, lucke! :)");


            Random random = new Random();
            int secret = random.Next(0, 11);
            int attempts = 3;
            bool winned = false;
            string userNumber;

            for (int i = 1; i <= attempts; i++)
            {
                Write($"\nAttempt {i}, give your number: ");
                userNumber = ReadLine();

                if (userNumber == "exit") return false;

                else if (int.TryParse(userNumber, out int number))
                {
                    if (number == secret)
                    {
                        winned = true;
                        WriteLine("\nYoure winned!\n------------------------------------------------------------------");
                        break;
                    }
                    else
                    {
                        WriteLine("Invalid number");
                    }
                }
                else
                {
                    attempts++;
                    WriteLine("Invalid data, I give you one bonus attempt, because youre so stuped :(");
                }
            }

            if (winned == false)
            {
                WriteLine($"\nYou are looser! Secret number: {secret}\n------------------------------------------------------------------");
            }

            return true;
        }


        static bool SolvingAQuadricEquation()
        {
            ForegroundColor = ConsoleColor.Cyan;

            bool flag = true;
            bool result = true;

            while (flag == true)
            {
                result = BodySolvingAQuadricEquation();

                if (result == false) return result;

                Write("\nSo... You have repiate? Give me 'yes' or 'no' -> ");
                string repiate = ReadLine();

                if (repiate == "no")
                {
                    flag = false;
                }
                else if (repiate == "exit")
                {
                    flag = false;
                    result = false;
                }
            }

            return result;
        }


        static bool BodySolvingAQuadricEquation()
        {
            int value = 1;
            int attempt = 3;

            double a = 0;
            double b = 0;
            double c = 0;

            WriteLine("\n\nHello, my dear user! Welcome to Solving A Quadric Equation!");

            for (int i = 0; i < attempt; i++)
            {
                if (value == 1)
                {
                    while (true)
                    {
                        Write("\nGive me number a -> ");
                        string numberA = ReadLine();
                        if (numberA == "exit") return false;
                        else if (double.TryParse(numberA, out a))
                        {
                            if (a == 0)
                            {
                                WriteLine("Invalid data, I give you one bonus attempt, because youre so stuped :(");
                                attempt++;
                                continue;
                            }

                            value += 1;
                            break;
                        }
                        else
                        {
                            WriteLine("Invalid data, I give you one bonus attempt, because youre so stuped :(");
                            attempt++;
                            continue;
                        }
                    }
                }
                else if (value == 2)
                {
                    while (true)
                    {
                        Write("\nGive me number b -> ");
                        string numberB = ReadLine();
                        if (numberB == "exit") return false;
                        else if (double.TryParse(numberB, out b))
                        {
                            value += 1;
                            break;
                        }
                        else
                        {
                            WriteLine("Invalid data, I give you one bonus attempt, because youre so stuped :(");
                            attempt++;
                            continue;
                        }

                    }
                }
                else if (value == 3)
                {
                    while (true)
                    {
                        Write("\nGive me number c -> ");
                        string numberC = ReadLine();
                        if (numberC == "exit") return false;
                        else if (double.TryParse(numberC, out c))
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("Invalid data, I give you one bonus attempt, because youre so stuped :(");
                            attempt++;
                            continue;
                        }

                    }
                    break;
                }
            }

            double form = b * b - 4 * a * c;

            if (form == 0)
            {
                double disk = Math.Sqrt(form);
                double x1 = -b / (2 * a);

                WriteLine("\nSo, now it's time to calculate the discriminant!" +
                    "\n\nThe discriminant is 0 we will only get one solution" +
                    "\nFor this we let's do the following: b^2 - 4 * a * c" +
                    $"\nWe get: {b}^2 - 4 * {a} * {c} = {form}" +
                    $"\nx1 = {x1}");
            }
            else if (form < 0)
            {
                 WriteLine("Discriminant negative - no solutions :(");
            } 
            else
            {
                double disk = Math.Sqrt(form);
                double x1 = (-b + disk) / (2 * a);
                double x2 = (-b - disk) / (2 * a);

                WriteLine("\n\nSo, now it's time to calculate the discriminant!" +
                    "\nFor this we let's do the following: b^2 - 4 * a * c" +
                    $"\nWe get: {b}^2 - 4 * {a} * {c} = {form}" +
                    $"\nx1 = {x1}" +
                    $"\nx2 = {x2}");
            }

            return true;
        }
    }
}
