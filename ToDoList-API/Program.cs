using ToDoList_API;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "http://www.contoso.com")

                          .AllowAnyHeader()
                          .AllowAnyOrigin()
                          .WithMethods("PUT", "DELETE", "GET", "POST");
                      });
});


builder.Services.AddControllers();

builder.Services.AddDbContext<todolistContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
todolistContext context = new todolistContext();
Console.WriteLine(context.Urgencies.Count());
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
