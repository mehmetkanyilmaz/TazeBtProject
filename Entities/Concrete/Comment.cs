using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Contents { get; set; }
        public int CUser { get; set; }
        public DateTime CDate { get; set; }
    }
}
