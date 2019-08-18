using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Core.Models
{
    public enum Priority : int
    {
        [Description("niski")]
        [Display(Name = "niski")]
        low,
        [Display(Name = "średni")]
        medium,
        [Display(Name = "wysoki")]
        high
    }
}
