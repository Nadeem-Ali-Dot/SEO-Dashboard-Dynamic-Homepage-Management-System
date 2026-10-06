using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGallery, GalleryService>();
builder.Services.AddScoped<IContactInformation, ContactInformationService>();
builder.Services.AddScoped<Iaboutsection, AboutSectionService>();
builder.Services.AddScoped<IHeroSection, HeroSectionService>();
builder.Services.AddScoped<IOccasions, OccasionsService>();
builder.Services.AddScoped<IRole, RoleService>();
builder.Services.AddScoped<ISeoSettings,SeoSettingsService>();
builder.Services.AddScoped<ITestimonials,TestimonialsService>();
builder.Services.AddScoped<IVehicles,VehiclesService>();
builder.Services.AddScoped<IUser,UserService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddDbContext<ApplicationDbContext>(optinos =>
{
    optinos.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
