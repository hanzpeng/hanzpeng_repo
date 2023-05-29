using FullStack.API.Data;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<FullStackDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FullStackConnectionString")));
            // this will register http Client
            builder.Services.AddHttpClient();

            // name http client
            builder.Services.AddHttpClient("github", c =>
            {
                c.BaseAddress = new Uri("https://api.github.com");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            builder.Services.AddAntiforgery(options =>
            {
                options.FormFieldName = "MyAntiForgeryField";
                options.HeaderName = "MyAntiForgeryHeader";
                options.Cookie.Name = "MyAntiForgeryCookie";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}