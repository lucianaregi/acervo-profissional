# Acervo Profissional

Backend da plataforma Acervo Profissional, construído em .NET 10 com arquitetura modular.

## Estrutura do repositório

```
acervo-profissional/
├── src/
│   ├── Hosts/
│   │   ├── AcervoProfissional.Api        # Web API REST
│   │   ├── AcervoProfissional.Worker     # Background worker
│   │   └── AcervoProfissional.Mcp        # Host MCP (Model Context Protocol)
│   ├── Modules/
│   │   ├── AcervoProfissional.Career     # Módulo de carreira
│   │   └── AcervoProfissional.Recruiting # Módulo de recrutamento
│   └── Infrastructure/
│       └── AcervoProfissional.Infrastructure  # Infraestrutura compartilhada
└── tests/
    ├── AcervoProfissional.UnitTests
    └── AcervoProfissional.IntegrationTests
```

## Pré-requisitos

| Ferramenta | Versão mínima | Verificar |
|---|---|---|
| [.NET SDK](https://dotnet.microsoft.com/download) | 10.0 | `dotnet --version` |
| [Git](https://git-scm.com/) | 2.x | `git --version` |

## Configuração do ambiente local

### 1. Clonar o repositório

```bash
git clone https://github.com/lucianaregi/acervo-profissional.git
cd acervo-profissional
```

### 2. Criar o arquivo de variáveis locais

```bash
cp .env.example .env
```

Abra o `.env` e preencha as variáveis necessárias para o seu ambiente. O arquivo `.env` **não é versionado** — nunca o commite.

> Consulte `.env.example` para ver todas as variáveis disponíveis e seus valores esperados.

### 3. Restaurar dependências

```bash
dotnet restore AcervoProfissional.slnx
```

### 4. Compilar a solution

```bash
dotnet build AcervoProfissional.slnx --configuration Release
```

Resultado esperado: `0 Erro(s)` e `0 Aviso(s)`.

## Executar os hosts

Cada host deve ser executado em um terminal separado.

### API

```bash
dotnet run --project src/Hosts/AcervoProfissional.Api
```

Disponível em:
- HTTP: `http://localhost:5226`
- HTTPS: `https://localhost:7287`

### Worker

```bash
dotnet run --project src/Hosts/AcervoProfissional.Worker
```

### MCP

```bash
dotnet run --project src/Hosts/AcervoProfissional.Mcp
```

## Executar os testes

```bash
dotnet test AcervoProfissional.slnx
```

## Secrets e configurações sensíveis

Credenciais, tokens e connection strings **nunca devem ser versionados**. O padrão adotado é:

| Arquivo | Versionado | Finalidade |
|---|---|---|
| `.env.example` | ✅ Sim | Modelo com nomes de variáveis e valores fictícios |
| `.env` | ❌ Não | Valores reais do ambiente local |

Variáveis seguem a convenção `SCREAMING_SNAKE_CASE` com prefixo por contexto (`API_`, `WORKER_`, `MCP_`, `CONNECTION_`, `JWT_`).
