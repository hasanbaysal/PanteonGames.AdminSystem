
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PanteionGames.AdminSystem.DataAccess.DependencyResolver;
using PanteonGames.AdminSystem.Business.DependencyResolver;
using PanteonGames.AdminSystem.Helper.Options;
using System.Text;

namespace PanteonGames.AdminSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOptions"));
            builder.Services.Configure<MongoDbConfigOption>(builder.Configuration.GetSection("MongoDBConfig"));

            builder.Services.AddDataAccessDependencies(builder.Configuration.GetConnectionString("MySqlCon")!);
            builder.Services.AddBusinessDependcies();

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOption>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new()
                    {
                        ValidIssuer
                            = tokenOptions!.Issuer,
                        ValidAudience
                            = tokenOptions.Audience,
                        IssuerSigningKey
                            = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                        ValidateIssuerSigningKey = true
                    };
                });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });


            var app = builder.Build();
            //app.Urls.Add("http://80.253.246.85:5000");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
