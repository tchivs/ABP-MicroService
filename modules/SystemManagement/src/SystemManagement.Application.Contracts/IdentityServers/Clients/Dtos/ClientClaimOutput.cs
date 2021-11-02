﻿using System;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.Clients
{
    public class ClientClaimOutput
    {
        public Guid ClientId { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}