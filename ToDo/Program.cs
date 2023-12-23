using ToDo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
