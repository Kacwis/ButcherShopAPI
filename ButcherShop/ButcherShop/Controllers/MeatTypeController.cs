using ButcherShop.Models;
using ButcherShop.Repository;
using ButcherShop.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ButcherShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeatTypeController : ControllerBase
    {
        private readonly APIResponse _response;

        private readonly IMeatTypeRepository _repository;

        public MeatTypeController(IMeatTypeRepository repository) 
        {
            _repository = repository;
            _response = new();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task <ActionResult<APIResponse>> GetAll()
        {
            var meatTypesList = await _repository.GetAllAsync();
            _response.Result = meatTypesList;
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}", Name = "GetMeatType")]
        public async Task<ActionResult<APIResponse>> GetMeatType(int id)
        {
            if(id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Meat type id can not be 0"};
                return BadRequest(_response);
            }
            var meatType = await _repository.GetAsync(mt => mt.Id == id);
            if(meatType == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "There is no meat type with that id" };
                return NotFound(_response);
            }
            _response.IsSuccess = true;
            _response.Result = meatType;
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }


    }
}
