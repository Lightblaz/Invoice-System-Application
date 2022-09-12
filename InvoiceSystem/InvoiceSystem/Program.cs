using InvoiceSystem.BL;
using InvoiceSystem.BL.Logics;
using AutoMapper;
using InvoiceSystem;
using DAL.DataManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();        //will create new objects  , can have many ex: 100 clients = 100 object
//builder.Services.AddSingleton<ICustomerLogic, CustomerLogic>();   //only have one customer object within the entire system
//builder.Services.AddTransient<ICustomerLogic, CustomerLogic>();   //objects made from object calls
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors(c => c.AllowAnyOrigin());
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
