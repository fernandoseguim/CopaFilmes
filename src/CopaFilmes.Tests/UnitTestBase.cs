using System;
using System.Linq;

namespace CopaFilmes.Tests
{
	public abstract class UnitTestBase
	{
		protected string MockString(int length = 10)
		{
			var random = new Random();
			const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(CHARS, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
}