using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ServiceLayer.Tests
{
    [Trait("Category", "Model Validations")]
    public class CustomerServicesValidationTests : IClassFixture<CustomerServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private CustomerServicesFixture _customerServicesFixture;

        public CustomerServicesValidationTests(CustomerServicesFixture customerServicesFixture ,ITestOutputHelper testOutputHelper)
        {
            this._customerServicesFixture = customerServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        private void SetValidSampleValues()
        {
            _customerServicesFixture.CustomerModel.ID = 1;
            _customerServicesFixture.CustomerModel.FirstName = "Test";
            _customerServicesFixture.CustomerModel.LastName = "User";
            _customerServicesFixture.CustomerModel.DateOfBirth = new DateTime(2009, 12, 25);
            _customerServicesFixture.CustomerModel.Gender = 1;
            _customerServicesFixture.CustomerModel.Occupation = 1;
        }

        private void WriteExceptionTestResult(Exception exception)
        {
            if (exception != null)
            {
                _testOutputHelper.WriteLine(exception.Message);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                JObject json = JObject.FromObject(_customerServicesFixture.CustomerModel);
                stringBuilder.Append("***** No Exception Was Thrown *****").AppendLine();
                foreach(JProperty jProperty in json.Properties())
                {
                    stringBuilder.Append(jProperty.Name).Append(" --> ").Append(jProperty.Value).AppendLine();
                }

                _testOutputHelper.WriteLine(stringBuilder.ToString());
            }
        }

        [Fact]
        public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
        {
            var exception = Record.Exception(() => _customerServicesFixture.CustomerServices.ValidateModelDataAnnotations
                            (_customerServicesFixture.CustomerModel));
            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyDataAnnotationCheckFails()
        {
            _customerServicesFixture.CustomerModel.FirstName = "";

            Exception exception = Assert.Throws<ArgumentException>(testCode: () => _customerServicesFixture.CustomerServices.ValidateModelDataAnnotations
                                    (_customerServicesFixture.CustomerModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForFirstNameEmpty()
        {
            _customerServicesFixture.CustomerModel.FirstName = "";

            Exception exception = Assert.Throws<ArgumentException>(testCode: () => _customerServicesFixture.CustomerServices.ValidateModelDataAnnotations
                        (_customerServicesFixture.CustomerModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForFirstNameExceedMaxLength()
        {
            _customerServicesFixture.CustomerModel.FirstName = "1222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222" +
                "211111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

            Exception exception = Assert.Throws<ArgumentException>(testCode: () => _customerServicesFixture.CustomerServices.ValidateModelDataAnnotations
                        (_customerServicesFixture.CustomerModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForDateOfBirthCheckFails()
        {
            _customerServicesFixture.CustomerModel.DateOfBirth = DateTime.Today;

            Exception exception = Assert.Throws<ArgumentException>(testCode: () => _customerServicesFixture.CustomerServices.ValidateModel
                        (_customerServicesFixture.CustomerModel));

            WriteExceptionTestResult(exception);
        }
    }
}
