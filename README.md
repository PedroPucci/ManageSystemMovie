# Nome do Projeto

Implementar uma API resful em dotnet7
Pode ser utilizado uma arquitetura em camadas simples MVC
A API deve ser possível gerenciar os filmes que passam em uma determinando sala de cinema
- Sala (Número da Sala, Descrição)
- Filme (Nome, diretor, duração)
- Uma sala pode ter vários filmes
- um filme pode existir sem uma sala
Criação de testes unitários (Controller e camada de serviço)
Utilização do banco mysql
Configuração do swagger
compartilhar no github

Plus
- docker
- docker-compose 
- paginação dinâmica das consultas
Dica importante:
- Obedecer http code

## Instalação

1. Clone o repositório no seguinte link: "https://github.com/PedroPucci/SistemaListaAtividade.git" e o github do projeto é: https://github.com/PedroPucci/SistemaListaAtividade
2. IDE utilizada foi o Visual Studio 2022 
3. Instale as dependências com o comando `dotnet restore`
4. Foi utilizado o banco de dados Postgre

# Configuração

Explique aqui como configurar o projeto para execução local ou em ambientes específicos.

Para gerar o banco de dados no ambiente desejado, seguir os passos abaixo:

1. Em appsettings dentro da camada da api do projeto, deve colocar a linha de conexão do banco de dados postgree
2. Utilizado Migrations para gerar o banco de dados, utilizar os seguintes comandos para que o banco de dados seja criado:
2.1 Utilizar dentro do Visual Studio 2022, a ferramenta Package Manager Console na camada do repository e digitar nessa ordem os seguintes comandos
2.2 add-migration MigrationInitial
2.3 update-database

## Exemplo de Arquivo de Configuração

{
  "ConnectionStrings": {
    "WebApiDatabase": "Host=localhost;Port=5432;Database=BancoAtividades;Username=postgres;Password=123456"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

# Endpoints

GET /api/exemplo
{
  "mensagem": "Exemplo de resposta"
}

# Estrutura do Projeto

Descreva a estrutura do projeto, incluindo a organização de pastas e arquivos em cada camada da arquitetura.

# Tecnologias Utilizadas

1. EntityFramework
2. Migrations
3. PostgreSQL
4. FluentValidation
5. SerialLog
6. UnitOfWork
7. Xunit

# Execução e Testes

## Execução do projeto

## Execução dos testes