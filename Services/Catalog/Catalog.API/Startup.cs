
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Catalog.API;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
       
        // services.AddCors(options =>
        // {
        //     options.AddPolicy("CorsPolicy", policy =>
        //     {
        //         policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        //     });
        // });
       
        
        //DI
     

        services.AddControllers();
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();  
         //   app.UseSwagger();
           // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        // app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseStaticFiles();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
              //  ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    }
}