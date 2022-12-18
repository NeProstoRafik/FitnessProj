using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        /// <summary>
        /// название продукта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// белки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// углеводы.
        /// </summary>
        public double Carbogydrates { get; set; }
        /// <summary>
        /// калории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; set; }

        //public double CaloriesOneGramm { get { return Calories / 100; } }
        //public double ProteinssOneGramm { get { return Proteins / 100; } }
        //public double FatsOneGramm { get { return Fats / 100; } }
        //public double CarbogydratesOneGramm { get { return Carbogydrates / 100; } }

        public Food(string name, double proteins, double fats, double carbogydrates, double calories)
        {
            Name = name;
            Proteins = proteins /100;
            Fats = fats/100;
            Carbogydrates = carbogydrates/100;
            Calories = calories/100;
        }
        public Food()
        {

        }
        public Food(string name) : this(name,0, 0, 0, 0)
        {
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
