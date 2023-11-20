using System;
using HoltiHubDapper.Entities;

namespace HoltiHubDapper.Contracts.Repository
{
	public interface IUserRepository
	{
		Task Add(UserEntity user);

		Task<IEnumerable<UserEntity>> Get();

		Task<string> LogIn(string email, string password);
	}
}

