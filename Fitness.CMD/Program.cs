using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resurceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            // Console.WriteLine(Languages.Messages.Hello); без менеджера ресурсов
            // Console.WriteLine(Languages.Messages.EnterName);
            Console.WriteLine(resurceManager.GetString("Hello"), culture);
            Console.WriteLine(resurceManager.GetString("EnterName"), culture) ;
            var name=Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();

                DateTime birthDay= ParseDateTime("введите дату рождения");               

                Console.WriteLine("Введите ваш вес");
                var weight = ParseDouble("вес");

                Console.WriteLine("Введите ваш рост");
                var height = ParseDouble("рост");


                userController.SetNewUserData(gender, birthDay, weight, height);

            }
            Console.WriteLine(userController);
           
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать? нажмите Е-ввести прием пищи.");
                Console.WriteLine("введите А- что бы добавить упраденние");
                Console.WriteLine("введите Q- что бы выйти");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EatingEnter();
                        eatingController.Add(foods.Item1, foods.Item2);
                        break;
                    case ConsoleKey.A:
                        var exe =EnterExerxise();
                       
                        exerciseController.Add(exe.activity, exe.begin, exe.end);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} c {item.Star.ToShortTimeString()} до {item.Finis.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
           
            
            
        }

        private static (DateTime begin, DateTime end, Activity activity) EnterExerxise()
        {
            Console.WriteLine("Введите упражнение");
            var name=Console.ReadLine();
            var energy = ParseDouble("расход энергии");
            var begin = ParseDateTime("начала упраженния");
            var end = ParseDateTime("окончание упраженния");
            var activity = new Activity(name, energy);
            return (begin,end,activity);
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

        private static DateTime ParseDateTime(string item)
        {
            DateTime birthDay;
            while (true)
            {
                Console.WriteLine($"Введите {item}день.месяц.год.");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("не правильный формат даты");
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
