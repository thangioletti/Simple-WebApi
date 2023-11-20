using System;
using HoltiHubDapper.Contracts.Repository;
using HoltiHubDapper.Entities;
using Dapper;
using HoltiHubDapper.Insfrastructure;
using MySql.Data.MySqlClient;

namespace HoltiHubDapper.Repository
{
    public class UserRepository : Connection, IUserRepository
    {

        public async Task Add(UserEntity user)
        {
            string sql = @"
                INSERT INTO USER (Name, Email, Password)
                           VALUE (@Name, @Email, @Password)
            ";
            await this.Execute(sql, user);
        }

        public async Task<IEnumerable<UserEntity>> Get()
        {
            string sql = "SELECT * FROM USER";
            return await this.GetConnection().QueryAsync<UserEntity>(sql);
        }

        public async Task<string> LogIn(string email, string password)
        {
            string sql = "SELECT * FROM USER WHERE Email = @email AND Password = @password";
            UserEntity user = await this.GetConnection().QueryFirstAsync<UserEntity>(sql, new { email, password });
            return Authentication.GenerateToken(user);
        }
    }
}

