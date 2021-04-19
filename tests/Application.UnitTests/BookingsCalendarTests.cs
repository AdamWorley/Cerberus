using Cerberus.Application.Common.Interfaces;
using Cerberus.Domain.Entities;
using Cerberus.Domain.Enums;
using Cerberus.Infrastructure.Persistence;
using FluentAssertions;
using Infrastructure.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests
{
    public class BookingsCalendarTests
    {
        private readonly IBookingsCalendar _sut;

        public BookingsCalendarTests()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<CerberusContext>().UseSqlite(connection).Options;

            var context = new CerberusContext(options);
            context.Database.EnsureCreated();

            context.Customers.Add(new Customer { FirstName = "Adam", LastName = "Worley"  });

            context.SaveChanges();

            _sut = new BookingsCalendar(new NullLogger<BookingsCalendar>(), context);
        }

        [Fact]
        public async Task GetBookinsAsync_ReturnsAllBookigs()
        {
            var bookings = await _sut.GetBookingsAsync();

            bookings.Should().BeEmpty();
        }

        [Fact]
        public async Task GetBookings_ReturnsAllWalks()
        {
            BookingType bookingType = BookingType.Walk;
            var walks = await _sut.GetBookingsAsync(bookingType);

            walks.Should().BeEmpty();
        }

        [Fact]
        public async Task LoadCustomerAsync()
        {
            var customerId = 1;
            var customer = await _sut.LoadCustomerAsync(customerId);

            customer.Id.Should().Be(customerId);
        }

        [Fact]
        public async Task AddBooking()
        {
            var customer = await _sut.LoadCustomerAsync(1);
            var booking = new Booking { Type = BookingType.Walk, Pets = customer.Pets, Customer = customer };

            var addedBooking = await _sut.AddBookingAsync(booking);

            var expected = BookingType.Walk;

            addedBooking.Type.Should().Be(expected);
        }
    }
}
