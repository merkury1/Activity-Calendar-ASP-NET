using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Api.ViewsModel;
using ToDoList.Core.Models;
using ToDoList.Core.Repositories;

namespace ToDoList.Api.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository activityRepository;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<Activity> Activities { get; set; }
        public Activity Activity { get; set; }
        public string Message { get; set; }
        public int PageSize = 4;

        public ActivityController(IActivityRepository activityRepository, IHtmlHelper htmlHelper)
        {
            this.activityRepository = activityRepository;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult Index(int pageId = 1)
        {
            ActivityViewModel activityViewModel = new ActivityViewModel();
            activityViewModel.Activities = activityRepository.GetActiveActivitiesForPage(pageId, PageSize);
            activityViewModel.CurrentPage = pageId;
            activityViewModel.ItemsPerPage = PageSize;
            activityViewModel.TotalItems = activityRepository.NumberOfActiveActivities(); 

            if(TempData["Message"]!=null)
                activityViewModel.Message = TempData["Message"].ToString();

            return View(activityViewModel);
        }

        [HttpGet("activity/archive/{pageid?}", Name = "Archive")]
        public IActionResult Archive(int pageId = 1)
        {
            ActivityViewModel activityViewModel = new ActivityViewModel();
            activityViewModel.Activities = activityRepository.GetAllActivitiesForPage(pageId, PageSize);
            activityViewModel.CurrentPage = pageId;
            activityViewModel.ItemsPerPage = PageSize;
            activityViewModel.TotalItems = activityRepository.NumberOfAllActivities();

            return View(activityViewModel);
        }

        [HttpGet("activity/searchResults/{phrase?}/{pageId?}", Name = "SearchResults")]
        public IActionResult SearchResults(string phrase, int pageId = 1)
        {
            ActivityViewModel activityViewModel = new ActivityViewModel();
            activityViewModel.Activities = activityRepository.GetActivitiesByPhrase(pageId, PageSize, phrase);
            activityViewModel.SearchPhrase = phrase;
            activityViewModel.CurrentPage = pageId;
            activityViewModel.ItemsPerPage = PageSize;
            activityViewModel.TotalItems = activityRepository.NumberOfActiveActivitiesWithPhrase(phrase);

            return View(activityViewModel);
        }

        [HttpGet("activity/details/{activityid?}", Name = "Details")]
        public IActionResult Details(int? activityId)
        {
            if (activityId.HasValue)
            {
                Activity = activityRepository.Get(activityId.Value);
                if(Activity!=null)
                    return View(Activity);
                else
                    return RedirectToAction("NotFound");
            }
            else
            {
                return RedirectToAction("NotFound");
            }

        }

        [HttpGet("activity/edit/{activityid?}", Name = "Edit")]
        public IActionResult Edit(int? activityId)
        {
            ActivityEditViewModel activityEditViewModel = new ActivityEditViewModel();
            activityEditViewModel.Priorities = htmlHelper.GetEnumSelectList<Priority>();

            if (activityId.HasValue)
            {
                activityEditViewModel.Activity = activityRepository.Get(activityId.Value);
                if(activityEditViewModel.Activity!=null)
                    return View(activityEditViewModel);
                else
                    return RedirectToAction("NotFound");
            }
            else
            {
                activityEditViewModel.Activity = new Activity();
                return View(activityEditViewModel);
            }
        }

        [HttpPost]
        public IActionResult Edit(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                ActivityEditViewModel activityEditViewModel = new ActivityEditViewModel();
                activityEditViewModel.Priorities = htmlHelper.GetEnumSelectList<Priority>();
                activityEditViewModel.Activity = activity;
                return View(activityEditViewModel);
            }

            if (activity.Id > 0)
            {
                activityRepository.Update(activity);
                TempData["Message"] = $"Zadanie '{activity.Title}' zostało zapisane.";
            }
            else
            {
                activityRepository.Add(activity);
                TempData["Message"] = $"Zadanie '{activity.Title}' zostało utworzone.";
            }

            activityRepository.Commit();
            return RedirectToAction("Index");
        }

        public new IActionResult NotFound()
        {
            return View();
        }

        [HttpGet("activity/delete/{activityid}", Name = "Delete")]
        public IActionResult Delete(int activityId)
        {
            Activity = activityRepository.Get(activityId);
            if (Activity == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(Activity);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Activity activity)
        {
            activityRepository.Delete(activity.Id);
            activityRepository.Commit();
            TempData["Message"] = $"Zadanie '{activity.Title}' zostało usunięte.";
            return RedirectToAction("Index");
        }

    }
}