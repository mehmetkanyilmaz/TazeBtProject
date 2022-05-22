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
    public class ArticleCategoryValidator : AbstractValidator<ArticleCategory>
    {
        public ArticleCategoryValidator()
        {
            //ArticleId rules
            RuleFor(x => x.ArticleId).NotEmpty().WithMessage(Messages.ArticleCategoryArticleIdNull);
            RuleFor(x => x.ArticleId).GreaterThan(0).WithMessage(Messages.ArticleCategoryArticleIdNull);

            //Name rules
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.ArticleCategoryNameNull);
        }
    }
}
