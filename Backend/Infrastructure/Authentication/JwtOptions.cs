namespace Backend.Infrastructure.Authentication
{
    public record class JwtOptions(
        string Issuer,
        string Audience,
        string SigningKey,
        int ExpirationSeconds
    );
}
