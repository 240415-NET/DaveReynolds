//this program.cs is different
//runs like a script from top to bottom, where we add services to our AppBuilder,
//then build the app
//after the app is built we toggle different options for it
//all of this is done when we run our dotnet run our webAPI

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();//finds all classes labeled [ApiController]
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
