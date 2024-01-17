using System.ComponentModel.DataAnnotations;

namespace TimeBooking.Db.Entities;

public class TimeBookingDay
{
    public int Id { get; set; }
    public DateTime BookingDay { get; set; }
    [MaxLength(2000)] public string? Remark { get; set; }
    public List<TimeBookingDetail>? TimeBookingDetails { get; set; } = new();
    
    public User User { get; set; }
    public int UserId { get; set; }
}