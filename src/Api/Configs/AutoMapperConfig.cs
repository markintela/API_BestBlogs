using Management.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configs
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CommentMappingProfile)
            );           
        }
    }
}
