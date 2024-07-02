using System;

namespace DomainLayer.Models.Customer
{
    public interface ICustomerModel
    {
        DateTime DateOfBirth { get; set; }
        string FirstName { get; set; }
        int Gender { get; set; }
        int ID { get; set; }
        string LastName { get; set; }
        int Occupation { get; set; }
    }
}