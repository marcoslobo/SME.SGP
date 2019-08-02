using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Repositorios;
using System.Collections.Generic;

namespace SME.SGP.Dados.Repositorios
{
    public class RepositorioAluno : IRepositorioAluno
    {
        private NpgsqlConnection connection;

        public RepositorioAluno(IConfiguration configuration)
        {
            connection = new NpgsqlConnection(configuration.GetConnectionString("SGP-Postgres"));

            connection.Open();
        }

        public IEnumerable<Aluno> Listar()
        {
            var sql = @"SELECT * FROM public.ALUNOS";

            return connection.Query<Aluno>(sql);
        }

        public void Salvar(Aluno aluno)
        {
            connection.Insert(aluno);
        }
    }
}