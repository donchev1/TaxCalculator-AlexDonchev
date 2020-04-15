using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator
{
    public class Imaginaria : ICountry
    {
        public decimal GrossSalaryAmount { get; set; }
        public decimal IncomeTaxLowerThreshold { get => 1000; }
        //we accept that if the UpperThreshold is 0 there is no upper threshold
        public decimal IncomeTaxUpperThreshold { get => 0; }
        public decimal SocialTaxLowerThreshold { get => 1000; }
        public decimal SocialTaxUpperThreshold { get => 3000; }
        public decimal IncomeTaxAmountInPercentage { get => 10; }
        public decimal SocialTaxAmountInPercentage { get => 15; }
    }
}
