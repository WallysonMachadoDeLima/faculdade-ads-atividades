# Projeto AulaCrud

Este projeto foi criado baseado no padrão do projeto `02-partial-view` (ASP.NET Core MVC com .NET 8), mas evoluído para conter um **CRUD completo de Aulas** com persistência em banco de dados **MySQL** e documentação da API via **Swagger**.

---

## Tecnologias Utilizadas

- **ASP.NET Core 8.0** (MVC)
- **Entity Framework Core 8.0**
- **Pomelo.EntityFrameworkCore.MySql** (provider MySQL)
- **Swashbuckle.AspNetCore** (Swagger UI)
- **Bootstrap 5** (já incluso no template MVC)

---

## Estrutura do Projeto

```
AulaCrud/
├── Controllers/
│   ├── AulasController.cs      # Controller com as ações do CRUD (Index, Create, Edit, Details, Delete)
│   └── HomeController.cs       # Controller padrão da aplicação
├── Data/
│   └── ApplicationDbContext.cs # Contexto do Entity Framework para acesso ao MySQL
├── Models/
│   ├── Aula.cs                 # Modelo da entidade Aula
│   └── ErrorViewModel.cs       # Modelo padrão de erro
├── Views/
│   ├── Aulas/
│   │   ├── Index.cshtml        # Lista de aulas
│   │   ├── Create.cshtml       # Formulário de criação
│   │   ├── Edit.cshtml         # Formulário de edição
│   │   ├── Details.cshtml      # Visualização de detalhes
│   │   └── Delete.cshtml       # Confirmação de exclusão
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _ValidationScriptsPartial.cshtml
│       └── Error.cshtml
├── wwwroot/                    # Arquivos estáticos (CSS, JS, imagens)
├── appsettings.json            # Configurações, incluindo a Connection String do MySQL
├── Program.cs                  # Configuração da aplicação (DI, pipeline, Swagger, EF Core)
└── EXPLICACAO.md               # Este arquivo
```

---

## Configuração do Banco de Dados

A connection string está configurada no arquivo `appsettings.json`:

```json
"Server=192.168.97.2;Port=3306;Database=AulaCrudDb;Uid=root;Pwd=root;"
```

O Entity Framework Core foi configurado no `Program.cs` para usar o provider **Pomelo MySQL**.

### Migrations aplicadas
- Foi criada a migration `InitialCreate` que gerou a tabela `Aulas` no banco `AulaCrudDb`.

---

## Modelo Aula

A entidade `Aula` possui os seguintes campos:

| Campo       | Tipo       | Descrição                          |
|-------------|------------|------------------------------------|
| `Id`        | `int`      | Identificador único (PK)           |
| `Titulo`    | `string`   | Título da aula (obrigatório)       |
| `Descricao` | `string`   | Descrição da aula                  |
| `DataHora`  | `DateTime` | Data e hora da aula (obrigatório)  |
| `Duracao`   | `int`      | Duração em minutos (obrigatório)   |
| `Professor` | `string`   | Nome do professor (obrigatório)    |

---

## Endpoints Disponíveis

### Aplicação Web (MVC)
- **Lista de Aulas**: `https://localhost:7192/Aulas`
- **Nova Aula**: `https://localhost:7192/Aulas/Create`

### Swagger (Documentação da API)
- **Swagger UI**: `https://localhost:7192/swagger`
- **Swagger JSON**: `https://localhost:7192/swagger/v1/swagger.json`

---

## Como Executar

1. Certifique-se de que o banco MySQL em `192.168.97.2:3306` está acessível.
2. Na pasta do projeto, execute:
   ```bash
   dotnet run
   ```
3. Acesse a aplicação em `https://localhost:7192` (ou `http://localhost:5015`).
4. Acesse o Swagger em `https://localhost:7192/swagger`.

---

## Observações

- O projeto segue a mesma estrutura e estilo do projeto `02-partial-view` (MVC com Bootstrap).
- Foram adicionados DataAnnotations no modelo `Aula` para validação dos campos nos formulários.
- O Swagger foi configurado para documentar automaticamente os endpoints expostos pela aplicação.
