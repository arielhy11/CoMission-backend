using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Chat_App.Data;
using Chat_App.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ContactService>();
builder.Services.AddControllers();

builder.Services.AddDbContext<Chat_AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Chat_AppContext") ?? throw new InvalidOperationException("Connection string 'Chat_AppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rates}/{action=Search}/{id?}");

app.Run();
