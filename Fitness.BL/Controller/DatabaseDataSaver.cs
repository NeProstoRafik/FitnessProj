﻿using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class DatabaseDataSaver: IDataSaver
    {          

        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnesContext())
            {
                var result = db.Set<T>().Where(k => true).ToList();
                return result;
            }
        }            

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnesContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();            
               
            }
        }
    }
}
