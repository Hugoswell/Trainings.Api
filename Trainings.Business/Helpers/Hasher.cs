namespace Trainings.Business.Helper
{
	using Microsoft.AspNetCore.Cryptography.KeyDerivation;
	using Microsoft.Extensions.Configuration;
	using System;
	using System.Text;
    using Trainings.Business.Interfaces;
    using Trainings.Common.Constants;

    public class Hasher : IHasher
    {
		private readonly IConfiguration _configuration;

		public Hasher(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string HashPassword(string value)
		{
			string salt = _configuration[AppSettings.Salt];
			var valueBytes = KeyDerivation.Pbkdf2(
								password: value,
								salt: Encoding.UTF8.GetBytes(salt),
								prf: KeyDerivationPrf.HMACSHA256,
								iterationCount: 10000,
								numBytesRequested: 256 / 8);
			return Convert.ToBase64String(valueBytes);
		}
	}
}
