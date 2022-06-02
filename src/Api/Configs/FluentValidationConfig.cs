using FluentValidation.AspNetCore;
using Management.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configs
{
    public static class FluentValidationConfig
    {

        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<PostValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<CommentValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PostReferenceValidator>();

                });
           
        }
    }
}
