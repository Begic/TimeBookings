namespace TimeBooking.Db.Models;

public class EditTimeBookingDay
{
    public DateTime? BookingDay { get; set; }
    public string Remark { get; set; }
    public List<EditTimeBookingDetail> TimeBookingDetails { get; set; } = new();
}