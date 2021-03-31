using FluentValidation;
using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.UpdateAsset
{
    public class UpdateAssetCommandValidator : AbstractValidator<UpdateAssetCommand>
    {
        public UpdateAssetCommandValidator(ICountryManager countryManager)
        {
            RuleFor(x => x.AssetName)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Department)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(x => Enum.IsDefined(typeof(Department), x))
                .WithMessage("Department is not valid");

            RuleFor(x => x.EMailAdressOfDepartment).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.CountryOfDepartment)
                .MustAsync((x, cancellation) => countryManager.CountryIsValid(x))
                .WithMessage("Country is not valid");

            RuleFor(x => x.PurchaseDate).GreaterThan(x => DateTime.UtcNow.AddYears(-1));
        }
    }
}
