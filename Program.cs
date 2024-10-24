using ASP.NET__web_API_Project.Repositories.implementations;
using ASP.NET__web_API_Project.Repositories.Interfaces;
using ASP.NET__web_API_Project.Services.Implementations;
using ASP.NET__web_API_Project.Services.Interfaces;
using ASP.NET_web_API_Project.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(ConnectionString));
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<OrderRepository>();
builder.Services.AddTransient<ProductRepository>();

builder.Services.AddTransient< CategoryService>();
builder.Services.AddTransient< CustomerService>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<ProductService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
