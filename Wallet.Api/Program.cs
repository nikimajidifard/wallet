using Wallet.Application.Services;
using wallet.Domain.Entities;
using Wallet.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Wallet.Infrastructure.Data;
using Wallet.Application.Mapper;
using AutoMapper;
using static Wallet.Application.Mapper.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICompany, CompanyServices>();
builder.Services.AddScoped<ILabel, LabelServices>();
builder.Services.AddScoped<INotification, NotificationServices>();
builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IWallet, WalletServices>();
builder.Services.AddScoped<IVoucher, VoucherServices>();

// Add AutoMapper configuration
builder.Services.AddAutoMapper(typeof(WalletMappingProfile));

builder.Services.AddControllers();
builder.Services.AddDbContext<PurseDbContext>(options =>
{
    // Configure your database connection here
    options.UseSqlServer(@"Server=DESKTOP-CMR9S4V;Database=WalletDb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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