using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repository;
using Serviceslayer.Interfaces;
using Serviceslayer.Logics;
using System.Text;
using AutoMapper;
using Serviceslayer;
using Microsoft.AspNetCore.Identity;
using pms_core_api;
using DomainLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddCors(option =>
//{
//    option.AddPolicy("PMSPolicy", a => a.WithOrigins(origins: "http://localhost:3000/").AllowAnyMethod().AllowAnyHeader());
//});
var ConnectionString = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString, opt => opt.MigrationsAssembly("RepositoryLayer")));
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
builder.Services.AddScoped<SeedDataDB>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddMvc();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepositoryModified<>), typeof(RepositoryModified<>));
builder.Services.AddTransient<IHospitalService, HospitalService>();
builder.Services.AddTransient<IHospitalLocationMasterService, HospitalLocationMasterService>();
builder.Services.AddTransient<IPriorityLevelMasterService, PriorityLevelMasterService>();
builder.Services.AddTransient<ISpecialityMasterService, SpecialityMasterService>();
builder.Services.AddTransient<IReferalStatusMasterService, ReferalStatusMasterService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDatabaseCallService, DatabaseCallService>();
builder.Services.AddTransient<IHospitalWardLocationMasterService, HospitalWardLocationMasterService>();

builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IReferalmasterService, ReferalmasterService>();
builder.Services.AddTransient<IOutlierQueueInService, OutlierQueueInService>();
builder.Services.AddTransient<IZoneBedService, ZoneBedService>();
builder.Services.AddTransient<INurseTrackingService, NurseTrackingService>();
builder.Services.AddTransient<IDischargeService, DischargeService>();
builder.Services.AddTransient<IDashboardService, DashboardService>();
builder.Services.AddTransient<IOutlierOutService, OutlierOutService>();
builder.Services.AddTransient<IClinicalRequirementMasterService, ClinicalRequirementMasterService>();
builder.Services.AddTransient<IInfectionControlMasterService, InfectionControlMasterService>();
builder.Services.AddTransient<IUserRolesService, UserRolesService>();
// For Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
//app.UseCors("PMSPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MigrateDatabase();

// Data seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dataSeeder = services.GetRequiredService<SeedDataDB>();
    dataSeeder.AddRoles();
}

app.MapControllers();



app.Run();

