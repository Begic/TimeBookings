using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using TimeBooking.Db;
using TimeBooking.Db.Contracts;
using TimeBooking.Db.Entities;
using TimeBooking.Db.Providers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices(conf => conf.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight);

builder.Services.AddTransient<IUserProvider, UserProvider>();
builder.Services.AddTransient<ITimeBookingProvider, TimeBookingProvider>();
builder.Services.AddTransient<ITimeBookingDetailProvider, TimeBookingDetailProvider>();

builder.Services.AddDbContextFactory<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var db = scope.ServiceProvider.GetService<IDbContextFactory<DataBaseContext>>().CreateDbContext())
{
    await db.Database.MigrateAsync();
    if (!db.Users.Any())
    {
        await db.Users.AddAsync(new User
        {
            FirstName = "John",
            LastName = "Wick",
            Birthday = DateTime.Now,
            Email = "JohnWick@gmail.com"
        });
    }
    await db.SaveChangesAsync();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();