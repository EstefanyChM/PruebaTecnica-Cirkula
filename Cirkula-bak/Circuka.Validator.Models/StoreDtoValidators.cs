using Cirkula.DTO.Models;
using FluentValidation;

namespace Circuka.Validator.Models
{
	public class StoreDtoValidators: AbstractValidator<CreateStoreDto>
	{
		public StoreDtoValidators()
		{
			 RuleFor(x => x)
                .Must(store => store.OpenTime < store.CloseTime)
                .WithMessage("La hora de apertura debe ser anterior a la hora de cierre.");

		}
	}
}
