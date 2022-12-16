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
        public string Name { get; }
        public double CaloriesPerMin { get;  }

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
