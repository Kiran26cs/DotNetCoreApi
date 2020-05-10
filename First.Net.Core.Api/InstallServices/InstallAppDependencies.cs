using System;
using System.Collections.Generic;
using System.Text;
using AppManager.AppInterfaces;
using AppManager.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace First.Net.Core.Api.InstallServices
{
    public static class InstallAppDependencies
    {
        public static void InstallManagerServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenProcessor, TokenProcessor>();
        }
    }
}
