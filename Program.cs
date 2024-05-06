using EmailSender.API.Data.Interfaces;
using EmailSender.API.Data.Services;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

var restClient = builder.Configuration.Get<RestClient>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => {
    options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
    });

app.UseHttpsRedirection();

app.Run();
