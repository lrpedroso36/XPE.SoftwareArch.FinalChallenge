# XPE.SoftwareArch.FinalChallenge

## Desafio Final – Bootcamp Arquiteto(a) de Software (XP Educação)

Projeto final com foco na aplicação de conceitos de arquitetura de software moderna, por meio da construção de uma **API RESTful** seguindo o padrão **MVC** e estruturada com **Clean Architecture**.

---

## Objetivo

Criar uma solução que exponha dados do domínio de **Produto** para parceiros da empresa, com operações completas de **CRUD** por meio de uma API REST.

---

## Tecnologias e Arquitetura

- **Linguagem:** C#  
- **Framework:** ASP.NET Core  
- **Padrão:** MVC na camada de API  
- **Arquitetura:** Clean Architecture, com separação em:
  - `Domain`
  - `Application`
  - `Infrastructure`
  - `IOC` (Inversão de Controle)

- **Documentação:** Swagger (OpenAPI)

---

## Funcionalidades

A API expõe operações CRUD sobre o domínio de **Produto**:

- `GET /v1/api/products`
- `GET /v1/api/products/count`
- `GET /v1/api/products/{id}`
- `GET /v1/api/products/{name}`
- `POST /v1/api/products`
- `PUT /v1/api/products/{id}`
- `DELETE /v1/api/products/{id}`

---

## Organização do Código

- `Domain`: entidades e interfaces do núcleo de negócio  
- `Application`: casos de uso e DTOs  
- `Infrastructure`: acesso a dados (ex: EF Core)  
- `API`: camada de entrada, controladores e middlewares  
- `IOC`: configuração de injeção de dependência