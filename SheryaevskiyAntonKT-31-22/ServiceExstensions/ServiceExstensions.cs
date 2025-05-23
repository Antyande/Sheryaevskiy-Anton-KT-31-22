using SheryaevskiyAntonKT_31_22.Interfaces;

namespace SheryaevskiyAntonKT_31_22.ServiceExstensions
{
    public static class ServiceExtensions
    {
        public static void AddDbServices(this IServiceCollection services)
        {
            services.AddScoped<ITeachersService, TeachersService>();
            services.AddScoped<IDisciplineService, DisciplineService>();

        }
    }
}
