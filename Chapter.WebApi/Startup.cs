using Chapter.WebApi.Contexts;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Chapter.WebApi
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
            //services.AddRazorPages();

            //Adiciona os servi�os necess�rios
            services.AddControllers();
            // Se n�o existir uma instancia na mem�ria da aplica��o, � criada uma nova
            services.AddScoped<ChapterContext, ChapterContext>();

            //services.AddDbContext<ChapterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ChapterContext")));

            services.AddTransient<LivroRepository, LivroRepository>();

            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChapterApi", Version = "v1" });
            });*/
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // � usado para especificar como o aplicativo responde �s solicita��es HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // ativa o middle para o uso do swagger
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChapterApi v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            // Mapear os controllers
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
