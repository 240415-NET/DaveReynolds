using TrackMyStuff.API.Services;
using TrackMyStuff.API.Data;
using Microsoft.EntityFrameworkCore;

//this program.cs is different
//runs like a script from top to bottom, where we add services to our AppBuilder,
//then build the app
//after the app is built we toggle different options for it
//all of this is done when we run our dotnet run our webAPI

var builder = WebApplication.CreateBuilder(args);
string connectionString = File.ReadAllText(@"C:\Users\U0SA29\Documents\Revature\bootcamp\connstringTMS.txt");

// Add services to the container. - these below came in from template
//by default you will have AddControllers(), AddEndpointsApiExplorer(), AddSwaggerGen()

// we are going to move AddControllers() to be last added


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//here are the dependencies that we are going to registar. These are things we choose to bring in 

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserStorageEFRepo, UserStorageEFRepo>();

//here we are going to add trackmystuff context class that inherits from EFCORE

builder.Services.AddDbContext<TrackMyStuffContext> (options => options.UseSqlServer(connectionString));

//
builder.Services.AddControllers();//finds all classes labeled [ApiController]
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Editing our apps CORS settings to allow us to DELETE
app.UseCors(policy => policy.AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
