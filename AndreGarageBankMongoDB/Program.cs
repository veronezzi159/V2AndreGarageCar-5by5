using AndreGarageBankMongoDB.Utils;
using AndreGarageBankMongoDB.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DataBaseSettings>(
    builder.Configuration.GetSection(nameof(DataBaseSettings)));

builder.Services.AddSingleton<IDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DataBaseSettings>>().Value);

builder.Services.AddSingleton<BankServiceMongo>();

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
