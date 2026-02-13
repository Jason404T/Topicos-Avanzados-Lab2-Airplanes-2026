using Lab2.Airplanes.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// HttpClient para consumir el API
var baseUrl = builder.Configuration["Api:BaseUrl"]!;
builder.Services.AddHttpClient<AirplanesApiClient>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Arrancar en el modulo del lab
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Airplanes}/{action=Index}/{id?}");

app.Run();
