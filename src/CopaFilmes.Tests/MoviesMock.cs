namespace CopaFilmes.Tests
{
	public class MoviesMock
	{
		public static string RegularCase { get; } = @"[  
								   {  
									  ""id"":""tt3606756"",
									  ""title"":""Os Incríveis 2"",
									  ""year"":2018,
									  ""score"":8.5
								   },
								   {  
									  ""id"":""tt4881806"",
									  ""title"":""Jurassic World: Reino Ameaçado"",
									  ""year"":2018,
									  ""score"":6.7
								   },
								   {  
									  ""id"":""tt5164214"",
									  ""title"":""Oito Mulheres e um Segredo"",
									  ""year"":2018,
									  ""score"":6.3
								   },
								   {  
									  ""id"":""tt7784604"",
									  ""title"":""Hereditário"",
									  ""year"":2018,
									  ""score"":7.8
								   },
								   {  
									  ""id"":""tt4154756"",
									  ""title"":""Vingadores: Guerra Infinita"",
									  ""year"":2018,
									  ""score"":8.8
								   },
								   {  
									  ""id"":""tt5463162"",
									  ""title"":""Deadpool 2"",
									  ""year"":2018,
									  ""score"":8.1
								   },
								   {  
									  ""id"":""tt3778644"",
									  ""title"":""Han Solo: Uma História Star Wars"",
									  ""year"":2018,
									  ""score"":7.2
								   },
								   {  
									  ""id"":""tt3501632"",
									  ""title"":""Thor: Ragnarok"",
									  ""year"":2017,
									  ""score"":7.9
								   }
								]";

		public static string CaseOfATie => @"[  
								   {  
									  ""id"":""tt3606756"",
									  ""title"":""Os Incríveis 2"",
									  ""year"":2018,
									  ""score"":8.8
								   },
								   {  
									  ""id"":""tt4881806"",
									  ""title"":""Jurassic World: Reino Ameaçado"",
									  ""year"":2018,
									  ""score"":8.8
								   },
								   {  
									  ""id"":""tt5164214"",
									  ""title"":""Oito Mulheres e um Segredo"",
									  ""year"":2018,
									  ""score"":6.3
								   },
								   {  
									  ""id"":""tt7784604"",
									  ""title"":""Hereditário"",
									  ""year"":2018,
									  ""score"":7.8
								   },
								   {  
									  ""id"":""tt4154756"",
									  ""title"":""Vingadores: Guerra Infinita"",
									  ""year"":2018,
									  ""score"":8.8
								   },
								   {  
									  ""id"":""tt5463162"",
									  ""title"":""Deadpool 2"",
									  ""year"":2018,
									  ""score"":8.8
								   },
								   {  
									  ""id"":""tt3778644"",
									  ""title"":""Han Solo: Uma História Star Wars"",
									  ""year"":2018,
									  ""score"":7.2
								   },
								   {  
									  ""id"":""tt3501632"",
									  ""title"":""Thor: Ragnarok"",
									  ""year"":2017,
									  ""score"":7.9
								   }
								]";
	}
}
