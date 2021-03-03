using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetex.modules.users.Services.Implementations.CreateUserService;
using dotnetex.modules.users.Services.Implementations.DeleteUserService;
using dotnetex.modules.users.Services.Implementations.GetAllUsersService;
using dotnetex.modules.users.Services.Implementations.GetUserByEmailService;
using dotnetex.modules.users.Services.Implementations.GetUserByIdService;
using dotnetex.shared.Errors;
using dotnetex.shared.Providers.FileUploadProvider;
using dotnetex.shared.Providers.FileUploadProvider.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using modules.users.Repositories;
using modules.users.Services;
using shared.Configurations.Database;

namespace dotnetex
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
            //var connection = Configuration["DbConnections:SqlitConnectionInMem"];
            var connection = Configuration.GetConnectionString("SqlitConnection");
            services.AddDbContext<SQLiteDbContext>(options => options.UseSqlite(connection));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserServices, UserServices>();
            services.AddTransient<IGetAllUsersService, GetAllUsersService>();
            services.AddTransient<IGetUserByIdService, GetUserByIdService>();
            services.AddTransient<ICreateUserService, CreateUserService>();
            services.AddTransient<IGetUserByEmailService, GetUserByEmailService>();
            services.AddTransient<IDeleteUserService, DeleteUserService>();
            services.AddTransient<IFileUpload, LocalFileUploadProvider>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetex", Version = "v1" });
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //Only For .NET 5
            // app.UseExceptionHandler(a => a.Run(async context =>
            // {
            //     var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            //     //var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            //     var exception = exceptionHandlerPathFeature.Error;

            //     if (exception is HttpException httpException)
            //     {
            //         System.Console.WriteLine(exception);
            //     }

            //     await context.Response.WriteAsJsonAsync<APIError>(new APIError(500, "oi"));
            //     //await context.Response.WriteAsJsonAsync(new APIError(100, exception.Message));
            // }));
            // It should be one of your very first registrations

            app.UseExceptionHandler("/error"); // Add this

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetex v1"));
            }

            //app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
