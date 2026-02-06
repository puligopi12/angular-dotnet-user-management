using EntityFrameWorkCoreFirstApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOpenApi();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
  

    //app.MapOpenApi();
}
app.UseCors("AllowAngular");


app.UseAuthorization();

app.MapControllers();

app.Run();
