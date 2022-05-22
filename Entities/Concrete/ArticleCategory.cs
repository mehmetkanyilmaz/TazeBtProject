using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ArticleCategory : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
    }
}
