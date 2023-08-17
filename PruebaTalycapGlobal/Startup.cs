using DataTransferObjects;
using Logic;
using Logic.BodegaLogic;
using Logic.ClienteLogic;
using Logic.EnvioLogic;
using Logic.EnvioMaritimoLogic;
using Logic.EnvioTerrestreLogic;
using Logic.ProductoLogic;
using Logic.PuertoLogic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Repository;
using System;
using System.Text;

namespace PruebaTalycapGlobal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();            

            //Configuracion Cors Origin
            services.AddCors(options =>
            {
                options.AddPolicy("AllowWebApp",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            // Configurar AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Se realiza la configuracion de la inyección de dependencias.
            services.AddScoped<IBodegaRepository, BodegaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnvioRepository, EnvioRepository>();
            services.AddScoped<IEnvioMaritimoRepository, EnvioMaritimoRepository>();
            services.AddScoped<IEnvioTerrestreRepository, EnvioTerrestreRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IPuertoRepository, PuertoRepository>();


            services.AddScoped<IBodegaLogic, BodegaLogic>();
            services.AddScoped<IClienteLogic, ClienteLogic>();
            services.AddScoped<IEnvioLogic, EnvioLogic>();
            services.AddScoped<IEnvioMaritimoLogic, EnvioMaritimoLogic>();
            services.AddScoped<IEnvioTerrestreLogic, EnvioTerrestreLogic>();
            services.AddScoped<IProductoLogic, ProductoLogic>();
            services.AddScoped<IPuertoLogic, PuertoLogic>();

            //Configuracion conexion a base de datos
            services.AddDbContext<AplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opciones => opciones.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                    ClockSkew = TimeSpan.Zero
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaTalycapGlobal", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

            });



            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AplicationDbContext>()
                .AddDefaultTokenProviders();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaTalycapGlobal v1"));
            }

            app.UseCors("AllowWebApp");

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
