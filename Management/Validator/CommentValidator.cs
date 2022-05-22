using FluentValidation;
using Model.Domain;
using ModelViewShared.ModelView.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Validator
{
    public class CommentValidator : AbstractValidator<NewCommment>
    {
        public CommentValidator() {        
            RuleFor(x => x.Content).NotNull().NotEmpty().MaximumLength(120);
            RuleFor(x => x.Author).NotNull().NotEmpty().MaximumLength(30);
        }
    }
}
