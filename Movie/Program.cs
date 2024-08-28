
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Movie.Entity;
using Movie.Repository.MovieRepository;
using System.Text;

namespace Movie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectioString = builder.Configuration.GetConnectionString("cs");
            builder.Services.AddDbContext<MovieDataBase>(op => {
                op.UseSqlServer(connectioString);
                });
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MovieDataBase>();
            builder.Services.AddAuthentication(op => op.DefaultAuthenticateScheme = "myschema")
                            .AddJwtBearer("myschema", op =>
                            {
string key= "Loai saber Elsayed BulNoor Tyseer Hesham AbulNoor";
          var secKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                                op.TokenValidationParameters = new TokenValidationParameters()
                                {
IssuerSigningKey = secKey,
ValidateIssuer=false ,
ValidateAudience=false 
                                };

                            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
