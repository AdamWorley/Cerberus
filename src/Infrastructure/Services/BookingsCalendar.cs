using Cerberus.Application.Common.Interfaces;
using Cerberus.Domain.Entities;
using Cerberus.Domain.Enums;
using Cerberus.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingsCalendar : IBookingsCalendar
    {
        private readonly ILogger<BookingsCalendar> _logger;
        private readonly CerberusContext _cerberusContext;

        public BookingsCalendar(ILogger<BookingsCalendar> logger, CerberusContext cerberusContext)
        {
            _logger = logger;
            _cerberusContext = cerberusContext;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting bookings");

            return await _cerberusContext.Bookings.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Booking> GetBookingAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting booking Id {Id}", id);

            return await _cerberusContext.Bookings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync(BookingType bookingType, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting bookings");

            return await _cerberusContext.Bookings.AsNoTracking().Where(x => x.Type == bookingType).ToListAsync(cancellationToken);
        }

        public async Task<Booking> AddBookingAsync(Booking booking, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Adding booking");

            var addedBooking = await _cerberusContext.Bookings.AddAsync(booking);

            await _cerberusContext.SaveChangesAsync();

            return addedBooking.Entity;
        }

        public async Task<Customer> LoadCustomerAsync(int customerId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting customer with ID {Id}", customerId);

            return await _cerberusContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
        }


    }
}