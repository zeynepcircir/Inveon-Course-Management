using CourseManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Service.Services;
using CourseManagement.Core.UnitOfWorks;
using CourseManagement.Repository.UnitOfWorks;
using CourseManagement.Service.Mapping;
using CourseManagement.Repository.Contexts;
using CourseManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;
using CourseManagement.Repository.Seeds;
using CourseManagement.Core.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configuration
builder.Services.Configure<JWTOptionsDTO>(builder.Configuration.GetSection("JWT"));

// DbContext
builder.Services.AddDbContext<CourseManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<CourseManagementDbContext>()
    .AddDefaultTokenProviders();

// Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
builder.Services.AddScoped<ICourseChapterRepository, CourseChapterRepository>();
builder.Services.AddScoped<IStudentChapterRepository, StudentChapterRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartCourseRepository, ShoppingCartCourseRepository>();

// Services
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapProfile));

// JWT Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyHeader() 
                   .AllowAnyMethod(); 
        });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var studentRepository = services.GetRequiredService<IStudentRepository>();
    var instructorRepository = services.GetRequiredService<IInstructorRepository>();
    var unitOfWork = services.GetRequiredService<IUnitOfWork>();

    var dbSeeder = new ApplicationUserSeed(userManager, roleManager,
                                           studentRepository, instructorRepository,
                                           unitOfWork);
    await dbSeeder.SeedAsync();
}

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();