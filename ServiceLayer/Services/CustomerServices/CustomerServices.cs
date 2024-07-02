using DomainLayer.Models.Customer;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CustomerServices
{
    public class CustomerServices: ICustomerServices, ICustomerRepository
    {
        private ICustomerRepository _customerRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CustomerServices(ICustomerRepository customerRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _customerRepository = customerRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(CustomerModel customerModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(customerModel);
            ValidateCustomerDateOfBirth(customerModel);
        }

        public void ValidateModelDataAnnotations(CustomerModel customerModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(customerModel);
        }

        public void ValidateCustomerDateOfBirth(ICustomerModel customerModel)
        {
            StringBuilder errorStringBuilder = new StringBuilder();

            if (customerModel.DateOfBirth.Year > DateTime.Now.Year)
            {
                errorStringBuilder.Append("The year of birth must be less than the current year!").AppendLine();
            }
            if (DateTime.Now.Year - customerModel.DateOfBirth.Year < 18)
            {
                errorStringBuilder.Append("Your age must be greater than 18!").AppendLine();
            }
            if (errorStringBuilder.Length > 0)
            {
                throw new ArgumentException($"{errorStringBuilder.ToString()}");
            }
        }
    }
}
