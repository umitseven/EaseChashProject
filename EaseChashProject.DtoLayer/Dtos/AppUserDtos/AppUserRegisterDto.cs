﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaseChashProject.DtoLayer.Dtos.AppUserDtos
{
    public class AppUserRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Usurname { get; set; }
        public string Password { get;  set; }
        public string ConfirmPassword { get; set; }
    }
}
