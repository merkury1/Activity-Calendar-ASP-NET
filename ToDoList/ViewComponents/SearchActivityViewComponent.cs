using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Core.Repositories;

namespace ToDoList.Api.ViewComponents
{
    public class SearchActivityViewComponent : ViewComponent
    {
        private readonly IActivityRepository activityRepository;

        public SearchActivityViewComponent(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
