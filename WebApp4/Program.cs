using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var suportedCultures = new[] { "en-US", "de-DE", "pl-PL" };
    options.SetDefaultCulture("en-US");
    options.AddSupportedCultures(suportedCultures);
    options.AddSupportedUICultures(suportedCultures);

});

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
