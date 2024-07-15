# StudentManagement

Sumário
1. Introdução
2. Tecnologias Utilizadas
3. Estrutura do Projeto
4. Instalação e Configuração
5. Funcionalidades
6. Arquitetura
7. Autenticação e Autorização
8. Testes



# Introdução
O Sistema de Gerenciamento de Estudantes é uma aplicação desenvolvida para facilitar a administração de informações dos alunos. O sistema permite que um administrador (admin) gerencie de forma eficiente e segura os dados dos estudantes, incluindo registro, atualização, consulta e exclusão de informações.

# Tecnologias Utilizadas

Frontend: React, Context API, react-router-dom, bootstrap, sass.
Backend: C#, ASP.NET Core
Autenticação: JWT (JSON Web Tokens)
Banco de Dados: SQL Server

# Estrutura do Projeto

/StudentManagement
  /1 - Web
    /StudentManagement.Web
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
      
  /3 - Domain
    /StudentManagement.Domain
      /Interfaces
        /Repositories
        /Services
      /Models
  /4 - Infrastructure
  /5 - Framework
  /6 - TDD

          
# Instalação e Configuração


Pré-requisitos
Node.js
.NET Core SDK

# Passos para Instalação
Clone o repositório:

bash
Copiar código
git clone: https://github.com/BrunaDan7as/StudentManagement

# Instale as dependências do frontend:

bash
Copiar código
cd frontend
npm install
Instale as dependências do backend:

bash
Copiar código
cd ../backend
dotnet restore
Configuração
Descreva as configurações necessárias, como variáveis de ambiente, configurações de banco de dados, etc.

# Funcionalidades


 # Arquitetura

Padrão MVC e DDD

