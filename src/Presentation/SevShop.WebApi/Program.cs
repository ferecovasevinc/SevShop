using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SevShop.Application.Validations.CategoryValidators;
using SevShop.Persistence.Contexts;
using SevShop.Persistence;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Persistence.Repositories;
using SevShop.Application.Shared.Helpers;
using Microsoft.AspNetCore.Identity;
using SevShop.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidatorsFromAssembly(typeof(CategoryCreateDtoValidator).Assembly);
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterService();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



builder.Services.AddAuthorization(options =>
{
    foreach (var permission in PermissionHelper.GetAllPermissionList())
    {
        options.AddPolicy(permission, policy =>
        {
            policy.RequireClaim("Permission", permission);
        });
    }
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 3;
})
.AddEntityFrameworkStores<SevShopDbContext>()
.AddDefaultTokenProviders();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SevShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

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
