using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.ViewModels;
using LLM.Store.BAL;
using LLM.Store.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Goggly_Training
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment)
        {
            // Configuration = configuration;

            var builder = new ConfigurationBuilder()
         .SetBasePath(environment.ContentRootPath)
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
         .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", reloadOnChange: false, optional: true)
         .AddEnvironmentVariables();

            Configuration = builder.Build();

            ConnectionStringSettingsProvider.ConnectionString = Configuration["ConnectionStrings:storeconnectionstring"];
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Goggly_Training", Version = "v1" });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IStoreData, StoreData>();
            services.AddTransient<IStoreRepo, StoreRepo>();
            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<ICustomerData, CustomerData>();
            services.AddTransient<IStoreCustomerData, StoreCustomerData>();
            services.AddTransient<IStoreCustomerRepo, StoreCustomerRepo>();
            services.AddTransient<ITransactionData, TransactionData>();
            services.AddTransient<ITransactionRepo, TransactionRepo>();
            services.AddTransient<IPaymentData, PaymentData>();
            services.AddTransient<IPaymentRepo, PaymentRepo>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.Configure<WelcomeRequest>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IStationMasterData, StationMasterData>();
            services.AddTransient<IStationMasterRepo, StationMasterRepo>();
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IUserRepo, UserRepo>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Goggly_Training v1"));
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
