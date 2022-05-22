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
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            //Title rules
            RuleFor(x => x.Title).NotEmpty().WithMessage(Messages.ArticleTitleNull);

            //Date rules
            RuleFor(x => x.Date).NotEmpty().WithMessage(Messages.ArticleDateNull);

            //Contents rules
            RuleFor(x => x.Contents).NotEmpty().WithMessage(Messages.ArticleContentsNull);

            //CUser rules
            RuleFor(x => x.CUser).NotEmpty().WithMessage(Messages.ArticleCuserNull);
            RuleFor(x => x.CUser).GreaterThan(0).WithMessage(Messages.ArticleCuserGreaterThanZero);
        }
    }
}
