using System;

namespace CopaFilmes.Service.Infra
{
	public interface IHttpWrapper
	{
		T Get<T>(Uri uri) where T : new();
	}
}