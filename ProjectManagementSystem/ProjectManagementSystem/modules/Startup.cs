using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.modules.authentication;
using ProjectManagementSystem.modules.ControlData;
using ProjectManagementSystem.modules.ControlData.Interfaces;
using ProjectManagementSystem.modules.UserInteraction;

namespace ProjectManagementSystem.modules
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Регистрируем DataManager как одноэлементный объект (Singleton)
            services.AddSingleton<DataManager>();
            services.AddSingleton<IDataStorage, JsonDataStorage>(); // Регистрируем JsonDataStorage как реализацию IDataStorage
            services.AddSingleton<Authenticator>();

            // Регистрируем Logger как одноэлементный объект (Singleton)
            services.AddSingleton<Logger>();

            // Регистрируем CLI как объект, создаваемый для каждого запроса (Scoped)
            services.AddScoped<CLI>();
        }
    }
}