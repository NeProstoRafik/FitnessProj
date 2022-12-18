using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
               throw new ArgumentNullException("Не может быть пустым или налл", nameof(name));
            }
            Name = name;
        }
        public Gender()
        {

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
