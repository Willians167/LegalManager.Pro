# ??? LegalManager.Pro

> **Sistema de Gestão Jurídica** - Uma solução completa para escritórios de advocacia

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![C#](https://img.shields.io/badge/C%23-12.0-green.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com/Willians167/LegalManager.Pro)

## ?? Sobre o Projeto

O **LegalManager.Pro** é um sistema de gestão jurídica (LegalTech) desenvolvido com foco em escritórios de advocacia modernos. Construído seguindo os princípios da **Clean Architecture** e **Domain Driven Design (DDD)**, oferece uma solução robusta, escalável e de fácil manutenção.

### ?? Objetivos

- Modernizar a gestão de escritórios de advocacia
- Centralizar informações de clientes, processos e documentos
- Automatizar controle de prazos e agenda
- Prover dashboards com indicadores de performance
- Garantir segurança e conformidade com LGPD

## ? Funcionalidades

### ?? **Autenticação e Autorização**
- Sistema de autenticação JWT com Refresh Token
- Controle de acesso baseado em perfis (Admin, Advogado, Assistente)
- Gestão de usuários com diferentes níveis de permissão

### ?? **Gestão de Usuários**
- Cadastro e manutenção de usuários
- Controle de perfis e permissões
- Histórico de acesso e atividades

### ?? **Gestão de Clientes**
- Cadastro completo de pessoas físicas e jurídicas
- Controle de documentos e informações de contato
- Histórico de relacionamento

### ?? **Gestão de Processos Jurídicos**
- Controle completo de processos
- Acompanhamento de andamentos
- Vinculação com clientes e responsáveis

### ?? **Controle de Prazos e Agenda**
- Sistema de alertas para prazos processuais
- Agenda integrada com processos
- Notificações automáticas

### ?? **Gerenciamento de Documentos**
- Upload e organização de documentos
- Versionamento e controle de acesso
- Integração com processos

### ?? **Dashboard e Relatórios**
- Indicadores de performance
- Relatórios gerenciais
- Análises estatísticas

## ??? Arquitetura

O projeto segue os princípios da **Clean Architecture** com **Domain Driven Design**, garantindo:

```
???????????????????
?   ?? API Layer  ?  ? Controllers, Middlewares, Auth
???????????????????
          ?
???????????????????
??? Application   ?  ? Use Cases, Commands, Queries
?     Layer       ?
???????????????????
          ?
???????????????????
??? Domain Layer  ?  ? Entities, Value Objects, Rules
???????????????????
          ?
???????????????????
??? Infrastructure?  ? EF Core, Repositories, External APIs
?     Layer       ?
???????????????????
```

### ?? Camadas do Sistema

#### ?? **Domain Layer** (Núcleo do Negócio)
- **Entidades**: `Usuario`, `Cliente`, `ProcessoJuridico`, `Documento`
- **Value Objects**: `Email`, `CPF`, `CNPJ`, `Endereco`, `Telefone`
- **Enums**: `PerfilUsuario`, `StatusProcesso`, `TipoDocumento`
- **Regras de Negócio**: Validações e comportamentos específicos do domínio jurídico

#### ?? **Application Layer** (Casos de Uso)
- **Commands**: Operações que alteram estado do sistema
- **Queries**: Consultas e recuperação de dados
- **Handlers**: Processamento dos commands e queries
- **DTOs**: Objetos de transferência de dados
- **Interfaces**: Contratos para infraestrutura

#### ?? **Infrastructure Layer** (Tecnologia)
- **Entity Framework Core**: Persistência de dados
- **Repositories**: Implementação do padrão Repository
- **Identity**: Autenticação e autorização
- **External Services**: Integração com APIs externas
- **Configurations**: Mapeamentos e configurações do EF

#### ?? **API Layer** (Interface)
- **Controllers**: Endpoints REST
- **Middlewares**: Cross-cutting concerns
- **Filters**: Validações e tratamento de erros
- **Authentication**: Configuração JWT
- **Swagger**: Documentação da API

## ??? Tecnologias Utilizadas

### **Backend**
- **.NET 8.0** - Framework principal
- **C# 12** - Linguagem de programação
- **ASP.NET Core Web API** - Framework web
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server** - Banco de dados principal

### **Autenticação & Segurança**
- **JWT (JSON Web Tokens)** - Autenticação stateless
- **Refresh Tokens** - Renovação segura de tokens
- **BCrypt** - Hash de senhas
- **HTTPS** - Comunicação criptografada

### **Documentação & Testes**
- **Swagger/OpenAPI** - Documentação interativa da API
- **xUnit** - Framework de testes unitários
- **Moq** - Biblioteca de mocking
- **FluentAssertions** - Assertions mais legíveis

### **Logs & Monitoramento**
- **Serilog** - Logging estruturado
- **Application Insights** - Monitoramento (futuro)

### **Frontend** (Planejado)
- **Angular 17+** - Framework SPA
- **TypeScript** - Linguagem tipada
- **Angular Material** - Componentes UI

## ?? Como Executar

### **Pré-requisitos**
- **.NET 8.0 SDK** ou superior
- **SQL Server** (LocalDB, Express ou completo)
- **Git** para controle de versão
- **IDE**: Visual Studio 2022 ou VS Code

### **Clonando o Repositório**
```bash
git clone https://github.com/Willians167/LegalManager.Pro.git
cd LegalManager-pro
```

### **Restaurando Dependências**
```bash
dotnet restore
```

### **Configuração do Banco de Dados**
1. Configure a connection string no `appsettings.json`
2. Execute as migrations:
```bash
dotnet ef database update --project LegalManager.Pro.Infrastructure --startup-project LegalManager.Pro.API
```

### **Executando a Aplicação**
```bash
dotnet run --project LegalManager.Pro.API
```

A API estará disponível em: `https://localhost:7001`

### **Acessando a Documentação**
Swagger UI: `https://localhost:7001/swagger`

## ?? Estrutura do Projeto

```
LegalManager.Pro/
??? ?? LegalManager.Pro.Domain/          # Camada de Domínio
?   ??? ?? Entities/                     # Entidades de negócio
?   ?   ??? Usuario.cs                   # Entidade usuário ?
?   ??? ?? ValueObjects/                 # Objetos de valor
?   ?   ??? Email.cs                     # Value object para email ?
?   ??? ?? Enums/                        # Enumerações
?   ?   ??? PerfilUsuario.cs             # Perfis de usuário ?
?   ??? ?? Interfaces/                   # Interfaces do domínio
??? ?? LegalManager.Pro.Application/     # Camada de Aplicação
?   ??? ?? Commands/                     # Comandos (CQRS)
?   ??? ?? Queries/                      # Consultas (CQRS)
?   ??? ?? Handlers/                     # Manipuladores
?   ??? ?? DTOs/                         # Data Transfer Objects
?   ??? ?? Interfaces/                   # Contratos da aplicação
??? ?? LegalManager.Pro.Infrastructure/  # Camada de Infraestrutura
?   ??? ?? Data/                         # Contexto do EF Core
?   ??? ?? Repositories/                 # Implementação dos repositórios
?   ??? ?? Configurations/               # Configurações do EF
?   ??? ?? Migrations/                   # Migrações do banco
?   ??? ?? Services/                     # Serviços de infraestrutura
??? ?? LegalManager.Pro.API/             # Camada de Apresentação
?   ??? ?? Controllers/                  # Controllers da API
?   ??? ?? Middlewares/                  # Middlewares customizados
?   ??? ?? Filters/                      # Filtros da API
?   ??? Program.cs                       # Ponto de entrada ?
??? ?? LegalManager.Pro.Tests/           # Testes
    ??? ?? Domain/                       # Testes da camada de domínio
    ??? ?? Application/                  # Testes da camada de aplicação
    ??? ?? Infrastructure/               # Testes da infraestrutura
    ??? ?? API/                          # Testes da API
```

## ?? Executando Testes

### **Todos os Testes**
```bash
dotnet test
```

### **Testes com Coverage**
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### **Testes de uma Camada Específica**
```bash
dotnet test LegalManager.Pro.Tests/
```

## ?? Exemplos de Uso da API

### **Autenticação**
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "admin@legalmanager.com",
  "senha": "SenhaSegura123!"
}
```

### **Criando um Usuário**
```http
POST /api/usuarios
Authorization: Bearer {token}
Content-Type: application/json

{
  "nome": "João Silva",
  "email": "joao.silva@legalmanager.com",
  "senha": "SenhaSegura123!",
  "perfil": 2
}
```

### **Consultando Usuários**
```http
GET /api/usuarios?perfil=Advogado&ativo=true
Authorization: Bearer {token}
```

## ?? Domain Layer - Conceitos Implementados

### **Entidade Usuario**
```csharp
public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public PerfilUsuario Perfil { get; private set; }
    public bool Ativo { get; private set; }
    
    // Métodos de negócio
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
        // Validações de formato e obrigatoriedade
        // Normalização (trim, lowercase)
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

## ?? Princípios Aplicados

### **SOLID**
- ? **S**ingle Responsibility: Cada classe tem uma responsabilidade específica
- ? **O**pen/Closed: Abertas para extensão, fechadas para modificação
- ? **L**iskov Substitution: Subtipos substituem tipos base
- ? **I**nterface Segregation: Interfaces específicas e coesas
- ? **D**ependency Inversion: Dependência de abstrações, não implementações

### **DDD (Domain Driven Design)**
- ? **Ubiquitous Language**: Linguagem comum entre negócio e desenvolvimento
- ? **Bounded Contexts**: Contextos bem definidos
- ? **Entities**: Objetos com identidade e ciclo de vida
- ? **Value Objects**: Objetos imutáveis definidos por seus valores
- ? **Domain Services**: Lógica de negócio que não pertence a entidades

### **Clean Architecture**
- ? **Independence of Frameworks**: Não dependente de frameworks específicos
- ? **Testable**: Regras de negócio podem ser testadas sem UI, banco, etc.
- ? **Independence of UI**: UI pode mudar sem afetar o sistema
- ? **Independence of Database**: Banco pode ser trocado sem impacto
- ? **Independence of External Agencies**: Regras de negócio não sabem sobre o mundo externo

## ?? Contribuindo

### **Como Contribuir**
1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'feat: Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

### **Padrões de Commit**
```
feat: nova funcionalidade
fix: correção de bug
docs: documentação
style: formatação, ponto e vírgula ausente, etc
refactor: refatoração de código
test: adição ou correção de testes
chore: tarefas de build, configuração, etc
```

### **Code Review**
- Seguir princípios SOLID
- Manter cobertura de testes > 80%
- Documentar APIs públicas
- Seguir padrões do projeto

## ?? Roadmap

### **Fase 1 - Fundação** ?
- [x] Estrutura do projeto com Clean Architecture
- [x] Domain Layer com entidades básicas (Usuario)
- [x] Value Objects (Email) com validações
- [x] Enums de domínio (PerfilUsuario)
- [x] Configuração inicial da API com Swagger

### **Fase 2 - Core Business** ??
- [ ] Application Layer completa (CQRS)
- [ ] Infrastructure Layer com EF Core
- [ ] Sistema de autenticação JWT
- [ ] CRUD completo de usuários

### **Fase 3 - Domínio Expandido** ??
- [ ] Entidade Cliente com Value Objects (CPF, CNPJ)
- [ ] Entidade ProcessoJuridico
- [ ] Entidade Documento
- [ ] Value Object Endereco

### **Fase 4 - Funcionalidades Avançadas** ??
- [ ] Gestão de processos jurídicos
- [ ] Sistema de documentos
- [ ] Controle de prazos e agenda
- [ ] Notificações automáticas

### **Fase 5 - Interface e Experiência** ??
- [ ] Frontend Angular
- [ ] Dashboard interativo
- [ ] Relatórios e análises
- [ ] Mobile app (PWA)

### **Fase 6 - Produção** ??
- [ ] Deploy automatizado
- [ ] Monitoramento e logs
- [ ] Backup automatizado
- [ ] Documentação completa

## ?? Aprendizados Técnicos

Este projeto demonstra:

### **Clean Architecture**
- Separação clara de responsabilidades
- Dependências apontando para o centro
- Testabilidade e manutenibilidade

### **Domain Driven Design**
- Modelagem rica do domínio
- Value Objects com validações
- Linguagem ubíqua

### **Boas Práticas C#**
- Encapsulamento com `private set`
- Factory methods para criação segura
- Implementação adequada de `IEquatable`
- Operators overloading
- Implicit conversions

### **Arquitetura Empresarial**
- Estrutura de projetos profissional
- Configuração adequada do .NET 8
- Padrões de nomenclatura
- Organização de pastas

## ?? Contato

**Desenvolvedor:** Willians Silva  
**Email:** willians.dev@email.com  
**LinkedIn:** [willians-silva](https://linkedin.com/in/willians-silva)  
**GitHub:** [@Willians167](https://github.com/Willians167)

## ?? Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

? **Se este projeto te ajudou, considere dar uma estrela!**

[![Feito com ?? e ?](https://img.shields.io/badge/Made%20with-??%20and%20?-red.svg)](https://github.com/Willians167/LegalManager.Pro)

---

> **"O melhor código é aquele que conta uma história clara do negócio!"**