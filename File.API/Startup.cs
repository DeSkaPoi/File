using File.Infrastructure.ContextDB;
using File.Infrastructure.DataBaseFile;
using File.Infrastructure.DataBaseFile.ModelConnect;
using File.Infrastructure.RepositoryDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

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
            services.AddScoped<IFileRepository, FileRepository>();

            services.AddControllers();
            services.AddDbContext<FileContext>(b =>
            {
                b.UseSqlServer(Configuration.GetConnectionString("FileManagerDb"));
            });
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
