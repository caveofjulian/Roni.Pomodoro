using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Roni.Pomodoro.Persistence.Entities;

namespace Roni.Pomodoro.Persistence
{
    public static class ServicesConfiguration
    {
        public static void ConfigurePersistenceServices(this IServiceCollection collection, string connectionString)
        {
            collection.AddDbContext<PomodoroContext>(options => options.UseSqlServer(connectionString));
            collection.AddTransient<IRepository<TaskBlockCategory>, Repository<TaskBlockCategory>>();
            collection.AddTransient<IRepository<TaskBlock>, Repository<TaskBlock>>();
        }
    }
}
