using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleCategoryManager : IArticleCategoryService
    {
        private IArticleCategoryDal _articleCategoryDal;

        public ArticleCategoryManager(IArticleCategoryDal articleCategoryDal)
        {
            _articleCategoryDal = articleCategoryDal;
        }

        [ValidationAspect(typeof(ArticleCategoryValidator))]
        public IDataResult<ArticleCategory> Add(ArticleCategory articleCategory)
        {
            var result = _articleCategoryDal.Add(articleCategory);

            if (result == null)
                return new ErrorDataResult<ArticleCategory>(Messages.ArticleCategoryAddError);

            return new SuccessDataResult<ArticleCategory>(result);
        }

        public IDataResult<List<ArticleCategory>> AddRange(List<ArticleCategory> articleCategory)
        {
            var result = _articleCategoryDal.AddRange(articleCategory);

            if (result == null)
                return new ErrorDataResult<List<ArticleCategory>>(Messages.ArticleCategoryAddError);

            return new SuccessDataResult<List<ArticleCategory>>(result.ToList());
        }

        public IResult DeleteById(int Id)
        {
            var result = _articleCategoryDal.Get(x => x.Id == Id);

            if (result == null)
                return new ErrorResult(Messages.ArticleCategoryDeleteError);

            _articleCategoryDal.Delete(result);
            return new SuccessResult(Messages.ArticleCategorySuccessfulDeleted);
        }

        public IDataResult<List<ArticleCategory>> GetlistByArticleId(int articleId)
        {
            var result = _articleCategoryDal.GetList(x => x.ArticleId == articleId);

            return new SuccessDataResult<List<ArticleCategory>>(result.ToList());
        }
    }
}
