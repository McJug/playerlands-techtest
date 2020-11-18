using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model.Services;
using Model.Contracts;
using Repository;
using Repository.Contracts;
using AutoMapper;
using Model;
using testapi.DTO;

namespace testapi
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
            services.SetupCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(Configuration);

            var connectionString = Configuration.GetConnectionString("Players");
            services.AddDbContext<PlayerDatabaseContext>(opt => opt.UseSqlServer(connectionString));

            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, PlayerDto>()
                    .ForMember((d) => d.Email, (opt) => opt.MapFrom(s => s.Email))
                    .ForMember((d) => d.Username, (opt) => opt.MapFrom(s => s.Username))
                    .ForMember((d) => d.Joined, (opt) => opt.MapFrom(s => s.Joined));

                cfg.CreateMap<Paged<Player>, GetPlayerPageResponseDto>()
                    .ForMember(d => d.TotalPlayers, (opt) => opt.MapFrom((s) => s.TotalRecords))
                    .ForMember(d => d.Page, (opt) => opt.MapFrom((s) => s.Page))
                    .ForMember(d => d.PageSize, (opt) => opt.MapFrom((s) => s.PageSize))
                    .IncludeMembers(s => s.Data);

                cfg.CreateMap<Player[], GetPlayerPageResponseDto>()
                    .ForMember(d => d.Players, opt => opt.MapFrom(s => s))
                    .ForMember(d => d.TotalPlayers, (opt) => opt.Ignore())
                    .ForMember(d => d.Page, (opt) => opt.Ignore())
                    .ForMember(d => d.PageSize, (opt) => opt.Ignore());
            });
            mapperConfig.AssertConfigurationIsValid();
            services.AddTransient<IMapper>((serviceProvider) => new Mapper(mapperConfig));
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

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
