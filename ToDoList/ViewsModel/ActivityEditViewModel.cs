using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ToDoList.Api.ViewsModel
{
    public class ActivityEditViewModel
    {
        public IEnumerable<SelectListItem> Priorities { get; set; }
        public Core.Models.Activity Activity { get; set; }
    }
}
