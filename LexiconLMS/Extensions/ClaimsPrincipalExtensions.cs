using System.Security.Claims;

namespace LexiconLMS.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.Claims?.FirstOrDefault(claim => claim.Type.Equals("nameidentifier")).Value;
            return int.Parse(userId);
        }

        public static string GetFullName(this ClaimsPrincipal user)
        {
            if (user != null)
            {
                var firstName = user.Claims?.FirstOrDefault(claim => claim.Type.Equals("given_name")).Value;
                var lastName = user.Claims?.FirstOrDefault(claim => claim.Type.Equals("family_name")).Value;

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    return $"{firstName} {lastName}";
                }
            }

            return string.Empty;
        }
    }
}
