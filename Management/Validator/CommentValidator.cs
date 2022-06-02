using FluentValidation;
using Manager.Interfaces.Repository;
using Model.Domain;
using ModelViewShared.ModelView.Comment;
using ModelViewShared.ModelView.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Validator
{
    public class CommentValidator : AbstractValidator<NewCommment>
    {

        public CommentValidator(IPostRepository repository) {        
            RuleFor(x => x.Content).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(x => x.Author).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(x => x.Post).SetValidator(new PostReferenceValidator(repository));
        }


       
    }
}
