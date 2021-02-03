using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Time_Sheet_MVC.Models;

[assembly: HostingStartup(typeof(Time_Sheet_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Time_Sheet_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Time_Sheet_MVCIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Time_Sheet_MVCIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Time_Sheet_MVCIdentityContext>();
            });
        }
    }
}