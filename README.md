# API - QuizApp

Este é um projeto de uma Web API usando ASP.NET Core 8.0, para Criar e Armazenar Quizzes [empregos.com](https://www.empregos.com.br/).

## Como Rodar

Certifique-se de ter o SDK do .NET 8.0 instalado. Você pode baixá-lo em [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
    git clone https://github.com/RyanFurt12/DotNetApiQuizApp.git
    cd DotNetApiQuizApp
    
    dotnet watch run
```
    
## Resposta

A aplicação executará no seu console, e automaticamente abrirá na pagina do Swagger:
_Caso isso não ocorra, estará rodado em http://localhost:5001_

Exemplo de saída do Get, e esperado no Post
```json
{
    "id": 0,
    "title": "Qual Vegetal?",
    "questions": [
      {
        "id": 0,
        "title": "Qual Vegetal ?",
        "options": [
          {"id": 0, "name":"Batata", "alias":"A"},
          {"id": 0, "name":"Cenoura", "alias":"B"},
          {"id": 0, "name":"Alecrim", "alias":"C"}
        ]
      }
    ],
    "results": [
      {"id": 0, "alias": "A", "text": "Batata"},
      {"id": 0, "alias": "B", "text": "Cenoura"},
      {"id": 0, "alias": "C", "text": "Alecrim"}
    ]
}
```