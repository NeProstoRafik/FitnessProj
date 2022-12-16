using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISE_FILE_NAME = "exercise.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private User user;
        public List<Exercise> ExerciseList { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            this.ExerciseList = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return base.Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();

        }

        public void Add(Activity activity, DateTime begin, DateTime end )
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act==null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                ExerciseList.Add(exercise);

            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                ExerciseList.Add(exercise);
            }

            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return base.Load<List<Exercise>>(EXERCISE_FILE_NAME) ?? new List<Exercise>();
        }
        private void Save()
        {
            Save(EXERCISE_FILE_NAME, ExerciseList);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
