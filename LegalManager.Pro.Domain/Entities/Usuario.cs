using System;
using LegalManager.Pro.Domain.ValueObjects;
using LegalManager.Pro.Domain.Enums;

namespace LegalManager.Pro.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public PerfilUsuario Perfil { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataUltimoLogin { get; private set; }

        // Construtor privado para EF
        private Usuario() { }

        // Construtor de negócio
        public Usuario(string nome, Email email, string passwordHash, PerfilUsuario perfil)
        {
            // Validações de negócio
            ValidarNome(nome);
            ValidarPasswordHash(passwordHash);

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = passwordHash;
            Perfil = perfil;
            Ativo = true;
            DataCriacao = DateTime.UtcNow;
        }

        // Métodos de negócio
        public void AlterarEmail(Email novoEmail)
        {
            if (novoEmail == null)
                throw new ArgumentNullException(nameof(novoEmail));

            Email = novoEmail;
        }

        public void RegistrarLogin()
        {
            DataUltimoLogin = DateTime.UtcNow;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Reativar()
        {
            Ativo = true;
        }

        // Validações privadas
        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório", nameof(nome));

            if (nome.Length < 2)
                throw new ArgumentException("Nome deve ter pelo menos 2 caracteres", nameof(nome));

            if (nome.Length > 100)
                throw new ArgumentException("Nome deve ter no máximo 100 caracteres", nameof(nome));
        }

        private static void ValidarPasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Hash da senha é obrigatório", nameof(passwordHash));
        }
    }
}
