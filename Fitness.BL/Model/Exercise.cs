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
        public DateTime Star { get; }
        public DateTime Finis { get; }
        public Activity Activity { get; }
        public User User { get; }

        public Exercise(DateTime star, DateTime finis, Activity activity, User user)
        {
            // првоерку сделать
            Star = star;
            Finis = finis;
            Activity = activity;
            User = user;
        }
    }
}
