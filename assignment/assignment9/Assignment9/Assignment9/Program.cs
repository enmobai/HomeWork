using Microsoft.EntityFrameworkCore;
using Assignment9.Models;

namespace Assignment9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            string? connectionString = builder.Configuration.GetConnectionString("orderDB");
            builder.Services.AddDbContext<OrderDbContext>(opt => opt.UseMySQL(connectionString));
            builder.Services.AddScoped<OrderService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
