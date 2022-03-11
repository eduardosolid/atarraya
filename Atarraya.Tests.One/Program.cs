using Microsoft.EntityFrameworkCore;
using Atarraya.Tests.One.Data;
using Atarraya.Tests.One.Data.Repositories;
using Atarraya.Tests.One.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<PeopleService>()
    .AddScoped<PeopleRepository>()
    .AddDbContext<DemoOneContext>(options =>
    {
        bool postgresql = true;
        if (postgresql == true)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
        }
        else // in Memory
        { 
            options.UseInMemoryDatabase(databaseName: "InMemory_DB");
        }
    });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();