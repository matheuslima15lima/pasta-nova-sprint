var builder = WebApplication.CreateBuilder(args);


//adicona o serviço de controllers
builder.Services.AddControllers();

var app = builder.Build();

//mapear os controllers
app.MapControllers();

app.Run();
