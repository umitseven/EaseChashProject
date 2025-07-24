using EaseChashProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaseChashProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("ad alanı boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("soy ad boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
            RuleFor(X => X.Name).MaximumLength(30).WithMessage("lütfen en fazla 30 karakter giriniz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");

        }
    }
}
