using CompanyEmployees.Extensions;
using Contracts;
using LoggerService;
using NLog;


var builder = WebApplication.CreateBuilder(args);


LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config.xml"));  


builder.Services.ConfigureIIS();

builder.Services.ConfigureRepositoryManager();

builder.Services.AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;

    }).AddXmlDataContractSerializerFormatters()
    .AddCustomCSVFormatter();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.ConfigureLoggerService();

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILoggerManager>());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();