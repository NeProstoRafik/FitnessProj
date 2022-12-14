using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветсвует приложение для фитнеса");
            Console.WriteLine("Введите свое имя");
            var name=Console.ReadLine();

            

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();

                DateTime birthDay= ParseDateTime();               

                Console.WriteLine("Введите ваш вес");
                var weight = ParseDouble("вес");

                Console.WriteLine("Введите ваш рост");
                var height = ParseDouble("рост");


                userController.SetUserData(gender, birthDay, weight, height);

            }
            Console.WriteLine(userController);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDay;
            while (true)
            {
                Console.WriteLine("Введите дату рождения день.месяц.год.");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("не праильнвй формат даты");
                }
            }

            return birthDay;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите :{name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"не праильнвй {name}");
                }
            }
        }
    }
}
