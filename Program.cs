
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Repo;
using LearningManagmentSystem.Core.Service;
using LearningManagmentSystem.Infra.Repo;
using LearningManagmentSystem.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;

namespace LearningManagmentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            ///////// Register the DbContext for SQL Server, Repo, and Service in the Program.cs /////////////
            
            /////////////////////////////////////////////////////////////////////////////
            builder.Services.AddDbContext<LmsdemoDbContext>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IStudentRepo,StudentRepo>();
            builder.Services.AddScoped<IStudentService,StudentService>();
            builder.Services.AddScoped<ILoginRepo,LoginRepo>();
            builder.Services.AddScoped<ILoginService,LoginService>();
            builder.Services.AddScoped<IStdCourseRepo, StdCourseRepo>();
            builder.Services.AddScoped<IStdCourseService, StdCourseService>();
            builder.Services.AddScoped<IRoleRepo, RoleRepo>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAuthRepo, AuthRepo>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            /////////////////////////////////////////////////////////////////////////////

            // after install packages you must put configration 
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                    };
                });
            //////////////////////////////////////////////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();//firstly we do Authentication then Authorization for Login
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
