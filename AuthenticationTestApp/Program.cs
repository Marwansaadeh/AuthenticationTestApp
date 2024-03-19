using AuthenticationTestApp;
using AuthenticationTestApp.Helper.HttpClientHeplers;
using AuthenticationTestApp.Services.Authontication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthonticationToken, AuthonticationToken>();
builder.Services.AddScoped<IHttpClientAuthHelper, HttpClientAuthHelper>();
builder.Services.Configure<ApplicationUrlsOptions>(builder.Configuration.GetSection(nameof(ApplicationUrlsOptions)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
