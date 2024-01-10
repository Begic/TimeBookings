namespace TimeBooking.Db.Models;

public class TimeBookingDayInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime BookingDay { get; set; }
    public string Remark { get; set; }
    public List<TimeBookingDetailInfo> TimeBookingDetails { get; set; } = new();
}