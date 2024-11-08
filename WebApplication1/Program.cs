
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._2_Repository;
using FrabalhoFinal._2_Repository.Interface;
using FrabalhoFinal._4_Data;
using Microsoft.OpenApi.Models;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Informa ao Swagger para incluir o arquivo XML gerado
    var xmlFile = "MinhaAPI.xml"; // Nome do arquivo XML gerado
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Teste turma da tarde",
        Version = "v1",
        Description = "Testando descrição"
    });
});
builder.Services.AddAutoMapper(typeof(mappingprofile));

builder.Services.AddScoped<IAssinaturaService, AssinaturaService>();
builder.Services.AddScoped<IAssinaturaRepository, AssinaturaRepository>();

var app = builder.Build();
InicalizadorBD.Inicializador();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
