using Vanto.Application;
using Vanto.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();
app.UseHttpsRedirection();

app.Run();