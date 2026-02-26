# Person API - CRUD com Soft Delete

Este projeto é uma API desenvolvida em .NET para gerenciamento de pessoas, focada na prática de operações CRUD e na implementação de exclusão lógica (**Soft Delete**).

## 🚀 Tecnologias Utilizadas
- .NET 9 / Minimal APIs
- Entity Framework Core
- SQL Server (LocalDB)
- Swagger / Postman (Testes)

## 🛠️ Funcionalidades
- **Create**: Cadastro de pessoas.
- **Read**: Listagem de registros (apenas os ativos).
- **Update**: Edição de dados existentes.
- **Soft Delete**: Os dados não são excluídos do banco, apenas marcados com a flag `IsDeleted`.
- **Restore**: Rota bônus para reativar registros deletados.

## 🏁 Como rodar o projeto
1. Clone o repositório.
2. No terminal, execute:
   ```bash
   dotnet ef database update
   dotnet run