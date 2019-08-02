using Microsoft.AspNetCore.Mvc;
using SME.SGP.Api.Filtros;
using SME.SGP.Dominio.Repositorios;
using SME.SGP.Dto;

namespace SME.SGP.Api.Controllers
{
    [ApiController]
    [Route("api/v1/alunos")]
    [ValidaDto]
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

        [HttpPost]
        public IActionResult Post(AlunoDto alunoDto)
        {
            repositorioAluno.Salvar(new Dominio.Aluno() { Nome = alunoDto.Nome });
            return Ok();
        }
    }
}