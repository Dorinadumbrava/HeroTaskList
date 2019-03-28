using GraphQL;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using HeroTaskList.EntityFramework;
using HeroTaskList.GraphQL;
using HeroTaskList.Repositories;
using HeroTaskList.Repository_Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HeroTaskList
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.AddScoped<IHeroTaskListDbContext, HeroTaskListDbContext>();
            services.AddScoped<IDbContextSeeder, DbContextSeeder>();
            services.AddScoped<HeroTaskListSchema>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IAssignmentStatusRepository, AssignmentStatusRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubTaskRepository, SubTaskRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(
                s.GetRequiredService));
            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader()
                .AddWebSockets();
            services.AddCors();
            services.AddDbContext<HeroTaskListDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:HeroTaskListDB"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHeroTaskListDbContext dbContext,
            IDbContextSeeder contextSeeder)
        {
            app.UseGraphiQl("/graphql");
            app.UseWebSockets();
            app.UseGraphQLWebSockets<HeroTaskListSchema>("/graphql");
            app.UseGraphQL<HeroTaskListSchema>();
            dbContext.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            contextSeeder.Seed(dbContext);
        }
    }
}
