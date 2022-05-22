using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            //ArticleId rules
            RuleFor(x => x.ArticleId).NotEmpty().WithMessage(Messages.CommentArticleIdNull);
            RuleFor(x => x.ArticleId).GreaterThan(0).WithMessage(Messages.CommentArticleIdNull);

            //Contents rules
            RuleFor(x => x.Contents).NotEmpty().WithMessage(Messages.CommentCommentsNull);

            //CUser rules
            RuleFor(x => x.CUser).NotEmpty().WithMessage(Messages.CommentCuserNull);
            RuleFor(x => x.CUser).GreaterThan(0).WithMessage(Messages.CommentCuserGreaterThanZero);

            //Date rules
            RuleFor(x => x.CDate).NotEmpty().WithMessage(Messages.CommentDateNull);
        }
    }
}
