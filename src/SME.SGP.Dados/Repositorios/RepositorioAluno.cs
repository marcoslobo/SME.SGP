using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Repositorios;
using System.Collections.Generic;
using System.Data;

namespace SME.SGP.Dados.Repositorios
{
    public class RepositorioAluno : IRepositorioAluno
    {
        private IDbConnection connection;

        public RepositorioAluno(IDbConnection dbConnection)
        {
            connection = dbConnection;
        }

        public IEnumerable<Aluno> Listar()
        {
            var sql = "SELECT * FROM Alunos";

            return connection.Query<Aluno>(sql);
        }

        public void Salvar(Aluno aluno)
        {
            using (var connection2 = new NpgsqlConnection("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=sgp_db;Pooling=true;"))
            {
                connection2.Open();
                connection2.Insert(aluno);
            }
        }
    }
}