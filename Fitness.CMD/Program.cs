using Fitness.BL.Controller;
using Fitness.BL.Model;
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
            var eatingController = new EatingController(userController.CurrentUser);
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
            Console.WriteLine("Что вы хотите сделать? нажмите Е-ввести прием пищи.");
            var key=Console.ReadKey();
            if (key.Key==ConsoleKey.E)
            {
                var foods=EatingEnter();
                eatingController.Add(foods.Item1, foods.Item2);
            }
            Console.ReadLine();
        }

        private static (Food, double) EatingEnter()
        {
            Console.WriteLine("Введите имя продукта");
          var food=  Console.ReadLine();

            var calories = ParseDouble("Калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");
            var product = new Food(food,proteins,fats,carbs,calories);
            return (product, weight);
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
                    Console.WriteLine("не праильный формат даты");
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
                    Console.WriteLine($"не праильный формат поля {name}");
                }
            }
        }
    }
}
