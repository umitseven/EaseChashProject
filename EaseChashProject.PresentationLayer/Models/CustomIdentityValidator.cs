﻿using Microsoft.AspNetCore.Identity;

namespace EaseChashProject.PresentationLayer.Models
{
    public class CustomIdentityValidator: IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = $"Lütfen en az bir büyük karakter giriniz."
            };
        }
        public override IdentityError PasswordRequiresLower() {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = $"Lütfen en az bir küçük karakter giriniz."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = $"Lütfen en az 1 tane rakam giriniz."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = $"Lütfen en az 1 tane sembol giriniz."
            };
        }
    }
}
