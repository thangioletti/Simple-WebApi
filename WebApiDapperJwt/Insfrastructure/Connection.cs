using System;
using Dapper;
using MySql.Data.MySqlClient;

namespace HoltiHubDapper.Insfrastructure
{
	public class Connection
	{
		public Connection()
		{
		}
        protected string conectionString = "Server=localhost;Database=aula;User=root;Password=root;";


        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(conectionString);
        }

        protected async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj); ;
            }
        }
    }
}

