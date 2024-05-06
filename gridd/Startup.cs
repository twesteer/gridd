//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.SqlServer;
//using gridd.Migrations;


//namespace gridd;
//public class Startup
//{
//    private IConfiguration _configuration;

//    public Startup(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        // Получаем строку подключения из appsettings.json
//        string connectionString = _configuration.GetConnectionString("DefaultConnection");

//        // Добавляем DbContext с указанием провайдера базы данных и строки подключения из конфигурации
//        services.AddDbContext<Grid>(options =>
//            options.UseSqlServer(connectionString));

//        // Другие сервисы и конфигурации
//    }

//    // Другие методы конфигурации
//}
