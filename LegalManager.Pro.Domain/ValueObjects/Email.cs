using System.Text.RegularExpressions;

namespace LegalManager.Pro.Domain.ValueObjects;

public sealed class Email : IEquatable<Email>
{
    public string Valor { get; private set; }

    private Email(string valor)
    {
        Valor = valor;
    }

    public static Email Criar(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email é obrigatório", nameof(email));

        email = email.Trim().ToLowerInvariant();

        if (!EhEmailValido(email))
            throw new ArgumentException("Formato de email inválido", nameof(email));

        return new Email(email);
    }

    private static bool EhEmailValido(string email)
    {
        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        return regex.IsMatch(email);
    }

    // Implementação de igualdade para Value Object
    public bool Equals(Email? other)
    {
        if (other is null) return false;
        return Valor == other.Valor;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Email);
    }

    public override int GetHashCode()
    {
        return Valor.GetHashCode();
    }

    public override string ToString()
    {
        return Valor;
    }

    // Operadores de igualdade
    public static bool operator ==(Email? left, Email? right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Email? left, Email? right)
    {
        return !(left == right);
    }

    // Conversão implícita para string
    public static implicit operator string(Email email)
    {
        return email?.Valor ?? string.Empty;
    }
}