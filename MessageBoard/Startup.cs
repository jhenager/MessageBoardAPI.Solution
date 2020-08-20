using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace MessageBoard
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
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
        });

      services.AddDbContext<MessageBoardContext>(opt =>
        opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
      services.AddMvc()
        .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      // Register the Swagger services
      services.AddSwaggerDocument(config =>
      {
        config.PostProcess = document =>
        {
          document.Info.Version = "v1";
          document.Info.Title = "Message Board API";
          document.Info.Description = "Sudo is the best, Sudo number 1";
          document.Info.TermsOfService = "Our terms, your service";
          document.Info.Contact = new NSwag.OpenApiContact
          {
            Name = "Ian Scott",
            Email = "chesnekov@gmail.com"
          };
          document.Info.License = new NSwag.OpenApiLicense
          {
            Name = "Use under MIT",
            Url = "https://opensource.org/licenses/MIT"
          };
        };
      });

      services.AddCors(options => 
      {
        options.AddPolicy("CorsPolicy",
          builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        .Build());
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      // Register the Swagger generator and the Swagger UI middlewares
      app.UseOpenApi();
      app.UseSwaggerUi3();
      // app.UseHttpsRedirection();
      app.UseAuthentication();
      app.UseCors("CorsPolicy");
      app.UseMvc();
    }
  }
}
