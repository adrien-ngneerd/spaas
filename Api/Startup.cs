using Ngneerd.PowerplantCodingChallenge.Api.Extensions;
using Ngneerd.PowerplantCodingChallenge.Application.Extensions;
using Ngneerd.PowerplantCodingChallenge.Infrastructure.Extensions;
using Prometheus;

namespace Ngneerd.PowerplantCodingChallenge.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApi(Configuration);
        services.AddApplication(Configuration);
        services.AddInfrastructure(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHttpLogging();
        app.UseWebSockets();
        app.UseAuthentication().UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapMetrics();
            endpoints.MapControllers();
        });
    }
}