using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skillbakery.Models
{
    public class FormattingService
    {
        public string toDate(DateTime date)
        {
            return date.ToString("d");
        }
    }
}
