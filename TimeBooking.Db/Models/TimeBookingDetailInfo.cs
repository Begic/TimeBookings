namespace TimeBooking.Db.Models;

public class TimeBookingDetailInfo
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Remark { get; set; }
}