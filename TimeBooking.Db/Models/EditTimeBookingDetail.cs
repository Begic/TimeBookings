namespace TimeBooking.Db.Models;

public class EditTimeBookingDetail
{
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Remark { get; set; }
}