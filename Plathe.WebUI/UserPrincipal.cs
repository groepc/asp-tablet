using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Plathe.WebUI
{
    public class UserPrincipal : ClaimsPrincipal
    {
        public UserPrincipal(ClaimsPrincipal principal) : base(principal)
            {

            }

            public string Name
            {
                get
                {
                    return FindFirst(ClaimTypes.Name).Value;
                }
            }
        }
    }