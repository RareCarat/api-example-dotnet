using API.RareCarat.Example.Configuration;
using API.RareCarat.Example.Model;
using API.RareCarat.Example.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

public class Startup
{
    public IConfigurationRoot Configuration { get; set; }
    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

        builder.AddEnvironmentVariables();
        Configuration = builder.Build();
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.RespectBrowserAcceptHeader = true;
        });
        services.Configure<APIOptions>(options =>
        {
            options.Endpoint = Configuration["API:Endpoint"];
            options.Key = Configuration["API:Key"];
        });
        services.AddDbContext<RetailerDBContext>(
            opts => opts.UseSqlServer(Configuration["ConnectionString"])
        );
        services.AddScoped<IRetailerDBContext, RetailerDBContext>();
        services.AddScoped<IDiamondService, DiamondService>();
        services.AddScoped<IAPIService, APIService>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseStaticFiles();

        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
    }

    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();

        var host = new WebHostBuilder()
            .UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT"))
            .UseKestrel()
            .UseConfiguration(config)
            .UseStartup<Startup>()
            .Build();
        host.Run();
    }
}
