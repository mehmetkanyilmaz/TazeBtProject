using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, TazeBtContext>, IArticleDal
    {
        public List<ArticleDetailDto> GetListArticle()
        {
            using (var context = new TazeBtContext())
            {
                var model = (from article in context.Articles
                             join user in context.Users on article.CUser equals user.Id
                             select new ArticleDetailDto()
                             {
                                 Article = article,
                                 UserName = user.Name,
                                 UserSurname = user.Surname,
                                 Categories = context.ArticleCategories.Where(x => x.ArticleId == article.Id).ToList(),
                                 Comments = context.Comments.Where(x => x.ArticleId == article.Id).ToList()
                             });
                return new List<ArticleDetailDto>(model);
            }
        }

        public ArticleDetailDto GetArticleById(int articleId)
        {
            using (var context = new TazeBtContext())
            {
                ArticleDetailDto model = (from article in context.Articles
                                          join user in context.Users on article.CUser equals user.Id
                                          where article.Id == articleId
                                          select new ArticleDetailDto()
                                          {
                                              Article = article,
                                              UserName = user.Name,
                                              UserSurname = user.Surname,
                                              Categories = context.ArticleCategories.Where(x => x.ArticleId == article.Id).ToList(),
                                              Comments = context.Comments.Where(x => x.ArticleId == article.Id).ToList()
                                          }).FirstOrDefault();
                return model;
            }
        }

        public List<ArticleDetailDto> GetListArticleByFilter(Expression<Func<ArticleDetailDto, bool>> filter)
        {
            using (var context = new TazeBtContext())
            {
                var model = (from article in context.Articles
                             join user in context.Users on article.CUser equals user.Id
                             select new ArticleDetailDto()
                             {
                                 Article = article,
                                 UserName = user.Name,
                                 UserSurname = user.Surname,
                                 Categories = context.ArticleCategories.Where(x => x.ArticleId == article.Id).ToList(),
                                 Comments = context.Comments.Where(x => x.ArticleId == article.Id).ToList()
                             }).Where(filter);
                return new List<ArticleDetailDto>(model);
            }
        }
    }
}
