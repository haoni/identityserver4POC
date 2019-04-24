using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace identityserver4POC
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddIdentityServer()
                .AddInMemoryClients(identityserver4POC.Domain.Entities.Clients.Get())
                .AddInMemoryIdentityResources(identityserver4POC.Domain.Entities.Resources.GetIdentityResources())
                .AddInMemoryApiResources(identityserver4POC.Domain.Entities.Resources.GetApiResources())
                .AddTestUsers(identityserver4POC.Domain.Entities.Users.Get())
                .AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // else
            // {
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //     app.UseHsts();
            // }
            
            app.UseIdentityServer();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}


/* 
Navegue para: URL: http://localhost:5000/.well-known/openid-configuration

Usar o Postman para fazer o teste:

    POST /connect/token
    Headers:
    Content-Type: application/x-www-form-urlencoded
    Body: grant_type=client_credentials&scope=customAPI.read&client_id=oauthClient&client_secret=myPassword@2019
 */