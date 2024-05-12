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

1. Clone o repositório no seguinte link: https://github.com/PedroPucci/ManageSystemMovie.git e o github do projeto é: https://github.com/PedroPucci/ManageSystemMovie
2. IDE utilizada foi o Visual Studio 2022 
3. Instale as dependências com o comando `dotnet restore`
4. Foi utilizado o banco de dados Postgre
5. Instale o docker e carregue a imagem

# Configuração

Para gerar o banco de dados no ambiente desejado, seguir os passos abaixo:

Versão Local
1. Em appsettings dentro da camada da api do projeto, deve colocar a linha de conexão do banco de dados postgree
2. Utilizado Migrations para gerar o banco de dados, utilizar os seguintes comandos para que o banco de dados seja criado:
2.1 Utilizar dentro do Visual Studio 2022, a ferramenta Package Manager Console na camada do repository e digitar nessa ordem os seguintes comandos
2.2 add-migration MigrationInitial
2.3 update-database

{
  "ConnectionStrings": {
    "WebApiDatabase": "Server=localhost;Port=3306;Database=MovieDatabase;Uid=root;Pwd=123456;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
-------------------------------
Versão do docker
1. Em appsettings dentro da camada da api do projeto, deve colocar a linha de conexão do banco de dados postgree/docker
2. Com o docker instalado carrega a imagem

Para criar a imagem

1. Use o comando no gitbash do projeto: docker pull mysql
2. A linha de comando para a conexão(nesse caso a porta3306 esteja ocupada usar a 3307): docker run --name meu-mysql -e MYSQL_ROOT_PASSWORD=123456 -e MYSQL_DATABASE=MovieDatabase -p 3307:3306 -d mysql 
3. Depois com o docker aberto rodar a imagem e o projeto

{
  "ConnectionStrings": {
    "WebApiDatabase": "Server=localhost;Port=3307;Database=MovieDatabase;Uid=root;Pwd=123456;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

## Exemplo de Arquivo de Configuração

Versão do docker:
{
  "ConnectionStrings": {
    "WebApiDatabase": "Server=localhost;Port=3307;Database=MovieDatabase;Uid=root;Pwd=123456;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Versão local:
{
  "ConnectionStrings": {
    "WebApiDatabase": "Server=localhost;Port=3306;Database=MovieDatabase;Uid=root;Pwd=123456;"
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

POST /api/v1/movie
	
Response body
{
  "success": true
}

{
  "modificationDate": "2024-05-12T14:14:48.035Z",
  "name": "string",
  "director": "string",
  "timeMovie": 0
}

GET /api/v1/movie/all

Response body
Download

[
  {
    "name": "string",
    "director": "string11111",
    "timeMovie": 0,
    "id": 0,
    "createDate": "2024-05-12T14:18:20.0675523Z"
  },
  {
    "name": "string",
    "director": "string012",
    "timeMovie": 0,
    "id": 0,
    "createDate": "2024-05-12T14:18:20.0701909Z"
  }
]

# Estrutura do Projeto

1. Camada da API
Esta camada é responsável pela comunicação com o front-end ou outro sistema que acessará os endpoints criados. Recebe um JSON e comunica-se com a camada de Application.

2. Camada Application
Responsável pela lógica de negócios do projeto, tratamento de erros e interação com a camada de banco de dados.

3. Camada Domain
Esta camada contém as entidades que representam objetos do mundo real dentro do contexto do projeto.

4. Camada Repository
Responsável por realizar operações de inserção, atualização e listagem no banco de dados.

5. Camada Sharead
Responsável por fornecer validações personalizadas para cada contexto das entidades.

# Tecnologias Utilizadas

1. EntityFramework
2. Migrations
3. PostgreSQL
4. Docker
5. FluentValidation
6. SerialLog
7. UnitOfWork
8. Xunit

# Execução e Testes

## Execução do projeto
Para executar o projeto, é necessário configurar o arquivo appsettings para apontar para uma versão local e ter o MySQL instalado, ou então apontar para a versão do Docker, que também requer o Docker instalado. 
Em seguida, certifique-se de que a camada da API esteja definida como o projeto principal. Para isso, clique com o botão direito sobre a camada da API e escolha a opção "Set as Startup Project".

## Execução dos testes
Para executar os testes, é necessário instalar o Xunit. Para isso, vá até "Manage NuGet Packages" clicando com o botão direito sobre a solução e procure por "xunit", então instale-o. Em seguida, vá até o menu "Test" e execute todos os testes.