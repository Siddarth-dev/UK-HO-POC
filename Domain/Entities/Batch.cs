using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Batch : AuditableEntity
    {
        public Guid Id { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual BatchStatus BatchStatus { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime BatchPublishedDate { get; set; }
        public virtual ICollection<BatchAttribute> BatchAttributes { get; set; }
        public virtual ICollection<Acl> Acls { get; set; }
        public bool IsActive { get; set; }
    }
}