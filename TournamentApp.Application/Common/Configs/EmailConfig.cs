namespace TournamentApp.Application.Common.Configs;
public class EmailConfig
{
    public string EmailFrom { get; set; }

    public string SmtpHost { get; set; }

    public int SmtpPort { get; set; }

    public string SmtpUser { get; set; }

    public string SmtpPass { get; set; }
}
