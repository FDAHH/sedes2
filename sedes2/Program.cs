using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using sedes.Data;
using sedes.Models.Maps;
using sedes2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", EdmModelHelper.GetEdmModel()).EnableQueryFeatures());
builder.Services.AddDbContext<SedesContext>(options =>
        options.

        UseSqlServer(
            builder.Configuration.GetConnectionString("MsSqlServer")
            )
        );

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



