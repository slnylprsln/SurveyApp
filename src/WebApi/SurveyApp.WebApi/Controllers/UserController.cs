using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Services.Interfaces;

namespace SurveyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var list = _service.GetDisplayResponses();
            if (list == null)
            {
                return NotFound();
            }
            else return Ok(list);
        }

        [HttpGet("[action]")]
        public IActionResult Get(int id)
        {
            var found = _service.Get(id);
            if (found == null)
            {
                return NotFound();
            }
            else return Ok(found);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateNewUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var lastId = await _service.CreateAndReturnIdAsync(request);
                return CreatedAtAction(nameof(Get), routeValues: new { id = lastId }, null);

            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateUserRequest updateRequest)
        {
            var isExists = await _service.IsExists(id);
            if (isExists)
            {
                if (ModelState.IsValid)
                {
                    await _service.Update(updateRequest);
                    return Ok();
                }

                return BadRequest(ModelState);
            }
            return NotFound();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.IsExists(id))
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
