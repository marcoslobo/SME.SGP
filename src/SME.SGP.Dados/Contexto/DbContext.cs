using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace SME.SGP.Dados.Contexto
{
    public class DbContext : IDbConnection
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        public DbContext(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            connectionString = configuration.GetConnectionString("SGP-Postgres");

            Connection = new NpgsqlConnection(connectionString);

            Open();
        }

        public NpgsqlConnection Connection { get; private set; }
        public string ConnectionString { get { return Connection.ConnectionString; } set { Connection.ConnectionString = value; } }

        public int ConnectionTimeout => Connection.ConnectionTimeout;

        public string Database => Connection.Database;

        public ConnectionState State => Connection.State;

        public IDbTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return Connection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            Connection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return Connection.CreateCommand();
        }

        public void Dispose() => Connection.Close();

        public void Open()
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();
            }
            catch (Exception ex)
            {
            }
        }
    }
}