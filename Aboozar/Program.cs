using Aboozar;
using Finbuckle.MultiTenant;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMultiTenant<TenantInfo>()
    .WithDelegateStrategy(Tenants.GetStrategy)
    .WithInMemoryStore(Tenants.Register);


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger(); 
app.UseSwaggerUI();


app.UseMultiTenant();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
