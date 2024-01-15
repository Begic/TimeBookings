using System.ComponentModel.DataAnnotations;

namespace TimeBooking.Db.Entities;

public class TimeBookingDetail
{
    public int Id { get; set; }

    public TimeBookingDay TimeBookingDay { get; set; }
    public int TimeBookingDayId { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    [MaxLength(2000)] public string? Remark { get; set; }
}