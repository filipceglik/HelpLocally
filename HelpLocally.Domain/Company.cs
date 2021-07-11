using System;
using System.Collections.Generic;

namespace HelpLocally.Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Nip { get; set; }
        public string BankAccountNumber { get; set; }

        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
