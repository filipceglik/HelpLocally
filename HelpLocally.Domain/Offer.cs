using System;

namespace HelpLocally.Domain
{
    public class Offer : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid OfferTypeId { get; set; }
        public virtual OfferType OfferType { get; set; }
        public Guid CompanyId { get; set; }
    }
}
