using Cerberus.Domain.Entities;
using Cerberus.Domain.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Application.Common.Interfaces
{
    public interface IBookingsCalendar
    {
        Task<Booking> AddBookingAsync(Booking booking, CancellationToken cancellationToken = default);
        Task<IEnumerable<Booking>> GetBookingsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Booking>> GetBookingsAsync(BookingType bookingType, CancellationToken cancellationToken = default);
        Task<Customer> LoadCustomerAsync(int customerId, CancellationToken cancellationToken = default);
        Task<Booking> GetBookingAsync(int id, CancellationToken cancellationToken);
    }
}