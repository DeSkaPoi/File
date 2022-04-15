using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File.Infrastructure;
using File.Domain;
using Microsoft.EntityFrameworkCore;
using File.Infrastructure.ContextDB;
using File.Infrastructure.DataBaseFile.ModelConnect;
using Microsoft.Extensions.Options;
using File.Infrastructure.RepositoryDB;
using File.Infrastructure.DataBaseFile;

namespace File.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Connect>(Configuration.GetSection("ConnectFileData"));
            services.AddSingleton<IConnect>(sp => sp.GetRequiredService<IOptions<Connect>>().Value);
            

            services.AddSingleton<IContextFileData, ContextFileData>();
            services.AddScoped<IFileRepository ,FileRepository>();

            services.AddControllers();
            services.AddDbContext<FileContext>(b =>
            {
                b.UseSqlServer(Configuration.GetConnectionString("FileManagerDb"));
            },ServiceLifetime.Scoped);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
