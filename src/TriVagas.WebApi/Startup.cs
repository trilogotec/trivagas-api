using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO.Compression;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TriVagas.Domain.Interfaces;
using TriVagas.Infra.Data.Context;
using TriVagas.WebApi.Config;

namespace TriVagas.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

            services.AddResponseCompression();
                                    
            services.AddSwaggerConfig();

            services.ResolveFilterException();

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings").GetChildren().ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.ResolveDependencies();

            services.AddScoped<IServiceProvider, ServiceProvider>();

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "API Controle Volume V1");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
