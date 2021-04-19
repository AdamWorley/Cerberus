using Cerberus.Application.Common.Interfaces;
using Cerberus.Domain.Entities;
using Cerberus.Domain.Enums;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<int>
    {
        public BookingType Type { get; private set; }
        public int CustomerId { get; private set; }

        public CreateBookingCommand(BookingType bookingType, int customerId)
        {

        }

        internal class CreateTodoItemCommandHandler : IRequestHandler<CreateBookingCommand, int>
        {
            private readonly IBookingsCalendar _context;

            public CreateTodoItemCommandHandler(IBookingsCalendar context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                var entity = new Booking
                {
                    Type = request.Type,
                    Customer = request.CustomerId,
                    Pets = new List<Pet>()
                };

                entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

                _context.TodoItems.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
