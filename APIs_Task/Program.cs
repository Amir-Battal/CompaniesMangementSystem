using APIs_Task.Models;
using APIs_Task.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IBranchService, BranchService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICreateService, CreateService>();
builder.Services.AddTransient<ISupplyService, SupplyService>();
builder.Services.AddTransient<IReportService, ReportService>();


builder.Services.AddCors();

builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (    app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
