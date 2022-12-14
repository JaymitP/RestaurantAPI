using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using RestaurantAPI.Data.Domain;
using RestaurantAPI.Data.Persistence;
using RestaurantAPI.Services.Handlers;
using RestaurantAPI.Services.Requirements;
using Supermarket.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
{
    apiBehaviorOptions.InvalidModelStateResponseFactory = actionContext =>
    {

        return new BadRequestObjectResult(actionContext.ModelState.GetErrorMessages());
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enforce lower case routing
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Audience = "restaurantapi";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsEmployee", policy => policy.Requirements.Add(new RequiredRoleRequirement(new List<string> { "Administrator", "Waiter", "Chef" })));
    // options.AddPolicy("IsAdmin", policy => policy.RequireClaim("IsAdmin", "true"));
});
builder.Services.AddSingleton<IAuthorizationHandler, RequiredRoleHandler>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<OrdersContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddDbContext<EmployeesContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<IOrdersRepo, SqlOrdersRepo>();
builder.Services.AddScoped<IEmployeeRepo, SqlEmployeeRepo>();
builder.Services.AddScoped<IMenuItemRepo, SqlMenuItemRepo>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    IdentityModelEventSource.ShowPII = true;
}
// app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
