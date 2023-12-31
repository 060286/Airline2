using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IMessageProducer _messageProducer;

    // In-memory DB
    public static readonly List<Booking> _bookings = new();

    public BookingsController(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    [HttpPost]
    public IActionResult CreatingBooking(Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        _bookings.Add(booking);

        // Sending a message
        _messageProducer.SendingMessage<Booking>(booking);

        return Ok();
    }
}