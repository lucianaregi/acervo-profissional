---
inclusion: always
---

# Padrão de configurações locais e secrets

## Regra principal

Credenciais, tokens, connection strings e outros secrets **nunca** devem ser versionados no Git.

## Arquivos

| Arquivo | Versionado | Finalidade |
|---|---|---|
| `.env.example` | ✅ Sim | Modelo com nomes de variáveis e valores fictícios |
| `.env` | ❌ Não (`.gitignore`) | Valores reais do ambiente local do desenvolvedor |

## Como usar

1. Na primeira vez, copie o exemplo: `cp .env.example .env`
2. Preencha `.env` com os valores reais do seu ambiente local
3. Nunca commite o arquivo `.env`

## Convenções de nomeação

- Variáveis em `SCREAMING_SNAKE_CASE`
- Prefixo por contexto: `API_`, `WORKER_`, `MCP_`, `CONNECTION_`, `OPENROUTER_`, `JWT_`
- Variáveis comentadas (`#`) no `.env.example` indicam integrações ainda não implementadas

## Leitura nos projetos .NET

As variáveis do `.env` devem ser carregadas via `DotNetEnv` ou equivalente no `Program.cs` de cada Host, mapeando para `IConfiguration` da forma padrão do ASP.NET Core.

> Enquanto as integrações não estiverem implementadas, as entradas correspondentes ficam comentadas no `.env.example`.
