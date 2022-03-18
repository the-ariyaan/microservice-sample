using Domain.Contracts.Repository;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add repository dependencies
services.AddDbContext<MicroSampDbContext>();
services.AddScoped<IGroupRepository, GroupRepository>();
services.AddScoped<IConnectorRepository, ConnectorRepository>();
services.AddScoped<IChargeStationRepository, ChargeStationRepository>();

// Add services to the container.
builder.Services.AddControllers();
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
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<MicroSampDbContext>();
    dataContext.Database.Migrate();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();