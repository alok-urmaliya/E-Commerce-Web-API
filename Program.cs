using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web_API;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var provider = services.BuildServiceProvider();
var config = provider.GetService<IConfiguration>();

// Add services to the container.

services.AddControllers();
services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Device Management API", Version = "v1" });
    //     c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    //     {
    //         Name = "Authorization",
    //         Type = SecuritySchemeType.Http,
    //         Scheme = "bearer",
    //         BearerFormat = "JWT",
    //         In = ParameterLocation.Header,
    //         Description = "JWT Authorization header using the Bearer scheme."
    //     });
    //     c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //     {
    //         {
    //               new OpenApiSecurityScheme
    //                 {
    //                     Reference = new OpenApiReference
    //                     {
    //                         Type = ReferenceType.SecurityScheme,
    //                         Id = "bearerAuth"
    //                     }
    //                 },
    //                 new string[] {}
    //         }
    //     });
});
services.AddDbContext<AppDbContext>(options =>
{

    options.UseSqlServer(config.GetConnectionString("VueapiContext"));
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
