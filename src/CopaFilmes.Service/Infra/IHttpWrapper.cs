using RestSharp;
using System;

namespace CopaFilmes.Api.Infra
{
	public interface IHttpWrapper
	{
		T Get<T>(Uri uri) where T : new();
	}
}