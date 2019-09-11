using System;

namespace MyMap.DataModel.Domain
{
    public class DomainBase
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public bool Disabled { get; set; }
    }
}
