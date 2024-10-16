using BookManagement.Application.Handle.Email;
using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.User_UseCase.ChangePassword;
using BookManagement.Application.UseCases.User_UseCase.ConfirmCreateNewPassword;
using BookManagement.Application.UseCases.User_UseCase.ForgotPassword;
using BookManagement.Application.UseCases.User_UseCase.Login;
using BookManagement.Application.UseCases.User_UseCase.Register;
using BookManagement.Commons.Configuration;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using BookManagement.Infrastructure.Configure;
using BookManagement.Infrastructure.DataAccess;
using BookManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(x => x.AddPolicy("corsGlobalPolicy", builder =>
{
    builder.WithOrigins("http://localhost:8080", "http://localhost:8081", "https://localhost:8081", "https://localhost:8080", "http://localhost:5173", "http://localhost:5174", "http://localhost:7027")
    .SetIsOriginAllowedToAllowWildcardSubdomains()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
}));
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromMinutes(5);
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

//Add Email Configs
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);


builder.Services.AddScoped<IDbContext, AppDbContext>();
builder.Services.AddScoped<IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>, RegisterUserUseCase>();
builder.Services.AddScoped<IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>, LoginUserUseCase>();
builder.Services.AddScoped<IUseCase<ChangePasswordUseCaseInput, ChangePasswordUseCaseOutput>, ChangePasswordUseCase>();
builder.Services.AddScoped<IUseCase<ForgotPasswordUseCaseInput, ForgotPasswordUseCaseOutput>, ForgotPasswordUseCase>();
builder.Services.AddScoped<IUseCase<ConfirmCreateNewPasswordUseCaseInput, ConfirmCreateNewPasswordUseCaseOutput>, ConfirmCreateNewPasswordUseCase>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<IRepository<UserRole>, Repository<UserRole>>();
builder.Services.AddScoped<IRepository<RefreshToken>, Repository<RefreshToken>>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IRepository<ConfirmEmail>, Repository<ConfirmEmail>>();
builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("corsGlobalPolicy");

app.MapControllers();

app.Run();
