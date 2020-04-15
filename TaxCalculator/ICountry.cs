using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator
{
    public interface ICountry
    {
        decimal GrossSalaryAmount { get; set; }
        decimal IncomeTaxLowerThreshold { get; }
        decimal IncomeTaxUpperThreshold { get; }
        decimal SocialTaxLowerThreshold { get; }
        decimal SocialTaxUpperThreshold { get; }
        decimal IncomeTaxAmountInPercentage { get; }
        decimal SocialTaxAmountInPercentage { get; }
    }
}
