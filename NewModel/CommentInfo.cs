using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModel
{
   public class CommentInfo
    {
        //Title, Author, Msg, CreateDateTime, UserName, Id
        //评论
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Msg { get; set; }
        public DateTime CreateDateTime { get; set;}
        public string UserName { get; set; }
    }
}
