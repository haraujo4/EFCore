# Minha Aplicação com AutoMapper, EntityFramework, WEB API Asp.Net C# e SQL Server

[![Automapper](https://img.shields.io/badge/AutoMapper-v12.0.1-blue)](https://github.com/AutoMapper/AutoMapper)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-v7.0.12-orange)](https://github.com/dotnet/ef6)
[![ASP.NET Web API](https://img.shields.io/badge/ASP.NET%20Web%20API-v6.0-green)](https://dotnet.microsoft.com/apps/aspnet/apis)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red)](https://www.microsoft.com/en-us/sql-server)

## Configurando a Aplicação

### Conexão com o Banco de Dados

1. Abra o arquivo `appsettings.json`.
2. Localize a seção `ConnectionStrings` e altere a conexão para o seu banco de dados SQL Server.

```json
"ConnectionStrings": {
    "DefaultConnection": "Sua_Connection_String_Aqui"
}
```

### Configurações de Email
1. Abra o arquivo SendEmail.cs.
2. Localize a seção de configurações de email e altere as informações de acordo com suas credenciais e servidor SMTP.


### Executando a Aplicação
Certifique-se de ter todas as dependências instaladas e a conexão com o banco de dados configurada corretamente. Depois, você pode iniciar a aplicação da maneira que preferir.

### Contribuições
Sinta-se à vontade para contribuir para este projeto. Se você encontrar problemas ou melhorias, abra uma issue ou envie um pull request.

### Licença
Este projeto é licenciado sob a MIT License - consulte o arquivo LICENSE para obter detalhes.


```markdown
Lembre-se de substituir "Sua_Connection_String_Aqui" com a sua string de conexão do banco de dados
e as informações de e-mail com as suas credenciais.
Além disso, ajuste os links nos badges (shields) para apontar para
os repositórios relevantes das tecnologias, se aplicável.
