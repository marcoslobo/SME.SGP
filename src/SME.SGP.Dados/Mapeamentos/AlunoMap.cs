using Dapper.FluentMap.Dommel.Mapping;
using SME.SGP.Dominio;

namespace SME.SGP.Dados.Mapeamentos
{
    internal class AlunoMap : DommelEntityMap<Aluno>
    {
        public AlunoMap()
        {
            ToTable("public.Alunos");
            Map(x => x.Nome).ToColumn("Nome");
        }
    }
}