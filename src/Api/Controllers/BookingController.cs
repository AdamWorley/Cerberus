using Cerberus.Api.Controllers;
using Cerberus.Application.Bookings.Queries.GetBookings;
using Cerberus.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerberusApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetBookings()
        {
            return (await Mediator.Send(new GetBookingsQuery())).ToList();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            return await Mediator.Send(new GetBookingQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody]CreateBookingRequest booking)
        {
            return (await Mediator.Send(new CreateBookingCommand(booking)));
        }
    }
}
