using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.ValidationRules
{
    public class GalleryValidator : AbstractValidator<Gallery>
    {
        public GalleryValidator()
        {
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("You cannot leave the image name blank.");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Add photo");
            RuleFor(x => x.ImageName).MinimumLength(3).WithMessage("Please enter at least 3 characters");
            RuleFor(x => x.ImageName).MaximumLength(20).WithMessage("Please do not enter more than 20 characters.");

        }
    }
}
