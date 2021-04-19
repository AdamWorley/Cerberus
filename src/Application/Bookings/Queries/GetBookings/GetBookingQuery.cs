using Cerberus.Application.Common.Interfaces;
using Cerberus.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Application.Bookings.Queries.GetBookings
{
    public class GetBookingQuery : IRequest<Booking>
    {
        public int Id { get; set; }

        public GetBookingQuery(int id)
        {
            Id = id;
        }

        internal class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, Booking>
        {
            private readonly IBookingsCalendar _context;

            public GetBookingQueryHandler(IBookingsCalendar context)
            {
                _context = context;
            }

            public async Task<Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
            {
                return await _context.GetBookingAsync(request.Id, cancellationToken);
            }
        }
    }
}
