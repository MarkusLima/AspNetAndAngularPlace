using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAndAngularPlace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly PointService _pointService;

        public PointsController(PointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadPointsDTO>>> GetPoints([FromQuery] int skip = 0, [FromQuery] int take = 10, [FromQuery] string keyword = "")
        {
            try
            {
                var result = await _pointService.GetBooksAsync(skip, take, keyword);
                return Ok(result);
            }
            catch (ExceptionsCode ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
        }
    }
}
