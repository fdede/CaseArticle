using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Article
    {
        public int ID { get; set; }
        public string NameOrTitle { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
