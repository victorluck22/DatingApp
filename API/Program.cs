using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationsServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
    

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(["http://localhost:4200", "https://localhost:4200"]));

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();