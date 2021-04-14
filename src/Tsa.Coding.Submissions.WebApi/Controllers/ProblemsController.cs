using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tsa.Coding.Submissions.WebApi.Repositories;

namespace Tsa.Coding.Submissions.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemsController : ControllerBase
    {
        private readonly IProblemRepository _problemRepository;

        public ProblemsController(IProblemRepository problemRepository)
        {
            _problemRepository = problemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var problems = await _problemRepository.GetAsync();

            return Ok(problems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var problem = await _problemRepository.GetAsync(id);

            return problem != null
                ? Ok(problem)
                : NotFound();
        }
    }
}
