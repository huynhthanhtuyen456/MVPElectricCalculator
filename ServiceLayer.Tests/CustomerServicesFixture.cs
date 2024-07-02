using DomainLayer.Models.Customer;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Tests
{
    public class CustomerServicesFixture
    {
        private ICustomerServices _customerServices;
        private ICustomerModel _customerModel;

        public CustomerServicesFixture() 
        {
            _customerModel = new CustomerModel();
            _customerServices = new CustomerServices(null, new ModelDataAnnotationCheck());
        }

        public CustomerModel CustomerModel
        {
            get { return (CustomerModel)_customerModel; }
            set { _customerModel = value; }
        }

        public CustomerServices CustomerServices
        {
            get { return (CustomerServices)_customerServices; }
            set { _customerServices = value; }
        }
    }
}
