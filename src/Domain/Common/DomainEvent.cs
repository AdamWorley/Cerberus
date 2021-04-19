using System;
using System.Collections.Generic;

namespace Cerberus.Domain.Common
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
    public abstract class DomainEvent
    {
        public bool IsPublished { get; set; }
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;


        protected DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }
    }
}
