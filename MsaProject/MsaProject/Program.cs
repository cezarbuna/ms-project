using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MsaProject.Application.Commands.CustomerCommands;
using MsaProject.Application.Commands.MenuCommands;
using MsaProject.Application.Commands.MenuItemCommands;
using MsaProject.Dal;
using MsaProject.Dal.Repositories;
using MsaProject.Domain.IRepositories;
using MsaProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
        .GetConnectionString(@"Server=DESKTOP-FOFN1JI;Database=Database1;Trusted_Connection=True;TrustServerCertificate=True;")));

builder.Services.AddMediatR(typeof(CreateCustomerCommand));
builder.Services.AddMediatR(typeof(CreateMenuItemCommand));
builder.Services.AddMediatR(typeof(CreateMenuCommand));

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
