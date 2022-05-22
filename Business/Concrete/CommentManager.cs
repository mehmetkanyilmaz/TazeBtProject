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
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [ValidationAspect(typeof(CommentValidator))]
        public IDataResult<Comment> Add(Comment comment)
        {
            var result = _commentDal.Add(comment);

            if (result == null)
                return new ErrorDataResult<Comment>(Messages.CommentAddError);

            return new SuccessDataResult<Comment>(result);
        }

        public IDataResult<List<Comment>> GetListByArticleId(int articleId)
        {
            var result = _commentDal.GetList(x => x.ArticleId == articleId);

            return new SuccessDataResult<List<Comment>>(result.ToList());
        }
    }
}
