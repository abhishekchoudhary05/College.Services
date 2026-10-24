using College.Services.Business;
using College.Services.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace College.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<CollegeDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeDBConnectionString")));
            builder.Services.AddScoped<IEmployeeData, EmployeeData>();
            builder.Services.AddScoped<IProfessorsData, ProfessorsData>();
            builder.Services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
            builder.Services.AddScoped<IProfessorsBusiness, ProfessorsBusiness>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
