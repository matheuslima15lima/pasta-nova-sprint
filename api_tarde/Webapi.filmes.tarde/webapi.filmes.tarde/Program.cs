var builder = WebApplication.CreateBuilder(args);


//adicona o servi�o de controllers
builder.Services.AddControllers();

var app = builder.Build();

//mapear os controllers
app.MapControllers();

app.Run();
