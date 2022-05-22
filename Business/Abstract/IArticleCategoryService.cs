using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleCategoryService
    {
        IDataResult<ArticleCategory> Add(ArticleCategory articleCategory);
        IDataResult<List<ArticleCategory>> AddRange(List<ArticleCategory> articleCategory);
        IResult DeleteById(int Id);
        IDataResult<List<ArticleCategory>> GetlistByArticleId(int articleId);
    }
}
