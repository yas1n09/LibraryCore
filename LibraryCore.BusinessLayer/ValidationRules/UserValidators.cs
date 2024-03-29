﻿using FluentValidation;
using LibraryCore.BusinessLayer.Concrete;
using LibraryCore.DataAccessLayer.Concrete;
using LibraryCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.BusinessLayer.ValidationRules
{
    public class UserValidators : AbstractValidator<User>//Fluent validationda Abstract sınıfından miras alınıp parametredeki entitiyler için validasyon kuralları.
    {
        public UserValidators()
        {
            // User Name
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.");

            RuleFor(u => u.UserName).MinimumLength(4).WithMessage("Kullanıcı adı en az 4 karakter içermelidir.");

			RuleFor(u => u.UserName).Must(UniqueUsername).WithMessage("Kullanıcı adı zaten mevcut.");

            //First Name
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("İsim en az 2 karakter içermelidir.");

            // Last Name
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyisim en az 2 karakter içermelidir.");

            // Password
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(u => u.Password).GreaterThan("3").WithMessage("Şifre en az 4 haneli olmalıdır.");

            // Email
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email adresini düzgün giriniz.");
        }


        //private bool UniqueUsername(string arg)
        //{
        //    var userManager = new UserManager(new EfUserDal());
        //    return userManager.CheckUsername(arg).Success;
        //}

        private bool UniqueUsername(string arg)
        {
            var userManager = new UserManager(new EfUserDal());
            return !userManager.CheckUsername(arg).Success; // Değişiklik burada
        }


    }
}
