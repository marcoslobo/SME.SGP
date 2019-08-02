using Microsoft.AspNetCore.Mvc;
using SME.SGP.Dominio.Repositorios;

namespace SME.SGP.Api.Controllers
{
    [ApiController]
    [Route("api/v1/alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepositorioAluno repositorioAluno;

        public AlunoController(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repositorioAluno.Listar());
        }
    }
}