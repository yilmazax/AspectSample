using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{

    public class Bank
    {
        public virtual short BankId { get; set; }
        public virtual string BankName { get; set; }
        public virtual string BankCode { get; set; }
        public virtual Boolean Status { get; set; }
        public virtual string ContactPerson { get; set; }
        public virtual string ContactEmail { get; set; }
        public virtual string ContactGSM { get; set; }
     
        public virtual DateTime DateCreated { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual int UpdatedBy { get; set; }

    }
}
