# CopaFilmes &middot; [![Build status](https://seguimit.visualstudio.com/CopaFilmes/_apis/build/status/CopaFilmes-ASP.NET%20Core-CI)](https://seguimit.visualstudio.com/CopaFilmes/_build/latest?definitionId=-1)

To restore and build project
```
dotnet restore
dotnet build
```

To run project

```
dotnet run
```

## Test this Service API on Postman
[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/0caaf7f361f55c3d0d1b)


## Endpoints

### [Get] Get All Movies

http://localhost:5000/api/movies

#### Response

```json
[
    {
        "id": "tt3606756",
        "title": "Os Incríveis 2",
        "year": 2018,
        "score": 8
    },
    {
        "id": "tt4881806",
        "title": "Jurassic World: Reino Ameaçado",
        "year": 2018,
        "score": 7
    },
    {
        "id": "tt5164214",
        "title": "Oito Mulheres e um Segredo",
        "year": 2018,
        "score": 6
    },
    {
        "id": "tt7784604",
        "title": "Hereditário",
        "year": 2018,
        "score": 8
    }
    ...
]
```

### [POST] Get Winners 

http://localhost:5000/api/movies/winners

NOTE: To get the winners movies is necessary to send a request with a movies list with 8 items exactly in the request body 

#### Body

```json
{ 
  "Movies" : [
      {
          "id": "tt3606756",
          "title": "Os Incríveis 2",
          "year": 2018,
          "score": 8
      },
      {
          "id": "tt4881806",
          "title": "Jurassic World: Reino Ameaçado",
          "year": 2018,
          "score": 7
      },
      {
          "id": "tt5164214",
          "title": "Oito Mulheres e um Segredo",
          "year": 2018,
          "score": 6
      },
      {
          "id": "tt7784604",
          "title": "Hereditário",
          "year": 2018,
          "score": 8
      },
      {
          "id": "tt4154756",
          "title": "Vingadores: Guerra Infinita",
          "year": 2018,
          "score": 9
      },
      {
          "id": "tt5463162",
          "title": "Deadpool 2",
          "year": 2018,
          "score": 8
      },
      {
          "id": "tt3778644",
          "title": "Han Solo: Uma História Star Wars",
          "year": 2018,
          "score": 7
      },
      {
          "id": "tt3501632",
          "title": "Thor: Ragnarok",
          "year": 2017,
          "score": 8
      }
  ]
}
```

#### Response

```json
{
    "success": true,
    "data": [
        {
            "id": "tt4154756",
            "title": "Vingadores: Guerra Infinita",
            "year": 2018,
            "score": 9
        },
        {
            "id": "tt5463162",
            "title": "Deadpool 2",
            "year": 2018,
            "score": 8
        }
    ]
}
```

