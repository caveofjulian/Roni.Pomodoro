using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Roni.Pomodoro.Persistence.Entities;

namespace Roni.Pomodoro.Persistence
{
    public class PomodoroContext : DbContext
    {
        public PomodoroContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskBlock> TimeBlocks { get; set; }
        public DbSet<TaskBlockCategory> TimeBlockCategories { get; set; }
    }
}
