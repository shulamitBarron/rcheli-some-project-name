using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientrepository, PatientRepository>();
builder.Host.UseSerilog((HostContext,services,configuration) =>
{
    configuration.WriteTo.File(@"C:\Users\user1\Documents\תרגולים תכנות\קמאטק\Location_Lesson_1\log.txt");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(c => c.Run(async context =>
{
    var code = context.Response.StatusCode > 400 ? 0 : 1;
    var excption = context.Features
    .Get<IExceptionHandlerPathFeature>()
    .Error;
    Log.Error(excption.Message);
    var response = new { error = excption.Message ,code=code};
    await context.Response.WriteAsJsonAsync(response);
}));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program
{ }