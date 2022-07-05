using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Application.DTO;
using FluentValidation;

namespace DatingApp.Application.Validation
{
    public class CommentDtoValidation : AbstractValidator<CommentDto>
    {
        public CommentDtoValidation()
        {
            // config level for validation
            // when a rule/validation is fails, the validation is stopped for the current rule/validation
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(comment => comment.Text)
                .NotEmpty().WithMessage("Please enter your comment")
                .NotNull().WithMessage("Please enter your comment");

            RuleFor(comment => comment.PostId)
                .NotEmpty().WithMessage("PostId is not empty")
                .NotNull().WithMessage("PostId is not empty");

            RuleFor(comment => comment.UserId)
                .NotEmpty().WithMessage("UserId is not empty")
                .NotNull().WithMessage("UserId is not empty");
        }
    }
}
