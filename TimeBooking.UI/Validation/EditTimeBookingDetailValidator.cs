using FluentValidation;
using TimeBooking.Db.Models;

namespace TimeBooking.UI.Validation;

public class EditTimeBookingDetailValidator : AbstractValidator<EditTimeBookingDetail>
{
    public EditTimeBookingDetailValidator()
    {
        RuleFor(x => x.StartTime).NotNull().NotEmpty();
        RuleFor(x => x.EndTime).GreaterThan(x=> x.StartTime).NotNull().NotEmpty();
    }
}