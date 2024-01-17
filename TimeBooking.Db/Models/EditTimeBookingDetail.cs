namespace TimeBooking.Db.Models;

public class EditTimeBookingDetail
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string Remark { get; set; }
}