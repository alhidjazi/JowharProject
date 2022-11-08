using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ktegori Adını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriş yapın");
            RuleFor(x => x.UserName).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer giriş yapmayın");
            
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.UserMail).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer giriş yapmayın");
            
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriş yapın");
            RuleFor(x => x.Subject).MaximumLength(15).WithMessage("Lütfen 15 karakterden fazla değer giriş yapmayın");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.Message).MinimumLength(20).WithMessage("Lütfen en az 20 karakter giriş yapın");
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage("Lütfen 1000 karakterden fazla değer giriş yapmayın");

        }
    }
}
