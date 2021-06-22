using BattleshipChallenge.Api.Infrastructure;
using BattleshipChallenge.Core.Services;
using BattleshipChallenge.Core.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipChallenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // in-memory boards
            Action<InMemoryStore> store = (_ => { });

            services.Configure(store);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<InMemoryStore>>().Value);

            // app services
            services.AddTransient<IBoardService, BoardService>()
                .AddTransient<IPlayerService, PlayerService>()
                .AddTransient<IGameService, GameService>();

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    // handle model state validation errors
                    options.InvalidModelStateResponseFactory = (context) =>
                    {
                        return new BadRequestObjectResult(new ApiErrorResponse(context.ModelState));
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to Battleship game api");
                });
            });
        }
    }
}