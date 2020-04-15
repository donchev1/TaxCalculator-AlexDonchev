using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator
{
    public class NetSalaryCalculator
    {
        ICountry _country;
        decimal _incomeTaxAmount { get { return IncomeTaxAmount(); } }
        decimal _socialTaxAmount { get { return SocialTaxAmmount(); } }

        //The tax calculator accepts an abstraction because of the 2nd SOLID principle.
        //Open for extension and closed for modification.
        //If you decide to calculate the tax of another country 
        //you don't have to change the TaxCalculator class, just feed it different country class.
        public NetSalaryCalculator(ICountry country)
        {
            _country = country;
        }

        public decimal NetSalary
        {
            get
            {
                return _country.GrossSalaryAmount - (_incomeTaxAmount + _socialTaxAmount);
            }
        }

        private decimal IncomeTaxAmount()
        {
            decimal excess = 0;

            if (_country.GrossSalaryAmount > _country.IncomeTaxLowerThreshold)
            {
                excess = _country.GrossSalaryAmount - _country.IncomeTaxLowerThreshold;

                //we accept that if the incomeTaxUpperThreshold is 0 there is no upper threshold
                if (_country.IncomeTaxUpperThreshold > 0 && _country.GrossSalaryAmount > _country.IncomeTaxUpperThreshold)
                {
                    excess -= _country.GrossSalaryAmount - _country.IncomeTaxUpperThreshold;
                }
            }

            return (_country.IncomeTaxAmountInPercentage / 100) * excess;
        }

        private decimal SocialTaxAmmount()
        {
            decimal excess = 0;

            if (_country.GrossSalaryAmount > _country.SocialTaxLowerThreshold)
            {
                excess = _country.GrossSalaryAmount - _country.SocialTaxLowerThreshold;

                //we accept that if the incomeTaxUpperThreshold is 0 there is no upper threshold
                if (_country.SocialTaxUpperThreshold > 0 && _country.GrossSalaryAmount > _country.SocialTaxUpperThreshold)
                {
                    excess -= _country.GrossSalaryAmount - _country.SocialTaxUpperThreshold;
                }
            }

            return (_country.SocialTaxAmountInPercentage / 100) * excess;
        }

    }
}
