using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ArticleAddDto : IDto
    {
        public Article Article { get; set; }
        public List<ArticleCategory> Categories { get; set; }
    }
}
