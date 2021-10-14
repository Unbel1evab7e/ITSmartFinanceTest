using ITSmartFinance.Services.IService;
using ITSmartFinance.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinance.Services
{
    public static class AppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IBoardService, BoardService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskOnUserService, TaskOnUserService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
