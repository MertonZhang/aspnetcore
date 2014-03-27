﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Abstractions.Security;
using Microsoft.AspNet.HttpFeature.Security;

namespace Microsoft.AspNet.PipelineCore.Security
{
    public class AuthenticateContext : IAuthenticateContext
    {
        public AuthenticateContext(IList<string> authenticationTypes)
        {
            if (authenticationTypes == null)
            {
                throw new ArgumentNullException("authenticationType");
            }
            AuthenticationTypes = authenticationTypes;
            Results = new List<AuthenticationResult>();
        }

        public IList<string> AuthenticationTypes { get; private set; }

        public IList<AuthenticationResult> Results { get; private set; }

        public void Authenticated(ClaimsIdentity identity, IDictionary<string, string> properties, IDictionary<string, object> description)
        {
            Results.Add(new AuthenticationResult(identity, new AuthenticationProperties(properties), new AuthenticationDescription(description)));
        }

        public void NotAuthenticated(string authenticationType, IDictionary<string, string> properties, IDictionary<string, object> description)
        {
        }
    }
}
