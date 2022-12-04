using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEscuelaMVC.Validations
{
    public class CheckValidAula : ValidationAttribute
    {
        public CheckValidAula()
        {
            ErrorMessage = "El número debe ser mayor a 100";
        }

        public override bool IsValid(object value)
        {
            int numero = (int)value;
            if (numero < 100) { return false; }
            else { return true; }

        }
    }
}