using System;

namespace Domain.Entities
{
    public class Acl
    {
        public int Id { get; set; }
        // public Guid BatchId { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public virtual Batch Batch { get; set; }
        public bool IsActive { get; set; }
    }
}