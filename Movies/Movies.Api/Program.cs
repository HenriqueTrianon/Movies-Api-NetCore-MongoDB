﻿using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Movies.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    //.UseKestrel()
                    .ConfigureServices(services => services.AddAutofac())
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
