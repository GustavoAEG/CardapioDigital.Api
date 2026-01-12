using Microsoft.AspNetCore.Authorization;

namespace CardapioDigital.Api.Authorization
{
    public static class Policies
    {
        public const string RequireAdmin = "RequireAdmin";
        public const string RequireWaiter = "RequireWaiter";
        public const string RequireKitchen = "RequireKitchen";
        public const string RequireRestaurantAdmin = "RequireRestaurantAdmin";

        public static void AddPolicies(AuthorizationOptions options)
        {
            options.AddPolicy(RequireAdmin, policy =>
                policy.RequireRole(Roles.Admin));

            options.AddPolicy(RequireWaiter, policy =>
                policy.RequireRole(Roles.Waiter));

            options.AddPolicy(RequireKitchen, policy =>
                policy.RequireRole(Roles.Kitchen));

            options.AddPolicy(RequireRestaurantAdmin, policy =>
            {
                policy.RequireRole(Roles.Admin);
                policy.RequireClaim("rid"); // restaurante no token
            });
        }
    }
}
