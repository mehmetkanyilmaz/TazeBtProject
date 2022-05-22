using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        [ValidationAspect(typeof(ArticleValidator))]
        public IDataResult<Article> Add(Article article)
        {
            var result = _articleDal.Add(article);

            if (result == null)
                return new ErrorDataResult<Article>(Messages.ArticleAddError);

            return new SuccessDataResult<Article>(result);
        }

        public IResult DeleteById(int Id)
        {
            //Önce article category sil, sonra article sil
            var article = _articleDal.Get(x => x.Id == Id);
            if (article == null)
                return new ErrorResult(Messages.ArticleDeleteError);

            _articleDal.Delete(article);
            return new SuccessResult(Messages.ArticleSuccessfulDeleted);
        }

        public IDataResult<Article> Get(int Id)
        {
            var result = _articleDal.Get(x => x.Id == Id);

            if (result == null)
                return new ErrorDataResult<Article>(Messages.ArticleNotFound);

            return new SuccessDataResult<Article>(result);
        }

        public IDataResult<List<ArticleDetailDto>> GetListArticle()
        {
            var result = _articleDal.GetListArticle();

            if (result == null)
                return new ErrorDataResult<List<ArticleDetailDto>>(Messages.ArticleGetListError);

            return new SuccessDataResult<List<ArticleDetailDto>>(result);
        }

        public IDataResult<ArticleDetailDto> GetArticleById(int articleId)
        {
            var result = _articleDal.GetArticleById(articleId);

            if (result == null)
                return new ErrorDataResult<ArticleDetailDto>(Messages.ArticleGetError);

            return new SuccessDataResult<ArticleDetailDto>(result);
        }

        public IDataResult<List<ArticleDetailDto>> GetListArticleByFilter(Expression<Func<ArticleDetailDto, bool>> filter)
        {
            var result = _articleDal.GetListArticleByFilter(filter);

            if (result == null)
                return new ErrorDataResult<List<ArticleDetailDto>>(Messages.ArticleGetListError);

            return new SuccessDataResult<List<ArticleDetailDto>>(result);
        }

        public IDataResult<List<Article>> GetList()
        {
            var result = _articleDal.GetList();

            if (result == null)
                return new ErrorDataResult<List<Article>>(Messages.ArticleGetListError);

            return new SuccessDataResult<List<Article>>(result.ToList());
        }

        public IDataResult<List<Article>> GetListByCuser(int CUser)
        {
            var result = _articleDal.GetList(x => x.CUser == CUser);

            if (result == null)
                return new ErrorDataResult<List<Article>>(Messages.ArticleGetListError);

            return new SuccessDataResult<List<Article>>(result.ToList());
        }

        [ValidationAspect(typeof(ArticleValidator))]
        public IDataResult<Article> Update(Article article)
        {
            var result = _articleDal.Update(article);

            if (result == null)
                return new ErrorDataResult<Article>(Messages.ArticleUpdateError);

            return new SuccessDataResult<Article>(result);
        }
    }
}
