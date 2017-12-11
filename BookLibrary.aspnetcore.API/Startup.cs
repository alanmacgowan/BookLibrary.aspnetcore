using BookLibrary.aspnetcore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace BookLibrary.aspnetcore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookLibraryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(opt =>
            {
                opt.Filters.Add(new RequireHttpsAttribute());
            })
            .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "BookLibrary API - V1",
                        Version = "v1",
                        Description = "A sample API for BookLibrary demo.",
                        TermsOfService = "",
                        Contact = new Contact
                        {
                            Name = "Alan Macgowan",
                            Email = "alanmacgowan@gmail.com"
                        },
                        License = new License
                        {
                            Name = "Apache 2.0",
                            Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                        }
                    });
                    var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "BookLibrary.aspnetcore.API.xml");
                    c.IncludeXmlComments(filePath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRewriter(new RewriteOptions().AddRedirectToHttps(301, 44324));

            app.UseMvc();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookLibrary API V1");
            });
        }
    }
}
