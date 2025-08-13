using warehouse.Data;
using Microsoft.EntityFrameworkCore;
using warehouse.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using warehouse.Repository;
using warehouse.Data.InterfacesStockBalance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Âûםוסעט ג מעהוכüםûי פאיכ
builder.Services.AddTransient<IUnits, UnitsRepository>();
builder.Services.AddTransient<IResources, ResourscesRepository>();
builder.Services.AddTransient<IClients, ClientsRepository>();
builder.Services.AddTransient<IBalance, BalanceRepository>();




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    AppDbContext content = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DBObject.initial(content);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();      
app.UseRouting();


app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
