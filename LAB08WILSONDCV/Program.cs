using LAB08WILSONDCV.Data;
using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Configuración de la Conexión a la Base de Datos ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LinqDbContext>(options =>
    options.UseNpgsql(connectionString));

// --- 2. Configuración de Servicios ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- ¡NUEVA LÍNEA! ---
// Registro del Repositorio para Inyección de Dependencias.
// Le decimos a la app: "Cuando un constructor pida IClientRepository,
// entrégale una instancia de ClientRepository".
builder.Services.AddScoped<IClientRepository, ClientRepository>();


var app = builder.Build();

// --- 3. Configuración del Pipeline HTTP ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();