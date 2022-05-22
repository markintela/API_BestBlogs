using FluentValidation;
using Model.Domain;
using ModelViewShared.ModelView.Comment;
using ModelViewShared.ModelView.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Validator
{
    public class PostValidator : AbstractValidator<NewPost>
    {

        public PostValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(x => x.Content).NotNull().NotEmpty().MaximumLength(1200);

        }

    }
}
