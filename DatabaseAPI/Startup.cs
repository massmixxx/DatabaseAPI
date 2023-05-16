using DatabaseAPI.Database.Interceptors;
using DatabaseAPI.Database.Model.ProductCategories;
using DatabaseAPI.Database.Model.Products;
using DatabaseAPI.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

namespace DatabaseAPI
{

  public class Startup
  {
    private IConfiguration _configuration { get; }
    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers()
        .AddJsonOptions(options =>
      {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
      });

      //FluentValidation
      services.AddFluentValidationAutoValidation();
      services.AddFluentValidationClientsideAdapters();
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

      // Automapper
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      // Database
      string connString = _configuration.GetConnectionString("Debug") ?? throw new NullReferenceException();
      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString).AddInterceptors(new ModificationDateInterceptor()));

      AddFactories(services);
      AddServices(services);

      //Swagger
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();

      services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger();
      app.UseSwaggerUI();

      app.UseHttpsRedirection();

      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(c => c.MapControllers());

    }

    private void AddFactories(IServiceCollection services)
    {
      services.AddScoped<IProductFactory, ProductProxyFactory>();
      services.AddScoped<IProductCategoryFactory, ProductCategoryProxyFactory>();
    }

    private void AddServices(IServiceCollection services)
    {
    }
  }
}
