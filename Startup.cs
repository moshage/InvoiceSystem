using Microsoft.EntityFrameworkCore;
using NFSystem.Data;
using NFSystem.Notification;
using NFSystem.Service;
using NFSystem.Validator;
using NFSystem.XML;
using System.Text.Json.Serialization;

namespace InvoiceSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration cfg) => Configuration = cfg;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter()
                    );
                });

            services.AddDbContext<InvoiceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<INotification, Notifier>();
            services.AddScoped<IInvoiceXmlParser, InvoiceXmlParser>();
            services.AddScoped<IInvoiceValidator, InvoiceValidator>();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notas API V1"); });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
