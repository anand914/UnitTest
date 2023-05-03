using crudTest.ServiceContracts.DTO;
using crudTest.Services;
using ServiceContracts;
using Xunit;

namespace crudTest
{
    public class CrudServicesTest
    {

        private readonly  ICountryServices _countryServices;

        public CrudServicesTest(ICountryServices countryServices)
        {
            _countryServices = new CountryService();
        }

        // Case :-1  //
        //When CountryAddRequest is null, it should throw ArgumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
             CountryAddRequest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countryServices.AddCountry(request);
            });
        }

        //Case 2 :-
        //When the CountryName is null, it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest request = new CountryAddRequest()
            {
                CountryName = null
             };
            //Assert

            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act 
                _countryServices.AddCountry(request);
            });
        }

        //Case 3:- 
        //When the CountryName is duplicate, it should throw ArgumentException
        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName = "USA" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "USA" };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countryServices.AddCountry(request1);
                _countryServices.AddCountry(request2);
            });
        }

        // Case 4:- 
        //When you supply proper country name, it should insert (add) the country to the existing list of countries
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "Japan" };

            //Act
            CountryResponse response = _countryServices.AddCountry(request);

            //Assert
            Assert.True(response.CountryID != Guid.Empty);
        }
    }
}