using System.Collections.Generic;

namespace SME.SGP.Dominio.Repositorios
{
    public interface IRepositorioAluno
    {
        IEnumerable<Aluno> Listar();

        void Salvar(Aluno aluno);
    }
}