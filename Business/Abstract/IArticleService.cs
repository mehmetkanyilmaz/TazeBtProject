using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        IDataResult<Article> Add(Article article);
        IDataResult<Article> Update(Article article);
        IResult DeleteById(int Id);
        IDataResult<Article> Get(int Id);
        IDataResult<List<Article>> GetList();
        IDataResult<List<ArticleDetailDto>> GetListArticle();
        IDataResult<List<ArticleDetailDto>> GetListArticleByFilter(Expression<Func<ArticleDetailDto, bool>> filter);
        IDataResult<ArticleDetailDto> GetArticleById(int articleId);
        IDataResult<List<Article>> GetListByCuser(int CUser);
    }
}
