using System.ComponentModel.DataAnnotations;

namespace SME.SGP.Dto
{
    public class AlunoDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
    }
}