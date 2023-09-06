using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parametros de validação do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem está solicitando
        ValidateIssuer = true,

        // Valida quem está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração do token será validado
        ValidateLifetime = true,

        //Forma de criptografia e ainda validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Games-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expiração do Token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde está vindo (Issuer)
        ValidIssuer = "senai.inlock.webApi",

        //Para onde está indo (audience)
        ValidAudience = "senai.inlock.webApi"
    };
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api inlock games Tarde",
        Description = "API para gerenciamento de uma loja de Games",

        Contact = new OpenApiContact
        {
            Name = "Matheus",
            Url = new Uri("https://github.com/matheuslima15lima")
        }

    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                }

            },
            new String[] {}
        }
    });



});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Usar autenticação
app.UseAuthentication();

//Usar autorização
app.UseAuthorization();

//mapear os controllers
app.MapControllers();

app.Run();


