using Bookify.Repository;
using Bookify.Repository.Contracts;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IConnectionMultiplexer>(options =>
{
    var connection = builder.Configuration.GetConnectionString("RedisConnection");
    return ConnectionMultiplexer.Connect(connection!);
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
