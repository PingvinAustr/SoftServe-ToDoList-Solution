using ToDoList_API;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using ToDoList_DAL.Interfaces;
using ToDoList_DAL;
using ToDoList_BLL.Interfaces;
using ToDoList_BLL;

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


builder.Services.AddScoped<ICategoryRepository, CategoryDAL>();
builder.Services.AddScoped<ITaskRepository, TaskDAL>();
builder.Services.AddScoped<IStatusRepository, StatusDAL>();
builder.Services.AddScoped<IUrgencyRepository, UrgencyDAL>();
builder.Services.AddScoped<ITask, TaskBLL>();
builder.Services.AddScoped<ICategory, CategoryBLL>();
builder.Services.AddScoped<IStatus, StatusBLL>();
builder.Services.AddScoped<IUrgency, UrgencyBLL>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ToDoList_BLL.Mapper.MappingProfile());
});


var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
 

builder.Services.AddDbContext<ToDoList_DAL.todolistContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
ToDoList_DAL.todolistContext context = new ToDoList_DAL.todolistContext();
Console.WriteLine(context.Urgencies.Count());
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
