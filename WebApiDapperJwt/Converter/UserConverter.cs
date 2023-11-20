using System;
using HoltiHubDapper.DTO;
using HoltiHubDapper.Entities;

namespace HoltiHubDapper.Converters
{
	public class UserConverter
	{
		
		public static UserEntity Convert(UserDTO user)
		{
			UserEntity userEntity = new UserEntity()
			{
                Name = user.Name,
				Email = user.Email,
				Password = user.Password
			};
			return userEntity;
		}
	}
}

