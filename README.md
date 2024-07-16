# Gerenciamento de Estudantes

Sumário
1. Introdução
2. Tecnologias Utilizadas
3. Estrutura do Projeto
4. Instalação
5. Como executar
6. Arquitetura
7. Autenticação e Autorização
8. Testes
9. Explicação de Cada Tecnologia

## Introdução

Este é um projeto de gerenciamento de estudantes, desenvolvido utilizando uma arquitetura baseada em MVC e DDD. O projeto inclui autenticação JWT, testes unitários, documentação de API com Swagger e um front-end em React.

## Tecnologias Utilizadas

- **Backend**: ASP.NET Core, Entity Framework Core
- **Frontend**: React, Bootstrap, Sass, Context API, Axios, react-bootstrap, dayjs
- **Autenticação**: JWT (JSON Web Tokens)
- **Testes**: xUnit
- **Documentação**: Swagger
- **Banco de Dados**: Em memória com EF Core, populado a partir de um documento CSV
- **Gerenciador de Pacotes**: Node.js (para o frontend)

# Estrutura do Projeto

```plaintext
# Estrutura do Projeto

/StudentManagement
  /1 - Web
    /StudentManagement.Web
      /Controllers
      Program.cs
      /ClientApp
        /public
        /src
          /components
          /context
          /models
          /pages
          /services
          /styles
        package.json
        README.md
        
  /2 - Application
    /StudentManagement.Application
      /Services
        /Authentication
        
  /3 - Domain
    /StudentManagement.Domain
      /Interfaces
        /Repositories
        /Services
      /Models
      
  /4 - Infrastructure
    /StudentManagement.DependencyInjection
    /StudentManagement.Infrastructure
      /Context
      /Map
      /Repository
		
  /5 - Framework
    /StudentManagement.DataTransferObject
      /Authentication
        /Request
        /Response
      /Student
        /Request
        /Response
        
  /6 - TDD
    /StudentManagement.Tests
      StudentTests.cs
````
## Instalação

1. Clone o repositório:

    ```sh
    git clone https://github.com/BrunaDan7as/StudentManagement.git
    cd StudentManagement
    ```

2.O banco de dados em memória já está configurado no `Program.cs` com o context.Database.EnsureCreated(); para que banco de dados seja criado e carregar os dados do CSV.

4. Navegue até a pasta do frontend e instale as dependências:

    ```sh
    cd ClientApp
    npm install
    ```
## Como Executar

1. Inicie o backend:

    ```sh
    dotnet run
    ```

    O Swagger estará disponível em `https://localhost:7040/index.html`.

2. Inicie o frontend:

    ```sh
    cd ClientApp
    npm start
    ```

    O frontend estará disponível em `http://localhost:44440/`.

## Arquitetura

- **MVC (Model-View-Controller)**: Estrutura básica do projeto backend.
- **DDD (Domain-Driven Design)**: Organização do código em domínios específicos.
- **JWT**: Utilizado para autenticação e autorização.
- **Swagger**: Para documentação da API.

##Autenticação e Autorização

A autenticação e autorização são implementadas utilizando JWT (JSON Web Tokens) usado para autenticar usuários em um sistema e o JWT Bearer que permite que os tokens JWT sejam usados para autenticação(nesse caso no Swagger). Esta abordagem permite que a aplicação proteja endpoints de forma eficiente e segura.

## Testes

### Testes Unitários

Os testes unitários estão localizados na pasta `StudentManagement.Tests`. Para executar os testes, utilize o comando:

```sh
dotnet test

## Requisitos

- .NET Core SDK
- Node.js
````


##Explicação de Cada Tecnologia

###Backend:

ASP.NET Core: Um framework de desenvolvimento web de código aberto e multiplataforma.
Entity Framework Core: Um ORM (Object-Relational Mapper) para .NET que permite trabalhar com um banco de dados usando objetos .NET.

###Frontend:

React: Uma biblioteca JavaScript para construção de interfaces de usuário.
Bootstrap: Um framework CSS para desenvolvimento de interfaces responsivas e modernas.
Sass: Um pré-processador CSS que permite utilizar funcionalidades como variáveis, aninhamento e mixins.
Context API: Uma API do React para gerenciar o estado global da aplicação.
Axios: Uma biblioteca para fazer requisições HTTP.
react-bootstrap: Componentes do Bootstrap desenvolvidos especificamente para o React.
dayjs: Uma biblioteca JavaScript para manipulação e formatação de datas.
Autenticação:

JWT (JSON Web Tokens): Um padrão aberto para criação de tokens de acesso que permitem a autenticação entre diferentes partes de um sistema.
Testes:

xUnit: Um framework para criação de testes unitários em .NET.
Documentação:

Swagger: Uma ferramenta para documentação de APIs que permite testar endpoints diretamente na interface web.
Banco de Dados:

Em memória com EF Core: Utilização do Entity Framework Core para trabalhar com um banco de dados em memória, populado a partir de um documento CSV.
Gerenciador de Pacotes:

Node.js: Uma plataforma JavaScript utilizada para executar código fora do navegador, geralmente usada para gerenciar pacotes e dependências do frontend.








          





