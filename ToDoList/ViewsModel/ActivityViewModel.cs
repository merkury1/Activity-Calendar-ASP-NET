using System;
using System.Collections.Generic;

namespace ToDoList.Api.ViewsModel
{
    public class ActivityViewModel
    {
        public IEnumerable<Core.Models.Activity> Activities { get; set; }
        public string Message { get; set; }
        public string SearchPhrase { get; set; }

        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}
