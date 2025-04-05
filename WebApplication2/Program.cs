using WebApplication2;
using WebApplication2.Contracts;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();   

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
