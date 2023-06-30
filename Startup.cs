using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UfjfGoAPI.DAL;
using UfjfGoAPI.Services;

namespace UfjfGoAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UfjfGoAPI", Version = "v1" });
            });

            // Repositories
            //services.AddScoped<CustomersRepository>();
            //services.AddScoped<OrderItemsRepository>();
            //services.AddScoped<ProductsRepository>();
            //services.AddScoped<OrdersRepository>();

            // Services
            services.AddTransient<UserService>();
            services.AddTransient<EvaluationService>();
            //services.AddTransient<ProductService>();

            var connectionString = "Server=.\\SQLExpress;Database=ufjfgo;Trusted_Connection=True;TrustServerCertificate=True";
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UfjfGo v1"));
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
