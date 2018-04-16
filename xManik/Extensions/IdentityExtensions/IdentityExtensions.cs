﻿using System;
using System.Security.Claims;
using xManik.Models;

namespace xManik.Extensions.IdentityExtensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            ClaimsPrincipal currentUser = user;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static string GetUserName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            return user.Identity.Name;
        }

        public static string GetUserRole(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            string role = "";

            if (user.IsInRole(Enum.GetName(typeof(Roles), Roles.Blogger)))
            {
                role = "Bolgger";
            }
            if (user.IsInRole(Enum.GetName(typeof(Roles), Roles.Client)))
            {
                role = "Client";
            }
            return role;
        }
    }
}
