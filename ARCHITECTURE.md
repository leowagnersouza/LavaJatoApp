# Arquitetura — LavaJatoApp

## Visão Geral

O projeto segue os princípios da **Clean Architecture** com influências de **DDD (Domain-Driven Design)**.
O objetivo é garantir separação de responsabilidades, testabilidade e escalabilidade, especialmente
à medida que o domínio de negócio (agendamento, lavagens, pagamentos) cresce.

---

## Estrutura de Projetos

```
LavaJatoApp.sln
│
├── LavaJatoApp.Domain          # Núcleo do negócio — sem dependências externas
├── LavaJatoApp.Application     # Orquestração — casos de uso e regras de aplicação
├── LavaJatoApp.Infrastructure  # Implementações técnicas — banco, APIs, storage
├── LavaJatoApp.Shared          # Utilitários cross-cutting — Result<T>, exceções, extensões
└── LavaJatoApp.MAUI            # Camada de apresentação — UI, ViewModels, navegação, DI
```

---

## Detalhamento por Camada

### `LavaJatoApp.Domain`
Núcleo do domínio. **Não referencia nenhum outro projeto da solução.**

```
Domain/
├── Entities/           # Objetos com identidade (ex: Agendamento, Cliente, Veiculo)
├── ValueObjects/       # Objetos sem identidade (ex: Placa, HorarioDisponivel)
└── Interfaces/
    └── Repositories/   # Contratos de repositório (ex: IAgendamentoRepository)
```

---

### `LavaJatoApp.Application`
Orquestra o domínio para atender às necessidades da aplicação.
Referencia apenas `Domain` e `Shared`.

```
Application/
├── UseCases/           # Um por caso de uso (ex: CriarAgendamentoUseCase)
├── DTOs/               # Objetos de transferência — evita vazar entidades para a UI
├── Services/           # Application Services (coordenação entre use cases)
├── Handlers/           # Handlers de comandos/eventos (ex: MediatR)
└── Interfaces/
    └── Services/       # Contratos de serviços externos (ex: INavigationService, INotificationService)
```

> **Nota:** `INavigationService` vive aqui como contrato. A implementação concreta fica no projeto MAUI.
> Isso permite que ViewModels naveguem sem referenciar páginas concretas.

---

### `LavaJatoApp.Infrastructure`
Implementa os contratos definidos em `Domain` e `Application`.
Referencia `Domain`, `Application` e `Shared`.

```
Infrastructure/
├── Repositories/       # Implementações concretas dos repositórios (ex: SQLite, REST)
├── Data/               # Contexto de banco de dados, migrations
└── ExternalServices/   # Integrações com APIs externas (ex: pagamento, notificações)
```

---

### `LavaJatoApp.Shared`
Utilitários sem lógica de negócio, compartilhados entre todas as camadas.
**Não referencia nenhum outro projeto da solução.**

```
Shared/
├── Result.cs           # Result<T> para retornos sem exceções
├── Errors/             # Tipos de erro padronizados
└── Extensions/         # Extensões de tipo (ex: StringExtensions)
```

---

### `LavaJatoApp.MAUI`
Camada de apresentação. Referencia `Application` e `Shared`.
**Nunca referencia `Domain` ou `Infrastructure` diretamente.**

```
MAUI/
├── Pages/              # Views XAML (ex: LoginPage, AgendamentoPage)
├── ViewModels/         # Presentation logic — bindam com as Pages
├── Navigation/         # Implementação concreta de INavigationService
├── Resources/          # Fontes, imagens, estilos, cores
└── MauiProgram.cs      # Registro de DI (Pages, ViewModels, Services)
```

---

## Fluxo de Dependências

```
MAUI  ──►  Application  ──►  Domain
  │              │
  └──►  Shared  ◄┘

Infrastructure  ──►  Domain
Infrastructure  ──►  Application
Infrastructure  ──►  Shared
```

A seta indica "depende de". `Domain` e `Shared` não apontam para ninguém.

---

## Status Atual

> O projeto está em fase de **mockup/prototipação**.
> Atualmente todos os arquivos residem em `LavaJatoApp.MAUI`.
> A separação em projetos será feita de forma incremental conforme o domínio de negócio amadurecer.

| Camada                       | Status        |
| ---------------------------- | ------------- |
| `LavaJatoApp.MAUI`           | ✅ Em progresso |
| `LavaJatoApp.Application`    | 🔲 Planejado  |
| `LavaJatoApp.Domain`         | 🔲 Planejado  |
| `LavaJatoApp.Infrastructure` | 🔲 Planejado  |
| `LavaJatoApp.Shared`         | 🔲 Planejado  |

---

## Referências

- [Clean Architecture — Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [.NET MAUI Documentation](https://learn.microsoft.com/dotnet/maui/)
- [MediatR](https://github.com/jbogard/MediatR)

