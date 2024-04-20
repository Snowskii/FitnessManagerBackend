using System.Security.Claims;

namespace Backend.Infrastructure
{
    static class Utils
    {
        public static int? getUserId(ClaimsIdentity? identity) => identity == null ? null : Convert.ToInt32(identity.FindFirst("id").Value);
    }
}
