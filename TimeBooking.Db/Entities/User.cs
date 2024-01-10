using System.ComponentModel.DataAnnotations;

namespace TimeBooking.Db.Entities;

public class User
{
    public int Id { get; set; }
    [MaxLength(200)] public string FirstName { get; set; }
    [MaxLength(200)] public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    [MaxLength(200)] public string Email { get; set; }

    public List<TimeBookingDay> TimeBookingDays { get; set; } = new();
}