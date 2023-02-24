using AutoMapper;
using System.Text.Json.Serialization;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Auth.Models;
public class AuthenticateResponse : IMapFrom<User>
{
    public int Id { get; set; }

    public string Email { get; set; }

    public bool IsVerified { get; set; }

    public string JwtToken { get; set; }

    [JsonIgnore]
    public string RefreshToken { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, AuthenticateResponse>()
            .ForMember(d => d.JwtToken, opt => opt.Ignore())
            .ForMember(d => d.RefreshToken, opt => opt.Ignore());
    }
}
