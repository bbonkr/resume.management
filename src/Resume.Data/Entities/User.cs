using kr.bbon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Entities
{
    public class User : Entity<long>
    {
        //public long Id { get; set; }

        public string UserName { get; set; }        

        public virtual ICollection<UserAttachment> UserAttachments { get; set; }

        public virtual Home Home { get; set; }

        public virtual ICollection<Content> Contents { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection< Attachment> Attachments { get; set;  }
    }

    public class UserAttachment : Entity
    {
        public long UserId { get; set; }

        public long AttachmentId { get; set; }

        public virtual User User { get; set; }

        public virtual Attachment Attachment { get; set; }
    }
}
