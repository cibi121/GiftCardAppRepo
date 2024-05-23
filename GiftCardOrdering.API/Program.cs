
using GiftCardOrdering.Data;
using GiftCardOrdering.Services;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace GiftCardOrdering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();



            string connectionString = "\"Data Source=LAPTOP-2L11O401\\EAGLESDEV;Initial Catalog=GiftCards;User ID=sa;Password=Logmein@admin123;Integrated Security=true;\"";


            builder.Services.AddTransient<UserRepository>(provider => new UserRepository(connectionString));
            builder.Services.AddTransient<OrderRepository>(provider => new OrderRepository(connectionString));
            builder.Services.AddTransient<OrderService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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