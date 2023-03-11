using AutoMapper;
using ButcherShop.Models;
using ButcherShop.Models.DTO;
using ButcherShop.Repository;
using ButcherShop.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace ButcherShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected APIResponse _response;

        private readonly ICustomerRepository _repository;

        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _response = new APIResponse();
            _mapper = mapper;

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAll() 
        {
            try
            {
                var customersList = await _repository.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = customersList;
                return Ok(_response);
            }
            catch(Exception ex) 
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.IsSuccess = false;
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetCustomer")]
        public async Task<ActionResult<APIResponse>> GetCustomer(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Customer id can not be 0" };
                    return BadRequest(_response);
                }
                var customer = await _repository.GetAsync(c => c.Id == id);
                if (customer == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "There is no customer with that id" };
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = customer;
                return Ok(_response);
            }
            catch(Exception ex) 
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.IsSuccess = false;
            }
            return _response;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateCustomer([FromBody] CustomerCreateDTO customerCreate)
        {
            try
            {
                if (await _repository.GetAsync(c => c.PhoneNumber == customerCreate.PhoneNumber) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "There is already customer with that phone number" };
                    return BadRequest(_response);
                }
                var customer = _mapper.Map<Customer>(customerCreate);

                await _repository.CreateAsync(customer);
                await _repository.SaveAsync();
                
                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = customer;

                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.IsSuccess = false;
            }

            return _response;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:int}", Name = "DeleteCustomer")]
        public async Task<ActionResult<APIResponse>> DeleteCustomer(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Customer id can not be 0" };
                    return BadRequest(_response);
                }
                var customer = await _repository.GetAsync(prod => prod.Id == id);
                if (customer == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "There is no customer with that id" };
                    return NotFound(_response);
                }
                await _repository.RemoveAsync(customer);
                await _repository.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id:int}", Name = "UpdateCustomer")]
        public async Task<ActionResult<APIResponse>> UpdateCustomer(int id, Customer updatedCustomer)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Customer id can not be 0" };
                    return BadRequest(_response);
                }
                var customer = await _repository.GetAsync(c => c.Id == id);
                if (customer == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "There is no customer with that id" };
                    return NotFound(_response);
                }
                await _repository.UpdateAsync(updatedCustomer);
                await _repository.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = customer;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

    }
}
