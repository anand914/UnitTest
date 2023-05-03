using Entities;
using ServiceContract;
using ServiceContract.DTO;

namespace Services
{
    public class CountrySrvc : ICountryService
    {
        private readonly List<Country> _countries;

        public CountrySrvc()
        {
            _countries = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest countryAddRequest)
        {
            //Validation: countryAddRequest parameter can't be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: CountryName can't be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: CountryName can't be duplicate
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }

            //Convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();

            //generate CountryID
            country.CountryId = Guid.NewGuid();

            //Add country object into _countries
            _countries.Add(country);

            return country.ToCounrtyResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
           return _countries.Select(country => country.ToCounrtyResponse()).ToList();
        }
    }
}
    
