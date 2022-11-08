using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PartnerValidator : AbstractValidator<Partner>
    {
        public PartnerValidator()
        {
            RuleFor(x => x.PartnerName).NotEmpty().WithMessage("Ktegori Adını Boş Geçemezsiniz");
            RuleFor(x => x.PartnerDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.PartnerCountry).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.PartnerStatus).NotEmpty().WithMessage(" Status Seçmelisiniz");
            RuleFor(x => x.PartnerName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriş yapın");
            RuleFor(x => x.PartnerName).MaximumLength(100).WithMessage("Lütfen 20 karakterden fazla değer giriş yapmayın");
            RuleFor(x => x.PartnerDescription).MinimumLength(10).WithMessage("Lütfen 20 karakterden fazla değer giriş yapmayın");
            RuleFor(x => x.PartnerDescription).MaximumLength(1000).WithMessage("Lütfen 20 karakterden fazla değer giriş yapmayın");

        }
    }
}
