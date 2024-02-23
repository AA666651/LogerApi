using System.Text;
using Autofac;
using LogerApi.Auth;
using LogerApi.CommandBase;
using LogerApi.Common;
using LogerApi.Config;
using LogerApi.QueryBase;
using LogerApi.ValidatorBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using LogerDatabase;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;

namespace LogerApi
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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddScoped<IUserService, UserService>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            
            var context = Configuration.GetConnectionString("AppContext");
            services.AddDbContext<LogerContext>(options =>options.UseSqlServer(context));
        
            services.AddCors(options => options.AddPolicy(name: "NgOrigins",
            policy =>
            {
                policy.WithOrigins("http://localhost:5015").AllowAnyMethod().AllowAnyHeader();
            }));
            
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new QueriesModule());
            builder.RegisterModule(new CommandsModule());
            builder.RegisterModule(new ValidatorsModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LogerApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("NgOrigins");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}