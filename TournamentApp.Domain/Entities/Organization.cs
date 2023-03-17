﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities
{
    public class Organization: Entity
    {
        public string Name { get; set; }
        public List<OrganizationMember> OrganizationMembers { get; set; }
        public string Description { get; set; }
    }
}