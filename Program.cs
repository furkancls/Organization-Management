using Activities.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<Program>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ActivitiesContext>(
//     options =>
//     {
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ACTÝVÝTÝES"));
//     }

//    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
//app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
    
//    name: "default",
//    pattern: "api/{controller}/{action}"
//    ));

app.MapControllers();

app.Run();
