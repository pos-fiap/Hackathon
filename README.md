# Hackathon API

## Tecnologias Utilizadas

- .NET 7
- SQL Server LocalDB
- Entity Framework


## Integrantes do Projeto

- Ricardo Maciel da Silva
- Jacó Isaque dos Santos Penteado
- Luana Santos Lima
- Luiz Gustavo Mendes Batista
- João Carlos Baldi Júnior

## Requisitos

Antes de rodar a API, certifique-se de que você tenha os seguintes pré-requisitos instalados:

- [SDK do .NET 7](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

## Configuração do Banco de Dados

1. Abra o Visual Studio Code ou sua IDE preferida.
2. Abra o arquivo `appsettings.json` na pasta raiz do projeto e configure a string de conexão com o SQL Server LocalDB de acordo com suas preferências:

```json
"ConnectionStrings": {
   "Default": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TechChallenge;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server             
   Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
}
```

### Executando as Migrações do Banco de Dados
Para criar ou atualizar o banco de dados, basta iniciar a aplicação.

## Executando a API
Abra um terminal na pasta do projeto. Execute o seguinte comando para iniciar a API:

```
dotnet run
```

A API estará disponível em http://localhost:5023. Você pode acessar os endpoints da API para realizar operações de controle de vagas de estacionamento.

Após executado, para o primeiro login e criação dos próximos usuários, utilize o seguinte login e senha:
Login: ricardomacieldasilva@hotmail.com
Senha: 1

Ao realizar o login, copie o token e cole-o no botão Authorize localizado no canto superior direito do swagger da aplicação, não esquecendo de adicionar a palavra bearer no começo.
