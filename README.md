# LegalManager.Pro

> **Sistema de Gestao Juridica** - Uma solucao completa para escritorios de advocacia

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![C#](https://img.shields.io/badge/C%23-12.0-green.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com/Willians167/LegalManager.Pro)

## Sobre o Projeto

O **LegalManager.Pro** e um sistema de gestao juridica (LegalTech) desenvolvido com foco em escritorios de advocacia modernos. Construido seguindo os principios da **Clean Architecture** e **Domain Driven Design (DDD)**, oferece uma solucao robusta, escalavel e de facil manutencao.

### Objetivos

- Modernizar a gestao de escritorios de advocacia
- Centralizar informacoes de clientes, processos e documentos
- Automatizar controle de prazos e agenda
- Prover dashboards com indicadores de performance
- Garantir seguranca e conformidade com LGPD

## Funcionalidades

### **Autenticacao e Autorizacao**
- Sistema de autenticacao JWT com Refresh Token
- Controle de acesso baseado em perfis (Admin, Advogado, Assistente)
- Gestao de usuarios com diferentes niveis de permissao

### **Gestao de Usuarios**
- Cadastro e manutencao de usuarios
- Controle de perfis e permissoes
- Historico de acesso e atividades

### **Gestao de Clientes**
- Cadastro completo de pessoas fisicas e juridicas
- Controle de documentos e informacoes de contato
- Historico de relacionamento

### **Gestao de Processos Juridicos**
- Controle completo de processos
- Acompanhamento de andamentos
- Vinculacao com clientes e responsaveis

### **Controle de Prazos e Agenda**
- Sistema de alertas para prazos processuais
- Agenda integrada com processos
- Notificacoes automaticas

### **Gerenciamento de Documentos**
- Upload e organizacao de documentos
- Versionamento e controle de acesso
- Integracao com processos

### **Dashboard e Relatorios**
- Indicadores de performance
- Relatorios gerenciais
- Analises estatisticas

## Arquitetura

O projeto segue os principios da **Clean Architecture** com **Domain Driven Design**, garantindo:

```
┌─────────────────┐
│   API Layer     │  ← Controllers, Middlewares, Auth
└─────┬───────────┘
      │
┌─────▼───────────┐
│ Application     │  ← Use Cases, Commands, Queries
│ Layer           │
└─────┬───────────┘
      │
┌─────▼───────────┐
│ Domain Layer    │  ← Entities, Value Objects, Rules
└─────────────────┘
      ▲
┌─────┴───────────┐
│ Infrastructure  │  ← EF Core, Repositories, External APIs
│ Layer           │
└─────────────────┘
```

### Camadas do Sistema

#### **Domain Layer** (Nucleo do Negocio)
- **Entidades**: `Usuario`, `Cliente`, `ProcessoJuridico`, `Documento`
- **Value Objects**: `Email`, `CPF`, `CNPJ`, `Endereco`, `Telefone`
- **Enums**: `PerfilUsuario`, `StatusProcesso`, `TipoDocumento`
- **Regras de Negocio**: Validacoes e comportamentos especificos do dominio juridico

#### **Application Layer** (Casos de Uso)
- **Commands**: Operacoes que alteram estado do sistema
- **Queries**: Consultas e recuperacao de dados
- **Handlers**: Processamento dos commands e queries
- **DTOs**: Objetos de transferencia de dados
- **Interfaces**: Contratos para infraestrutura

#### **Infrastructure Layer** (Tecnologia)
- **Entity Framework Core**: Persistencia de dados
- **Repositories**: Implementacao do padrao Repository
- **Identity**: Autenticacao e autorizacao
- **External Services**: Integracao com APIs externas
- **Configurations**: Mapeamentos e configuracoes do EF

#### **API Layer** (Interface)
- **Controllers**: Endpoints REST
- **Middlewares**: Cross-cutting concerns
- **Filters**: Validacoes e tratamento de erros
- **Authentication**: Configuracao JWT
- **Swagger**: Documentacao da API

## Tecnologias Utilizadas

### **Backend**
- **.NET 8.0** - Framework principal
- **C# 12** - Linguagem de programacao
- **ASP.NET Core Web API** - Framework web
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server** - Banco de dados principal

### **Autenticacao & Seguranca**
- **JWT (JSON Web Tokens)** - Autenticacao stateless
- **Refresh Tokens** - Renovacao segura de tokens
- **BCrypt** - Hash de senhas
- **HTTPS** - Comunicacao criptografada

### **Documentacao & Testes**
- **Swagger/OpenAPI** - Documentacao interativa da API
- **xUnit** - Framework de testes unitarios
- **Moq** - Biblioteca de mocking
- **FluentAssertions** - Assertions mais legiveis

### **Logs & Monitoramento**
- **Serilog** - Logging estruturado
- **Application Insights** - Monitoramento (futuro)

### **Frontend** (Planejado)
- **Angular 17+** - Framework SPA
- **TypeScript** - Linguagem tipada
- **Angular Material** - Componentes UI

## Como Executar

### **Pre-requisitos**
- **.NET 8.0 SDK** ou superior
- **SQL Server** (LocalDB, Express ou completo)
- **Git** para controle de versao
- **IDE**: Visual Studio 2022 ou VS Code

### **Clonando o Repositorio**
```bash
git clone https://github.com/Willians167/LegalManager.Pro.git
cd LegalManager-pro
```

### **Restaurando Dependencias**
```bash
dotnet restore
```

### **Configuracao do Banco de Dados**
1. Configure a connection string no `appsettings.json`
2. Execute as migrations:
```bash
dotnet ef database update --project LegalManager.Pro.Infrastructure --startup-project LegalManager.Pro.API
```

### **Executando a Aplicacao**
```bash
dotnet run --project LegalManager.Pro.API
```

A API estara disponivel em: `https://localhost:7001`

### **Acessando a Documentacao**
Swagger UI: `https://localhost:7001/swagger`

## Estrutura do Projeto

```
LegalManager.Pro/
├── LegalManager.Pro.Domain/          # Camada de Dominio
│   ├── Entities/                     # Entidades de negocio
│   │   └── Usuario.cs                # Entidade usuario ✓
│   ├── ValueObjects/                 # Objetos de valor
│   │   └── Email.cs                  # Value object para email ✓
│   ├── Enums/                        # Enumeracoes
│   │   └── PerfilUsuario.cs          # Perfis de usuario ✓
│   └── Interfaces/                   # Interfaces do dominio
├── LegalManager.Pro.Application/     # Camada de Aplicacao
│   ├── Commands/                     # Comandos (CQRS)
│   ├── Queries/                      # Consultas (CQRS)
│   ├── Handlers/                     # Manipuladores
│   ├── DTOs/                         # Data Transfer Objects
│   └── Interfaces/                   # Contratos da aplicacao
├── LegalManager.Pro.Infrastructure/  # Camada de Infraestrutura
│   ├── Data/                         # Contexto do EF Core
│   ├── Repositories/                 # Implementacao dos repositorios
│   ├── Configurations/               # Configuracoes do EF
│   ├── Migrations/                   # Migracoes do banco
│   └── Services/                     # Servicos de infraestrutura
├── LegalManager.Pro.API/             # Camada de Apresentacao
│   ├── Controllers/                  # Controllers da API
│   ├── Middlewares/                  # Middlewares customizados
│   ├── Filters/                      # Filtros da API
│   └── Program.cs                    # Ponto de entrada ✓
└── LegalManager.Pro.Tests/           # Testes
    ├── Domain/                       # Testes da camada de dominio
    ├── Application/                  # Testes da camada de aplicacao
    ├── Infrastructure/               # Testes da infraestrutura
    └── API/                          # Testes da API
```

## Executando Testes

### **Todos os Testes**
```bash
dotnet test
```

### **Testes com Coverage**
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### **Testes de uma Camada Especifica**
```bash
dotnet test LegalManager.Pro.Tests/
```

## Exemplos de Uso da API

### **Autenticacao**
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "admin@legalmanager.com",
  "senha": "SenhaSegura123!"
}
```

### **Criando um Usuario**
```http
POST /api/usuarios
Authorization: Bearer {token}
Content-Type: application/json

{
  "nome": "Joao Silva",
  "email": "joao.silva@legalmanager.com",
  "senha": "SenhaSegura123!",
  "perfil": 2
}
```

### **Consultando Usuarios**
```http
GET /api/usuarios?perfil=Advogado&ativo=true
Authorization: Bearer {token}
```

## Domain Layer - Conceitos Implementados

### **Entidade Usuario**
```csharp
public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public PerfilUsuario Perfil { get; private set; }
    public bool Ativo { get; private set; }
    
    // Metodos de negocio
    public void AlterarEmail(Email novoEmail) { }
    public void RegistrarLogin() { }
    public void Desativar() { }
}
```

### **Value Object Email**
```csharp
public sealed class Email : IEquatable<Email>
{
    public string Valor { get; private set; }
    
    public static Email Criar(string email)
    {
        // Validacoes de formato e obrigatoriedade
        // Normalizacao (trim, lowercase)
        return new Email(email);
    }
}
```

### **Enum PerfilUsuario**
```csharp
public enum PerfilUsuario
{
    Admin = 1,
    Advogado = 2,
    Assistente = 3
}
```

## Principios Aplicados

### **SOLID**
- **Single Responsibility**: Cada classe tem uma responsabilidade especifica
- **Open/Closed**: Abertas para extensao, fechadas para modificacao
- **Liskov Substitution**: Subtipos substituem tipos base
- **Interface Segregation**: Interfaces especificas e coesas
- **Dependency Inversion**: Dependencia de abstracoes, nao implementacoes

### **DDD (Domain Driven Design)**
- **Ubiquitous Language**: Linguagem comum entre negocio e desenvolvimento
- **Bounded Contexts**: Contextos bem definidos
- **Entities**: Objetos com identidade e ciclo de vida
- **Value Objects**: Objetos imutaveis definidos por seus valores
- **Domain Services**: Logica de negocio que nao pertence a entidades

### **Clean Architecture**
- **Independence of Frameworks**: Nao dependente de frameworks especificos
- **Testable**: Regras de negocio podem ser testadas sem UI, banco, etc.
- **Independence of UI**: UI pode mudar sem afetar o sistema
- **Independence of Database**: Banco pode ser trocado sem impacto
- **Independence of External Agencies**: Regras de negocio nao sabem sobre o mundo externo

## Contribuindo

### **Como Contribuir**
1. Faca um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudancas (`git commit -m 'feat: Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

### **Padroes de Commit**
```
feat: nova funcionalidade
fix: correcao de bug
docs: documentacao
style: formatacao, ponto e virgula ausente, etc
refactor: refatoracao de codigo
test: adicao ou correcao de testes
chore: tarefas de build, configuracao, etc
```

### **Code Review**
- Seguir principios SOLID
- Manter cobertura de testes > 80%
- Documentar APIs publicas
- Seguir padroes do projeto

## Roadmap

### **Fase 1 - Fundacao** ✅
- [x] Estrutura do projeto com Clean Architecture
- [x] Domain Layer com entidades basicas (Usuario)
- [x] Value Objects (Email) com validacoes
- [x] Enums de dominio (PerfilUsuario)
- [x] Configuracao inicial da API com Swagger

### **Fase 2 - Core Business** 🚧
- [ ] Application Layer completa (CQRS)
- [ ] Infrastructure Layer com EF Core
- [ ] Sistema de autenticacao JWT
- [ ] CRUD completo de usuarios

### **Fase 3 - Dominio Expandido** 📋
- [ ] Entidade Cliente com Value Objects (CPF, CNPJ)
- [ ] Entidade ProcessoJuridico
- [ ] Entidade Documento
- [ ] Value Object Endereco

### **Fase 4 - Funcionalidades Avancadas** 🔧
- [ ] Gestao de processos juridicos
- [ ] Sistema de documentos
- [ ] Controle de prazos e agenda
- [ ] Notificacoes automaticas

### **Fase 5 - Interface e Experiencia** 🎨
- [ ] Frontend Angular
- [ ] Dashboard interativo
- [ ] Relatorios e analises
- [ ] Mobile app (PWA)

### **Fase 6 - Producao** 🚀
- [ ] Deploy automatizado
- [ ] Monitoramento e logs
- [ ] Backup automatizado
- [ ] Documentacao completa

## Aprendizados Tecnicos

Este projeto demonstra:

### **Clean Architecture**
- Separacao clara de responsabilidades
- Dependencias apontando para o centro
- Testabilidade e manutenibilidade

### **Domain Driven Design**
- Modelagem rica do dominio
- Value Objects com validacoes
- Linguagem ubiqua

### **Boas Praticas C#**
- Encapsulamento com `private set`
- Factory methods para criacao segura
- Implementacao adequada de `IEquatable`
- Operators overloading
- Implicit conversions

### **Arquitetura Empresarial**
- Estrutura de projetos profissional
- Configuracao adequada do .NET 8
- Padroes de nomenclatura
- Organizacao de pastas

## Contato

**Desenvolvedor:** Willians Silva  
**Email:** willians.dev@email.com  
**LinkedIn:** [willians-silva](https://linkedin.com/in/willians-silva)  
**GitHub:** [@Willians167](https://github.com/Willians167)

## Licenca

Este projeto esta licenciado sob a [MIT License](LICENSE).

---

⭐ **Se este projeto te ajudou, considere dar uma estrela!**

[![Feito com ❤️ e ☕](https://img.shields.io/badge/Made%20with-❤️%20and%20☕-red.svg)](https://github.com/Willians167/LegalManager.Pro)

---

> **"O melhor codigo e aquele que conta uma historia clara do negocio!"**
