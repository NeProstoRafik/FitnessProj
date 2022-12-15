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
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser { get; }=false;
        /// <summary>
        /// Создание нового контроллера.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
           
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("Имя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser==null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save(); 
            }          
            
        }
        /// <summary>
        /// Получить сохраннеый список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData() 
        {
           return base.Load<List<User>>("users.dat") ?? new List<User>();
           
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        /// 

        public void SetUserData(string genderName, DateTime birthDate, double userWeight, double userHeight)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weigth=userWeight;
            CurrentUser.Height = userHeight;
            Save();
        }
        public void Save()
        {
            base.Save("users.dat", Users);
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        /// <exception cref="FileLoadException"></exception>
        /// 

        
        
    }
}
