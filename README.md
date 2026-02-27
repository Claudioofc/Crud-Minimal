# 🚀 Crud Minimal API - .NET 8/9

Este projeto é uma API robusta desenvolvida para praticar e demonstrar padrões arquiteturais modernos em .NET. Evoluiu de um CRUD simples para uma aplicação segura, utilizando autenticação JWT e padrões de design como DTOs e Soft Delete.

## 🛠 Tecnologias Utilizadas

* **.NET 8/9** (Minimal APIs)
* **Entity Framework Core** (ORM)
* **SQL Server** (Banco de Dados)
* **JWT (JSON Web Token)** (Segurança/Autenticação)
* **Swagger/OpenAPI** (Documentação)

## 🏗 Arquitetura e Boas Práticas

O projeto foi construído focando em **Clean Code** e **Segurança**, implementando:

* **Padrão DTO (Data Transfer Object):** Isolamento total entre as entidades do banco de dados e os dados trafegados na API.
* **Soft Delete:** Exclusão lógica de registros para manter a integridade histórica dos dados.
* **Encapsulamento:** Modelos com estados protegidos, garantindo que a lógica de negócio permaneça dentro da entidade.
* **Security Extensions:** Configurações de segurança isoladas para manter o `Program.cs` limpo e modular.
* **Git Hygiene:** Uso rigoroso de `.gitignore` para proteção de segredos e arquivos de ambiente.

## 🔒 Segurança (JWT)

As rotas de gerenciamento de pessoas (`/person`) são protegidas. Para acessá-las:
1. Realize o login na rota `/login`.
2. Copie o Token gerado.
3. Utilize o botão **Authorize** no Swagger ou o Header **Authorization: Bearer [seu_token]** no Postman.



## 🚀 Como Executar o Projeto

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/Claudioofc/Crud-Minimal.git](https://github.com/Claudioofc/Crud-Minimal.git)