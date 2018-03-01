using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Filme.Core;
using Filme.Core.Dtos;
using Filme.Core.Models;

namespace Filme.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //get api/customers
        public async Task<IEnumerable<CustomerDto>> GetCustomers(string query = null)
        {
            var customersQuery = await _unitOfWork.Customers.CustomersMemberships();
            
            if(!string.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customers = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return customers;
        }

        //get api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(customerDto);
        }

        //post api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        //put api/customers/1
        [HttpPut]
        public void UpdateCustomer(CustomerDto customerDto, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cust = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, cust);
            _unitOfWork.Complete();
        }

        //delete api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cust = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _unitOfWork.Customers.Remove(cust);
            _unitOfWork.Complete();
        }
    }
}
