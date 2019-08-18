using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.Repositories;

namespace ToDoList.Api.ViewComponents
{
    public class NextActivityViewComponent : ViewComponent
    {
        private readonly IActivityRepository activityRepository;

        public NextActivityViewComponent(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public IViewComponentResult Invoke()
        {
            var count = activityRepository.GetNextActivities(3);
            return View(count);
        }
    }
}
