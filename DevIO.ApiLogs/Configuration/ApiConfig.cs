using DevIO.APILogs.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace DevIO.APILogs.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddControllers();

            //##################################################################################################

            /*Corrigindo o erro “Um possível ciclo de objeto foi detectado” em diferentes versões do ASP.NET Core

                Para corrigir o erro:

                System.Text.Json.JsonException: Um possível ciclo de objeto foi detectado. Isso pode ser devido a um ciclo ou se a profundidade do objeto for maior do que a profundidade máxima permitida de 32. Considere o uso de ReferenceHandler.Preserve em JsonSerializerOptions para oferecer suporte a ciclos.

                Você tem pelo menos duas opções:

                1)Evitando referências circulares
                2)Ignorando referências circulares

                Vou assumir que a opção 1 (que geralmente é ideal) não é viável para você.

                A opção 2 é literalmente uma pequena instrução na classe Startup, no método ConfigureServices (isso é para ASP.NET Core 6+ ):

                services.AddControllers().AddJsonOptions(x =>
                                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

                Se você usa ASP.NET Core 5 :

                services.AddControllers().AddJsonOptions(x =>
                   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

                Se estiver usando ASP.NET Core 3.1 ou menos , você pode fazer o seguinte:

                Instale a biblioteca: Microsoft.AspNetCore.Mvc.NewtonsoftJson (instale a versão correspondente, se você tiver ASP.NET Core 3.1, instale a versão 3.1 da biblioteca)

                Então, em ConfigureServices:

                services.AddControllers().AddNewtonsoftJson(x =>
                 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); */

            services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //###################################################################################################

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .WithMethods("GET")
                            .WithOrigins("https://github.com/deivideregis/")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                            .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Development"); // Usar apenas nas demos => Configuração Ideal: Production
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/api/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecksUI(options =>
                {
                    options.UIPath = "/api/hc-ui";
                    options.ResourcesPath = "/api/hc-ui-resources";

                    options.UseRelativeApiPath = false;
                    options.UseRelativeResourcesPath = false;
                    options.UseRelativeWebhookPath = false;
                });

            });

            return app;
        }
    }
}
