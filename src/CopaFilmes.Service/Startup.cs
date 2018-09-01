using CopaFilmes.Service.Domain.Engine;
using CopaFilmes.Service.Domain.Handlers;
using CopaFilmes.Service.Infra;
using CopaFilmes.Service.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

	    public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
	        services.AddSingleton(this.Configuration.GetSection("MoviesApiContext").Get<MoviesApiContext>());
			services.AddSingleton<IHttpWrapper, HttpWrapper>();
	        services.AddTransient<ICupEngine, CupEngine>();
			services.AddTransient<IMoviesRepository, MoviesRepository>();
	        services.AddTransient<IMoviesHandler, MoviesHandler>();

			services.AddResponseCompression(options =>
	        {
		        options.Providers.Add<BrotliCompressionProvider>();
		        options.EnableForHttps = true;
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
	        app.UseResponseCompression();
        }
    }
}
