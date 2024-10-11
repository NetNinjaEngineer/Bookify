using Bookify.Data;
using Bookify.Entities;
using Bookify.Helpers;
using Bookify.Repository;
using Bookify.Repository.Contracts;
using Bookify.Services;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Stripe;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IConnectionMultiplexer>(options =>
{
	var connection = builder.Configuration.GetConnectionString("RedisConnection");
	return ConnectionMultiplexer.Connect(connection!);
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = true;
	options.Password.RequireLowercase = true;
	options.User.RequireUniqueEmail = true;
})
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.AccessDeniedPath = "/Account/AccessDenied";
		options.LoginPath = "/Account/Login";
		options.LogoutPath = "/Account/Logout";
		options.Cookie.Name = "LMS-COOKIE";
	});

builder.Services.AddAuthorization();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IUserService, UserService>();

var stripeKeys = new StripeKeys();
builder.Configuration.Bind(nameof(StripeKeys), stripeKeys);

StripeConfiguration.ApiKey = stripeKeys.SecretKey;

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IWishlistService, WishlistService>();


var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
await dbContext.SeedDatabaseAsync();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/Home/Error404");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapAreaControllerRoute(
	name: "admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
