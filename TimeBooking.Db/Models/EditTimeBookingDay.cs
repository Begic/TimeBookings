namespace TimeBooking.Db.Models;

public class EditTimeBookingDay
{
    public int Id { get; set; }
    public DateTime? BookingDay { get; set; }
    public string Remark { get; set; }
    public List<EditTimeBookingDetail> TimeBookingDetails { get; set; } = new();
}