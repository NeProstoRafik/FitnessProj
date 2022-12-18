using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Star { get; set; }
        public DateTime Finis { get; set; }
        public  virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public Exercise(DateTime star, DateTime finis, Activity activity, User user)
        {
            // првоерку сделать
            Star = star;
            Finis = finis;
            Activity = activity;
            User = user;
        }
        public Exercise()
        {

        }
    }
}
