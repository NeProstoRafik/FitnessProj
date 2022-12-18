using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public double CaloriesPerMin { get; set; }

        public Activity()
        {

        }
        public Activity(string name, double caloriesPerMin)
        {
            //To Do проверка
            Name = name;
            CaloriesPerMin = caloriesPerMin;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
