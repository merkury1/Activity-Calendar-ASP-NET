using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Models;
using ToDoList.Core.Repositories;

namespace ToDoList.Infrastracture.Repositories
{
    public class MockActivityRepository : IActivityRepository
    {
        readonly List<Activity> Activities;

        public MockActivityRepository()
        {
            Activities = new List<Activity>()
            {
                new Activity(){Id=1, Title="Koncert", Note="Filharmonia", Date = new DateTime(2019,9,3,20,0,0)},
                new Activity(){Id=2, Title="Dentysta", Note="Stomatolog - Klinika Sobieskiego 20", Date = new DateTime(2019,9,4,17,30,0)},
                new Activity(){Id=3, Title="Spotkanie Marta", Note="Kawiarnia Towarzyska", Date = new DateTime(2019,7,5,17,20,0)},
            };
        }

        public void Add(Activity activity)
        {
            Activities.Add(activity);
            activity.Id = Activities.Max(b => b.Id) + 1;
        }

        public void Delete(int activityId)
        {
            Activity activityToRemove = Get(activityId);
            Activities.Remove(activityToRemove);
        }

        public Activity Get(int activityId)
        {
            return Activities.FirstOrDefault(a => a.Id == activityId);
        }

        public IEnumerable<Activity> GetAll()
        {
            return Activities.OrderBy(a=>a.Date).ToList();
        }

        public IEnumerable<Activity> GetAllValid()
        {
            return Activities
                .OrderBy(a => a.Date)
                .Where(a=>a.Date>DateTime.Now)
                .ToList();
        }

        public IEnumerable<Activity> GetAllActivitiesForPage(int page, int pageSize)
        {
            return Activities
                .OrderBy(a => a.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Activity> GetActiveActivitiesForPage(int page, int pageSize)
        {
            return Activities
                .Where(a => a.Date > DateTime.Now)
                .OrderBy(a => a.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Activity> GetNextActivities(int limit)
        {
            return Activities
                .OrderBy(a => a.Date)
                .Where(a => a.Date > DateTime.Now)
                .Take(limit)
                .ToList();
        }

        public IEnumerable<Activity> GetActivitiesByPhrase(int page, int pageSize, string phrase)
        {
            return Activities
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
            return Activities.Count();
        }

        public int NumberOfActiveActivities()
        {
            return Activities.Where(a => a.Date > DateTime.Now).Count();
        }

        public int NumberOfActiveActivitiesWithPhrase(string phrase)
        {
            return Activities
                .Where(a => a.Title.ToLower().Contains(phrase.ToLower()) ||
                a.Note.ToLower().Contains(phrase.ToLower()) ||
                string.IsNullOrEmpty(phrase))
                .Count();
        }

        public void Update(Activity updatedActivity)
        {
            Activity activityToUpdate = Get(updatedActivity.Id);
            if (activityToUpdate != null)
            {
                activityToUpdate.Date = updatedActivity.Date;
                activityToUpdate.Note = updatedActivity.Note;
                activityToUpdate.Title = updatedActivity.Title;
                activityToUpdate.Priority = updatedActivity.Priority;
            }
        }

        public int Commit()
        {
            return 0;
        }
    }
}
