using Localiza.Frotas.Domain;
using Localiza.Frotas.Infra.Facade;
using Localiza.Frotas.Infra.Repository.EF;
using Localiza.Frotas.Infra.Singleton;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Localiza.Frotas",
        Description = "API - Frotas",
        Version = "v1"
    });

    var apiPath = Path.Combine(AppContext.BaseDirectory, "Localiza.Frotas.xml");
    c.IncludeXmlComments(apiPath);


});

//-> Singleton unica instancia
builder.Services.AddSingleton<SingletonContainer>();  //-> utilizar Singleton maneira auto (definir a classe)


//builder.Services.AddSingleton<IVeiculoRepository,InMemoryRepository>();

builder.Services.AddTransient<IVeiculoRepository, FrotaRepository>(); // AddTransient -> cria um intancia sempre que chamado

builder.Services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();

builder.Services.AddDbContext<FrotaContext>(opt => opt.UseInMemoryDatabase("Frota")); //-> conexão string


builder.Services.AddHttpClient();


builder.Services.Configure<DetranOptions>(builder.Configuration.GetSection("DetranOptions")); //-> pegando do appSettings 



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
