using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MsaProject.Application.Commands.CustomerCommands;
using MsaProject.Application.Commands.MenuCommands;
using MsaProject.Application.Commands.MenuItemCommands;
using MsaProject.Application.Commands.OwnerCommands;
using MsaProject.Application.Commands.ReservationCommands;
using MsaProject.Application.Commands.RestaurantCommands;
using MsaProject.Application.Commands.TableCommands;
using MsaProject.Dal;
using MsaProject.Dal.Repositories;
using MsaProject.Domain.IRepositories;
using MsaProject.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = "temporary_key_to_be_replaced";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200") // Your Angular app's host and port
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddSingleton(new JwtTokenService(key));

builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddDbContext<MsaProjectDbContext>(options =>
        options.UseSqlServer(builder.Configuration
        .GetConnectionString(@"Server=DESKTOP-DLVFJ7V\SQLEXPRESS;Database=Database2;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;")));

builder.Services.AddMediatR(typeof(CreateCustomerCommand));
builder.Services.AddMediatR(typeof(CreateMenuItemCommand));
builder.Services.AddMediatR(typeof(CreateMenuCommand));
builder.Services.AddMediatR(typeof(CreateRestaurantCommand));
builder.Services.AddMediatR(typeof(CreateTableCommand));
builder.Services.AddMediatR(typeof(CreateReservationCommand));
builder.Services.AddMediatR(typeof(CreateOwnerCommand));

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin"); // Use the CORS policy
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
