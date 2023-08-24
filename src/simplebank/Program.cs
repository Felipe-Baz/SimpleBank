using Microsoft.EntityFrameworkCore;
using simplebank.Data;
using simplebank.Facades;
using simplebank.Facades.interfaces;
using simplebank.Model;
using simplebank.Repositories;
using simplebank.Repositories.Interfaces;
using simplebank.Services;
using simplebank.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Facades
builder.Services.AddTransient<IUserFacade, UserFacade>();
builder.Services.AddTransient<ITransferFacade, TransferFacade>();

// Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITransferService, TransferService>();

// Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();

// Mappers
builder.Services.AddAutoMapper(typeof(User));
builder.Services.AddAutoMapper(typeof(Transfer));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
