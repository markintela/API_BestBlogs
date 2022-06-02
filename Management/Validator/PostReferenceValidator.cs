using FluentValidation;
using Manager.Interfaces.Repository;
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
    public class PostReferenceValidator : AbstractValidator<PostReference>
    {
        private readonly IPostRepository _repository;

        public PostReferenceValidator(IPostRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Id).NotEmpty()
                 .Must(ExistInDataBase).WithMessage("This post does not exist!");
        }


        private bool ExistInDataBase(Guid id)
        {
            return _repository.ValidationExistInDatabase(id);
        }
    }

}
