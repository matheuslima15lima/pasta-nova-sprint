using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();



        //adicona o servi�o de controllers
        //builder.Services.AddControllers();

        //Adiciona servi�o de autentica��o JWT Bearer
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = "JwtBearer";
            options.DefaultAuthenticateScheme = "JwtBearer";
        })

        //Define os parametros de valida��o do token
        .AddJwtBearer("JwtBearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                //Valida quem est� solicitando
                ValidateIssuer = true,

                // Valida quem est� recebendo
                ValidateAudience = true,

                //Define se o tempo de expira��o do token ser� validado
                ValidateLifetime = true,

                //Forma de criptografia e ainda valida��o da chave de autentica��o
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-chave-autenticacao-webapi-dev")),

                //Valida o tempo de expira��o do Token
                ClockSkew = TimeSpan.FromMinutes(5),

                //De onde est� vindo (Issuer)
                ValidIssuer = "Webapi.Inlock.CodeFirst",

                //Para onde est� indo (audience)
                ValidAudience = "Webapi.Inlock.CodeFirst"
            };
        });

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