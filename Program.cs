using ImcAPI.Enums;
using ImcAPI.Models;
using ImcAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonSerializerOptions>(options =>
{
    options.Converters.Add(new JsonStringEnumConverter());
});

// Add services to the container.
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

// Calculator BMI (Body Mass Index) endpoint

// Query version
app.MapGet("/bmi-calculator", ([FromQuery(Name = "height")] double height,
                               [FromQuery(Name = "weight")] double weight,
                               [FromQuery(Name = "heightUnit")] HeightUnitEnum heightUnit,
                               [FromQuery(Name = "weightUnit")] WeightUnitEnum weightUnit,
                               [FromQuery(Name = "measurementSystem")] MeasurementSystemEnum measurementSystem,
                               [FromQuery(Name = "age")] int age,
                               [FromQuery(Name = "gender")] GenderEnum gender) =>
{
    var _BMICalculator = new BMICalculator();
    var (bmi, bmiStatus) = _BMICalculator.CalculateBMI(height, weight, heightUnit, weightUnit, measurementSystem, age, gender);

    return Results.Ok(new { BMI = bmi, Status = bmiStatus });
}).WithOpenApi();

// body version
app.MapPost("/bmi-calculator", ([FromBody] BMICalculatorRequest request) =>
{
    var _BMICalculator = new BMICalculator();
    var (bmi, bmiStatus) = _BMICalculator.CalculateBMI(request.Height, request.Weight, request.HeightUnit, request.WeightUnit, request.MeasurementSystem, request.Age, request.Gender);

    return Results.Ok(new { BMI = bmi, Status = bmiStatus });
}).WithOpenApi();

app.UseHttpsRedirection();
app.Run();