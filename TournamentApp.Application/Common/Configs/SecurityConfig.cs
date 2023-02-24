namespace TournamentApp.Application.Common.Configs;
public class SecurityConfig
{
    public int RefreshTokenTTL { get; set; }

    public string Secret { get; set; }
}
