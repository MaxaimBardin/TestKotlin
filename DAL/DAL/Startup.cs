using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DAL;

public class Startup
{
    public Startup(IConfiguration conf)
    {
        Configuration = conf;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        string con = "Server=DESKTOP-DA7Q1OV;DataBase=Baker;Trusted_Connection=True;";
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(con));
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Baker", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Baker v1.0"));
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}