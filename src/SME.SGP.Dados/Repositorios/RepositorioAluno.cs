using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Repositorios;
using System.Collections.Generic;
using System.Data;

namespace SME.SGP.Dados.Repositorios
{
    public class RepositorioAluno : IRepositorioAluno
    {
        private NpgsqlConnection connection;
        private IDbConnection connection2;

        public RepositorioAluno(IConfiguration configuration)
        {
            //connection = new NpgsqlConnection(configuration.GetConnectionString("SGP-Postgres"));
            connection2 = new NpgsqlConnection(configuration.GetConnectionString("SGP-Postgres"));
            connection2.Open();
        }

        public IEnumerable<Aluno> Listar()
        {
            var sql = @"SELECT * FROM ALUNO";

            return connection.Query<Aluno>(sql);
        }

        public void Salvar(Aluno aluno)
        {
            connection2.Insert<Aluno>(aluno);
        }
    }
}