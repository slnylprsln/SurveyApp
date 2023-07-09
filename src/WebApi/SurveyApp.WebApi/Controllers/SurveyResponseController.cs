using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Services.Interfaces;

namespace SurveyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyResponseController : ControllerBase
    {
        private readonly ISurveyResponseService _service;

        public SurveyResponseController(ISurveyResponseService service)
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

        [HttpGet("[action]")]
        public IActionResult GetSurveyResponsesByQuestion(int id)
        {
            var list = _service.GetSurveyResponsesByQuestion(id);
            if (list == null)
            {
                return NotFound();
            }
            else return Ok(list);
        }

        [HttpGet("[action]")]
        public IActionResult GetSurveyResponsesBySurvey(int id)
        {
            var list = _service.GetSurveyResponsesBySurvey(id);
            if (list == null)
            {
                return NotFound();
            }
            else return Ok(list);
        }

        [HttpGet("[action]")]
        public IActionResult GetSurveyResponsesForAQuestionOfSurvey(int surveyId, int questionId)
        {
            var list = _service.GetSurveyResponsesForAQuestionOfSurvey(surveyId, questionId);
            if (list == null)
            {
                return NotFound();
            }
            else return Ok(list);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateNewSurveyResponseRequest request)
        {
            if (ModelState.IsValid)
            {
                var lastId = await _service.CreateAndReturnIdAsync(request);
                return CreatedAtAction(nameof(Get), routeValues: new { id = lastId }, null);

            }
            return BadRequest(ModelState);
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
