using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Models;

namespace ToDoList.Infrastracture
{
    public class ToDoListDBContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }

        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options):base(options)
        {
        }
    }
}
