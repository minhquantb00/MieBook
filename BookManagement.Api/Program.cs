using BookManagement.Application.Handle.Email;
using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.CreateBook;
using BookManagement.Application.UseCases.Book_UseCase.DeleteBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBookById;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Book_UseCase.UpdateBook;
using BookManagement.Application.UseCases.Category_UseCase.CreateCategory;
using BookManagement.Application.UseCases.Category_UseCase.DeleteCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategoryById;
using BookManagement.Application.UseCases.Category_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Category_UseCase.UpdateCategory;
using BookManagement.Application.UseCases.Contact_UseCase.CreateContact;
using BookManagement.Application.UseCases.Contact_UseCase.DeleteContact;
using BookManagement.Application.UseCases.Contact_UseCase.GetContact;
using BookManagement.Application.UseCases.Contact_UseCase.GetContactById;
using BookManagement.Application.UseCases.Contact_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Contact_UseCase.UpdateContact;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.CreateDiscountEvent;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.DeleteDiscountEvent;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEvent;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEventById;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.UpdateDiscountEvent;
using BookManagement.Application.UseCases.EventBook_UseCase.GetEventBook;
using BookManagement.Application.UseCases.EventBook_UseCase.GetEventBookById;
using BookManagement.Application.UseCases.EventBook_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.EventBook_UseCase.UpdateEventBook;
using BookManagement.Application.UseCases.Role_UseCase.CreateRole;
using BookManagement.Application.UseCases.Role_UseCase.DeleteRole;
using BookManagement.Application.UseCases.Role_UseCase.GetRole;
using BookManagement.Application.UseCases.Role_UseCase.GetRoleById;
using BookManagement.Application.UseCases.Role_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Role_UseCase.UpdateRole;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.CreateShippingMethod;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.DeleteShippingMethod;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethod;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethodById;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.UpdateShippingMethod;
using BookManagement.Application.UseCases.TopicBook_UseCase.CreateTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.DeleteTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBookById;
using BookManagement.Application.UseCases.TopicBook_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.TopicBook_UseCase.UpdateTopicBook;
using BookManagement.Application.UseCases.User_UseCase.ChangePassword;
using BookManagement.Application.UseCases.User_UseCase.ConfirmCreateNewPassword;
using BookManagement.Application.UseCases.User_UseCase.ForgotPassword;
using BookManagement.Application.UseCases.User_UseCase.GetUser;
using BookManagement.Application.UseCases.User_UseCase.GetUserById;
using BookManagement.Application.UseCases.User_UseCase.Login;
using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.User_UseCase.Register;
using BookManagement.Application.UseCases.Voucher_UseCase;
using BookManagement.Application.UseCases.Voucher_UseCase.CreateVoucher;
using BookManagement.Application.UseCases.Voucher_UseCase.DeleteVoucher;
using BookManagement.Application.UseCases.Voucher_UseCase.GetVoucher;
using BookManagement.Application.UseCases.Voucher_UseCase.GetVoucherById;
using BookManagement.Application.UseCases.Voucher_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Voucher_UseCase.UpdateVoucher;
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
builder.Services.AddScoped<IUseCase<CreateCategoryUseCaseInput, CreateCategoryUseCaseOutput>, CreateCategoryUseCase>();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
builder.Services.AddScoped<IUseCase<DeleteCategoryUseCaseInput, DeleteCategoryUseCaseOutput>,  DeleteCategoryUseCase>();  
builder.Services.AddScoped<IUseCase<UpdateCategoryUseCaseInput, UpdateCategoryUseCaseOutput>, UpdateCategoryUseCase>();
builder.Services.AddScoped<IUseCase<GetCategoryUseCaseInput, GetCategoryUseCaseOutput>, GetCategoryUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetCategoryByIdUseCaseOutput>, GetCategoryByIdUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetUserByIdUseCaseOutput>, GetUserByIdUserCase>();
builder.Services.AddScoped<IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>, GetUserUseCase>();
builder.Services.AddScoped<IUseCase<CreateTopicBookUseCaseInput, CreateTopicBookUseCaseOutput>, CreateTopicBookUseCase>();
builder.Services.AddScoped<IUseCase<UpdateTopicBookUseCaseInput, UpdateTopicBookUseCaseOutput>, UpdateTopicBookUseCase>();
builder.Services.AddScoped<IUseCase<DeleteTopicBookUseCaseInput, DeleteTopicBookUseCaseOutput>, DeleteTopicBookUseCase>();
builder.Services.AddScoped<IUseCase<GetTopicUseCaseInput, GetTopicUseCaseOutput>, GetTopicUseCase>();
builder.Services.AddScoped<IUseCase<GetVoucherUseCaseInput, GetVoucherUseCaseOutput>, GetVoucherUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetTopicBookByIdUseCaseOutput>, GetTopicBookByIdUseCase>();
builder.Services.AddScoped<IRepository<Voucher>, Repository<Voucher>>();
builder.Services.AddScoped<IUseCase<CreateVoucherUseCaseInput, CreateVoucherUseCaseOutput>, CreateVoucherUseCase>();
builder.Services.AddScoped<IUseCase<DeleteVoucherUseCaseInput, DeleteVoucherUseCaseOutput>, DeleteVoucherUseCase>();
builder.Services.AddScoped<IUseCase<UpdateVoucherUseCaseInput, UpdateVoucherUseCaseOutput>, UpdateVoucherUseCase>();
builder.Services.AddScoped<IUseCase<CreateContactUseCaseInput, CreateContactUseCaseOutput>, CreateContactUseCase>();
builder.Services.AddScoped<IUseCase<DeleteContactUseCaseInput, DeleteContactUseCaseOutput>, DeleteContactUseCase>();
builder.Services.AddScoped<IUseCase<UpdateContactUseCaseInput, UpdateContactUseCaseOutput>, UpdateContactUseCase>();
builder.Services.AddScoped<IUseCase<CreateDiscountEventUseCaseInput, CreateDiscountEventUseCaseOutput>, CreateDiscountEventUseCase>();
builder.Services.AddScoped<IUseCase<DeleteDiscountEventUseCaseInput, DeleteDiscountEventUseCaseOutput>, DeleteDiscountEventUseCase>();
builder.Services.AddScoped<IUseCase<UpdateDiscountEventUseCaseInput, UpdateDiscountEventUseCaseOutput>, UpdateDiscountEventUseCase>();
builder.Services.AddScoped<IUseCase<CreateBookUseCaseInput, CreateBookUseCaseOutput>, CreateBookUseCase>();
builder.Services.AddScoped<IUseCase<GetDiscountEventUseCaseInput, GetDiscountEventUseCaseOutput>, GetDiscountEventUseCase>();
builder.Services.AddScoped<IUseCase<CreateRoleUseCaseInput, CreateRoleUseCaseOutput>, CreateRoleUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetDiscountEventByIdUseCaseOutput>, GetDiscountEventByIdUseCase>();
builder.Services.AddScoped<IUseCase<GetContactUseCaseInput, GetContactUseCaseOutput>, GetContactUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetContactByIdUseCaseOutput>, GetContactByIdUseCase>();
builder.Services.AddScoped<IUseCase<GetRoleUseCaseInput, GetRoleUseCaseOutput>, GetRoleUseCase>();
builder.Services.AddScoped<IUseCase<DeleteBookUseCaseInput, DeleteBookUseCaseOutput>, DeleteBookUseCase>();
builder.Services.AddScoped<IUseCase<GetBookUseCaseInput, GetBookUseCaseOutput>, GetBookUseCase>();
builder.Services.AddScoped<IUseCase<UpdateBookUseCaseInput, UpdateBookUseCaseOutput>, UpdateBookUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetBookByIdUseCaseOutput>, GetBookByIdUseCase>();
builder.Services.AddScoped<BookConverter>();
builder.Services.AddScoped<IUseCaseGetById<long, GetRoleByIdUseCaseOutput>, GetRoleByIdUseCase>();
builder.Services.AddScoped<IUseCase<UpdateRoleUseCaseInput, UpdateRoleUseCaseOutput>, UpdateRoleUseCase>();
builder.Services.AddScoped<IUseCase<DeleteRoleUseCaseInput, DeleteRoleUseCaseOutput>, DeleteRoleUseCase>();
builder.Services.AddScoped<IRepository<Contact>, Repository<Contact>>();
builder.Services.AddScoped<IUseCaseGetById<long, GetVoucherByIdUseCaseOutput>, GetVoucherByIdUseCase>();
builder.Services.AddScoped<IUseCase<CreateShippingMethodUseCaseInput, CreateShippingMethodUseCaseOutput>, CreateShippingMethodUseCase>();
builder.Services.AddScoped<IUseCase<DeleteShippingMethodUseCaseInput, DeleteShippingMethodUseCaseOutput>, DeleteShippingMethodUseCase>();
builder.Services.AddScoped<IUseCase<UpdateShippingMethodUseCaseInput, UpdateShippingMethodUseCaseOutput>, UpdateShippingMethodUseCase>();
builder.Services.AddScoped<IUseCase<GetShippingMethodUseCaseInput, GetShippingMethodUseCaseOutput>, GetShippingMethodUseCase>();
builder.Services.AddScoped<IUseCase<CreateDiscountEventUseCaseInput, CreateDiscountEventUseCaseOutput>, CreateDiscountEventUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetShippingMethodByIdUseCaseOutput>, GetShippingMethodByIdUseCase>();
builder.Services.AddScoped<IUseCase<DeleteDiscountEventUseCaseInput, DeleteDiscountEventUseCaseOutput>, DeleteDiscountEventUseCase>();
builder.Services.AddScoped<IUseCase<UpdateEventBookUseCaseInput, UpdateEventBookUseCaseOutput>, UpdateEventBookUseCase>();
builder.Services.AddScoped<IUseCase<GetEventBookUseCaseInput, GetEventBookUseCaseOutput>, GetEventBookUseCase>();
builder.Services.AddScoped<IUseCaseGetById<long, GetEventBookByIdUseCaseOutput>, GetEventBookByIdUseCase>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<IRepository<EventBook>, Repository<EventBook>>();
builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
builder.Services.AddScoped<CategoryConverter>();
builder.Services.AddScoped<IRepository<UserRole>, Repository<UserRole>>();
builder.Services.AddScoped<IRepository<RefreshToken>, Repository<RefreshToken>>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IRepository<ConfirmEmail>, Repository<ConfirmEmail>>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRepository<AddressUser>, Repository<AddressUser>>();
builder.Services.AddScoped<UserConverter>();
builder.Services.AddScoped<IRepository<ShippingMethod>, Repository<ShippingMethod>>();
builder.Services.AddScoped<IRepository<TopicBook>, Repository<TopicBook>>();
builder.Services.AddScoped<IRepository<DiscountEvent>, Repository<DiscountEvent>>();
builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<TopicBookConverter>();
builder.Services.AddScoped<VoucherConverter>();
builder.Services.AddScoped<ContactConverter>();
builder.Services.AddScoped<DiscountEventConverter>();
builder.Services.AddScoped<RoleConverter>();
builder.Services.AddScoped<ShippingMethodConverter>();
builder.Services.AddScoped<EventBookConverter>();
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
