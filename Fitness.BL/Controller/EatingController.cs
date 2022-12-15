using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class EatingController :ControllerBase
    {
        private const string FOOD_FILE_NAME = "Foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private User user { get; }

        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
     
        public void Add(Food food, double weight)
        {
            var product = Foods.FirstOrDefault(f => f.Name == food.Name);
            if (product==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return base.Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return base.Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }
        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
