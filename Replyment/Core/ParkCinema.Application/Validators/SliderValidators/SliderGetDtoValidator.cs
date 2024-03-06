using FluentValidation;
using Replyment.Application.DTOs.Slider;

namespace Replyment.Application.Validators.SliderValidators;

public class SliderGetDtoValidator : AbstractValidator<SliderGetDTO>
{
    public SliderGetDtoValidator()
    {
        RuleFor(x => x.imagePath).NotNull().NotEmpty().MaximumLength(12000);
    }
}
