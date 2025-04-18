using CompanyEmployees.Extensions;
using Contracts;
using LoggerService;
using NLog;


var builder = WebApplication.CreateBuilder(args);


LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config.xml"));  


builder.Services.ConfigureIIS();

builder.Services.ConfigureRepositoryManager();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.ConfigureLoggerService();

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.ConfigureSqlContext(builder.Configuration);


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

app.UseCors("CorsPolicy");

app.Run();