using crudTest.Entities;
using crudTest.ServiceContracts;
using crudTest.ServiceContracts.DTO;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudTest.Services
{
    public class CountryService : ICountryServices
    {
        private readonly List<Country> _countries;

        public CountryService()
        {
            _countries = new List<Country>();
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            if(countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }
            Country country = countryAddRequest.ToCountry();

            // Generate Guid 
            country.CountryID = Guid.NewGuid();

            //Add Country Object into _countries//
            _countries.Add(country);
            return country.ToCountryResponse();
        }
    }
}
