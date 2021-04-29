using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TriviaProject
{
    public class CustomValidators
    {
        // public class FutureDate : ValidationAttribute
        // {
        //     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //     {
        //         DateTime date = (DateTime)value;
        //         return date < DateTime.Now ? new ValidationResult("must be in the future.") : ValidationResult.Success;
        //     }
        // }
        public class IsAnswer : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {

                return (bool)value == false ? new ValidationResult("You got the answer wrong. :'(") : ValidationResult.Success;

            }

        }
        public class SuperPassword : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string password = (string)value;
                List<char> chars = new List<char>() { };
                bool containsNum = false;
                bool containsSpecial = false;
                bool containsLetter = false;
                foreach (char c in password)
                {
                    chars.Add(c);
                    if (c < '9' && c >= '0')
                    {
                        containsNum = true;
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("contains num");
                    }
                    else if (c <= 'z' && c >= 'a')
                    {
                        containsLetter = true;
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("contains char");
                    }
                    else if (c == '!' || c == '@' || c == '#' || c == '$' || c == '%' || c == '^' || c == '&' || c == '*' || c == '*')
                    {
                        containsSpecial = true;
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("contains special");
                    }
                }
                bool validPass = false;

                if (containsLetter && containsNum && containsSpecial)
                {
                    validPass = true;
                }

                return validPass == false ? new ValidationResult("must contain at least 1 number, 1 letter and a special character.") : ValidationResult.Success;

            }
        }

    }
}