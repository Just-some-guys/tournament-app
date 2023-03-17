using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities
{
    public class OrganizationMember: Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public OrganizationRole OrganizationRole { get; set; } // Вот это поле под вопросом 
    }
}
