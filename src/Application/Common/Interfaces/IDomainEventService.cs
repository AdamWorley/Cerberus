using Cerberus.Domain.Common;
using System.Threading.Tasks;

namespace Cerberus.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}