using Management.Implementation;
using Management.Interfaces.Repository;
using Management.Manager;
using Manager.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repository;

namespace Api.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICommentManager, CommentManager>();
            services.AddScoped<IPostManager, PostManager>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
