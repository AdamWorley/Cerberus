using Cerberus.Application.Common.Interfaces;
using Cerberus.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Application.Bookings.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<IEnumerable<Booking>>
    {
        internal class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, IEnumerable<Booking>>
        {
            private readonly IBookingsCalendar _context;

            public GetBookingsQueryHandler(IBookingsCalendar context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Booking>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
            {
                return await _context.GetBookingsAsync(cancellationToken);
            }
        }
    }
}
