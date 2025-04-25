using XPE.SoftwareArch.FinalChallenge.Api.Extensions;
using XPE.SoftwareArch.FinalChallenge.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddCustomSwaggerGen(); 
builder.Services.AddEndpointsApiExplorer();

// Dependency injections
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();