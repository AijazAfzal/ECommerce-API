using Ecommerce_Domain.IRepository;
using Ecommerce_Infrastructure.ECommerce_DbContext;
using Ecommerce_Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var globalServicesCollection = builder.Services;
//globalServicesCollection.AddControllers();
//globalServicesCollection.AddHttpContextAccessor(); 

//globalServicesCollection.AddEndpointsApiExplorer(); 
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("ECommerce_Business")); 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommerceDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ECommerce_DB")));
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IPaymentRepository, PayementRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>(); 




//builder.Services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);  

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
