using crudTest.ServiceContracts.DTO;


namespace ServiceContracts
{
    public interface ICountryServices
    {
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
    }
}
