using Backend.Service;


namespace Backend.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkoutService, WorkoutService>();
        }
        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddSingleton(Mapper.GetMapperInstance());
        }
    }
}
