using System.Text.Json.Serialization;
using WebShop.Repositories;
using WebShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//TODO all injected services should derive from an interface
builder.Services.AddSingleton<CustomerRepository>(new CustomerRepository());
builder.Services.AddSingleton<ProductRepository>(new ProductRepository());
builder.Services.AddSingleton<OrderRepository>(new OrderRepository());
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddControllers().AddJsonOptions(opt => {
    opt.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});
;
builder.Services.AddProblemDetails();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
