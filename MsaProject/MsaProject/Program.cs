using MediatR;
using Microsoft.EntityFrameworkCore;
using MsaProject.Dal;
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

builder.Services.AddDbContext<MsaProjectDbContext>(options =>
        options.UseSqlServer(builder.Configuration
        .GetConnectionString(@"Server=DESKTOP-DLVFJ7V\SQLEXPRESS;Database=Database1;Trusted_Connection=True;")));

//builder.Services.AddMediatR(typeof(Program));
//builder.Services.AddAutoMapper(typeof(Program));

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
