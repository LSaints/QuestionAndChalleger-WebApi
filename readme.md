# QuestionAndChallenger

 Este repositorio abriga uma API simples em .NET para executar operações CRUD
em uma entidade chamada "Question". 

A entidade "Question" é definida por três campos principais: "description", "level" e "category". 

Algumas das tecnologias adotadas:

+ ASP.NET CORE API
+ EntityFramework Core (Utilizando CodeFirst)
+ C#
+ SQL Server
+ XUnit


JSON de Question:

{
   "id": 0,
   "description": "string",
   "level": 0, 
   "category": 0 
} 
+ onde level = 0 = "soft", 1 = "moderate", 2 = "hot"
+ onde category = 0 = "question", 1 = "challeger"
