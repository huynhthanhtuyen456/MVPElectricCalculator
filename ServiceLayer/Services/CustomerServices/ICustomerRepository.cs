using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Customer;

namespace ServiceLayer.Services.CustomerServices
{
    public interface ICustomerRepository
    {
        void Add(CustomerModel customerModel);
        void Update(CustomerModel customerModel);
        void Delete(CustomerModel customerModel);
        IEnumerable<CustomerModel> GetAll();
        CustomerModel GetByID(int id);
    }
}
