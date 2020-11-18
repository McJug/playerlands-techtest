using Microsoft.Extensions.DependencyInjection;

namespace testapi
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });
        }
    }
}
