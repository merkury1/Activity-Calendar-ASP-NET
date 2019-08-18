using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Models;
using ToDoList.Core.Repositories;

namespace ToDoList.Infrastracture.Repositories
{
    public class SQLActivityRepository : IActivityRepository
    {
        private readonly ToDoListDBContext db;

        public SQLActivityRepository(ToDoListDBContext db)
        {
            this.db = db;
        }
        public void Add(Activity activity)
        {
            db.Add(activity);
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Delete(int activityId)
        {
            Activity activityToRemove = Get(activityId);
            if (activityToRemove != null)
            {
                db.Activities.Remove(activityToRemove);
            }
        }

        public Activity Get(int activityId)
        {
            return db.Activities.Find(activityId);
        }

        public IEnumerable<Activity> GetAllActivitiesForPage(int page, int pageSize)
        {
            return db.Activities
                .OrderBy(a => a.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Activity> GetActiveActivitiesForPage(int page, int pageSize)
        {
            return db.Activities
                .Where(a => a.Date > DateTime.Now)
                .OrderBy(a => a.Date)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Activity> GetAll()
        {
            return db.Activities;
        }

        public IEnumerable<Activity> GetAllValid()
        {
            return db.Activities
                .Where(a => a.Date > DateTime.Now)
                .OrderBy(a => a.Date)
                .ToList();
        }

        public IEnumerable<Activity> GetNextActivities(int limit)
        {
            return db.Activities
                .Where(a => a.Date > DateTime.Now)
                .OrderBy(a => a.Date)
                .Take(limit)
                .ToList();
        }

        public IEnumerable<Activity> GetActivitiesByPhrase(int page, int pageSize, string phrase)
        {
            return db.Activities
                .Where(a => a.Title.ToLower().Contains(phrase.ToLower()) ||
                a.Note.ToLower().Contains(phrase.ToLower()) ||
                string.IsNullOrEmpty(phrase))
                .OrderBy(a => a.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfAllActivities()
        {
            return db.Activities.Count();
        }

        public int NumberOfActiveActivities()
        {
            return db.Activities.Where(a => a.Date > DateTime.Now).Count();
        }

        public int NumberOfActiveActivitiesWithPhrase(string phrase)
        {
            return db.Activities
                .Where(a => a.Title.ToLower().Contains(phrase.ToLower()) ||
                a.Note.ToLower().Contains(phrase.ToLower()) ||
                string.IsNullOrEmpty(phrase))
                .Count();
        }

        public void Update(Activity updatedActivity)
        {
            var entity = db.Activities.Attach(updatedActivity);
            entity.State = EntityState.Modified;
        }
    }
}
