using FluentValidation;
using Replyment.Application.DTOs.Slider;

namespace Replyment.Application.Validators.SliderValidators;

public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDTO>
{
    public SliderCreateDtoValidator()
    {
        RuleFor(x => x.Image).NotEmpty().NotNull();
        RuleFor(x => x.Name).MaximumLength(40).NotEmpty().NotNull();
    }
}
