using Hackathon.Infra.Data.Context;
using Hackathon.Infra.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("The connection string 'DefaultConnection' is missing or empty."); ;

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString).UseLazyLoadingProxies());

builder.Services.AddControllers();
builder.Services.AddDIConfiguration();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
        }
        );
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("Jwt:Key").Value!))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
