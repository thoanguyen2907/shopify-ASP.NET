using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Common;

namespace Shopify.src.Entity
{
    public class TimeStamp
    {
        [StartDateValidation(ErrorMessage = "StartDate has to be in the same year")]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}