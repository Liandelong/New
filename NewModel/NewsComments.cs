using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModel
{
    public class NewsComments
    {
        //Id, NewId, UserId, Msg, CreateDateTime
        public int Id { get; set; }

        public int NewId { get; set; }

        public int UserId { get; set; }

        public string Msg { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
