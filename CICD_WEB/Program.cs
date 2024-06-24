
using System.Data.Common;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment env = builder.Environment;
// Add services to the container.
builder.Services.AddControllersWithViews();


DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<CICD.LIB.Logica.GClientes>();
builder.Services.AddScoped<CICD.LIB.Logica.GEmpleados>();
builder.Services.AddScoped<CICD.LIB.Logica.GProductos>();

IConfiguration Configuration = builder.Configuration;

//Json
builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

//Actualizaci�n de vistas y JS en tiempo de ejecuci�n.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();

IServiceCollection services = builder.Services;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection(); 
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
