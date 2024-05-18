using Domain.EFCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.GenericRepositoryPattern.Functionality;
using Infrastructure.GenericRepositoryPattern.Repository;
using Service;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
//Dynamic migrations


//builder.Services.AddDbContext<UserDBContext>(t => t.UseSqlServer(builder.Configuration["ConnectionString:Myconn"], b => b.MigrationsAssembly("UserManagement.API")));

//builder.Services.AddDbContext<UserDBContext>(t => t.UseSqlServer(builder.Configuration["ConnectionString:Myconn"], b => b.MigrationsAssembly("UserManagement.API")));
builder.Services.AddDbContext<UserDBContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


