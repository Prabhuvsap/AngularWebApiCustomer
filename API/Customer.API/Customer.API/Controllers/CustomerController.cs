﻿using Customer.API.Business;
using Customer.API.Business.Interfaces;
using Customer.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await _customerService.GetCustomers();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerModel customerRequest)
        {     
            await _customerService.AddCustomer(customerRequest);
            return Ok();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, CustomerModel customerRequest)
        {
            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            var cusResponse = await _customerService.UpdateCustomer(customerRequest);
            return Ok(cusResponse);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
