// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API
{
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using Couchbase.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Services.Administration;
    using TEHA.Portal.ProxyAPI;
    using TEHA.Portal.ProxyAPI.Clients.Account;
    using TEHA.Portal.ProxyAPI.Clients.Accounting;
    using TEHA.Portal.ProxyAPI.Clients.Contract;
    using TEHA.Portal.ProxyAPI.Clients.Dashboard;
    using TEHA.Portal.ProxyAPI.Clients.Document;
    using TEHA.Portal.ProxyAPI.Clients.Info;
    using TEHA.Portal.ProxyAPI.Clients.Lookup;
    using TEHA.Portal.ProxyAPI.Clients.StockOverview;
    using TEHA.Portal.ProxyAPI.Order;

    /// <summary>
    /// API Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets configuration
        /// </summary>
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Couchbase Configurations
            Configuration configuration = new Configuration(this.Configuration.GetSection("AppSettings"));

            // Creating and Initializing Database
            DatabaseScripts databaseScripts = new DatabaseScripts(configuration);
            databaseScripts.Initialize();

            // Injecting Services with couchbase configurations
            services.AddScoped(_ => new EmailTemplateService(configuration));
            services.AddScoped(_ => new SystemSettingService(configuration));
            services.AddScoped(_ => new LanguageService(configuration));
            services.AddScoped(_ => new SystemLogService(configuration));
            services.AddScoped(_ => new UserSettingService(configuration));

            services.AddSingleton<Configuration>(configuration);

            services.AddTransient<IStockOverviewClient>(_ => new StockOverviewClient());
            services.AddTransient<IAccountClient>(_ => new AccountClient());
            services.AddTransient<IAccountingClient>(_ => new AccountingClient());
            services.AddTransient<IDocumentClient>(_ => new DocumentClient());
            services.AddTransient<IOrderClient>(_ => new OrderClient());
            services.AddTransient<IInfoClient>(_ => new InfoClient());
            services.AddTransient<IContractClient>(_ => new ContractClient());
            services.AddTransient<ILookupClient>(_ => new LookupClient());
            services.AddTransient<IDashboardClient>(_ => new DashboardClient());

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            // Auto Mapper Configurations
            services.AddAutoMapper(typeof(AutoMapping));

            // Swagger Settings
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "TEHA API", Version = "V1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 {
                      {
                        new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference
                            {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer",
                            }, Scheme = "oauth2", Name = "Bearer", In = ParameterLocation.Header,
                        }, new List<string>()
                      },
                 });
            });
            this.JwtSettings(services);
            this.Cors(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IWebHostEnvironment</param>
        /// <param name="applicationLifetime">IHostApplicationLifetime</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");

            // Swagger Settings
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/Swagger/v1/Swagger.json", name: "TEHA API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            // custom jwt auth middleware
            app.UseCors("Cors");
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Closing the couchbase connections
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                app.ApplicationServices.GetRequiredService<ICouchbaseLifetimeService>().Close();
            });
        }

        /// <summary>
        /// Cors
        /// </summary>
        /// <param name="services">Serives</param>
        private void Cors(IServiceCollection services)
        {
            var corsUrls = this.Configuration.GetSection("AllowedDomains:Urls").Get<List<string>>();
            services.AddCors(options =>
            {
                options.AddPolicy("Cors", p =>
                {
                    p.WithOrigins(corsUrls.ToArray())
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });
        }

        /// <summary>
        /// Implements JWT Settings
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        private void JwtSettings(IServiceCollection services)
        {
            string jWTKey = this.Configuration.GetSection("AppSettings").GetValue<string>("Secret");
            var key = Encoding.ASCII.GetBytes(jWTKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }
    }
}
