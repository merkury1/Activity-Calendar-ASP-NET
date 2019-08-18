using System.Collections.Generic;
using ToDoList.Core.Models;

namespace ToDoList.Core.Repositories
{
    public interface IActivityRepository
    {
        Activity Get(int activityId);
        IEnumerable<Activity> GetAll();
        IEnumerable<Activity> GetActiveActivitiesForPage(int page, int pageSize);
        IEnumerable<Activity> GetAllActivitiesForPage(int page, int pageSize);
        IEnumerable<Activity> GetAllValid();
        IEnumerable<Activity> GetNextActivities(int limit);
        IEnumerable<Activity> GetActivitiesByPhrase(int page, int pageSize, string phrase);
        int NumberOfAllActivities();
        int NumberOfActiveActivities();
        int NumberOfActiveActivitiesWithPhrase(string phrase);
        void Add(Activity activity);
        void Update(Activity updatedActivity);
        void Delete(int activityId);
        int Commit();
    }
}
