using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Core.Models
{
    public class Activity
    {
        public Activity()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        
        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Proszę uzupełnić tytuł zadania.")]
        [StringLength(100, ErrorMessage = "Maksymalna długość tytułu to 100 znaków.")]
        public string Title { get; set; }

        [Display(Name = "Notatka")]
        [Required(ErrorMessage = "Proszę uzupełnić treść notatki.")]
        [StringLength(500, ErrorMessage = "Maksymalna długość tytułu to 500 znaków.")]
        public string Note { get; set; }

        [Display(Name = "Data wykonania")]
        [Required(ErrorMessage = "Proszę uzupełnić datę zadania.")]
        [RegularExpression(@"^(0[1-9]|1\d|2\d|3[01])\.(0[1-9]|1\d|2\d|3[01])\.(19|20)\d{2}(\s)(0[1-9]|1[0-9]|2[0-3])(\:)([0-5]\d)(\:)([0-5]\d)$", 
            ErrorMessage = "Proszę wprowadzić poprawny format daty dd.mm.yy HH:mm:ss")]
        public DateTime Date { get; set; }

        [Display(Name = "Piorytet")]
        public Priority Priority { get; set; }
    }
}
