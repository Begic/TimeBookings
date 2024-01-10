using FluentValidation;
using TimeBooking.Db.Models;

namespace TimeBooking.UI.Validation;

public class EditTimeBookingDayValidator : AbstractValidator<EditTimeBookingDay>
{
    public EditTimeBookingDayValidator()
    {
        RuleFor(x => x.Remark).NotNull().NotEmpty();
    }
}