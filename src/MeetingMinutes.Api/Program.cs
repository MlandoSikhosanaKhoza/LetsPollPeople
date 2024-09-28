using MeetingMinutes.BusinessLogic;
using MeetingMinutes.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")??"";
// Add services to the container.

//Set you serialization options
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler     = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject Repositories (Data Access Layer) and Business Logic
builder.Services.AddRepository().AddBusinessLogic();

//Add Mapper
builder.Services.AddAutoMapper(typeof(Mapping));

//Allow access from the front end website
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("https://localhost:7111").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

//DbContext Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MeetingMinutes.Api"));
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
    });
});

//Add Jwt Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken                 = true;
    options.RequireHttpsMetadata      = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {

        ValidateIssuer   = true,
        ValidateAudience = true,
        ValidAudience    = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer      = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"] ?? ""))

    };
});

builder.Services.AddHttpContextAccessor();
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

app.UseCors();
app.Run();