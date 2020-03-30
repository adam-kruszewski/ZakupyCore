﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ZakupyWebApp.Models
{
    public class UzytkownikEditModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required]
        public string Nazwa { get; set; }

        [Required]
        public string Email { get; set; }

        [UIHint("Haslo")]
        [DisplayName("Hasło")]
        public string Haslo { get; set; }

        [UIHint("Haslo")]
        [DisplayName("Powtórzenie hasła")]
        public string PowtorzenieHasla { get; set; }
    }
}