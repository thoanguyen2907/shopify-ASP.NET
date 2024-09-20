using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.Common
{
    public class StartDateValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            var startDate = (DateTime)value;
            return startDate.Year == DateTime.Now.Year;
        }
    }
}