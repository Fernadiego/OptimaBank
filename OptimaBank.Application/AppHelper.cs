using OptimaBank.Services;

namespace OptimaBank.ApplicationLogic
{
    public static class AppHelper
    {
        public static UserProfile GetEnumUserProfileByString(string perfil)
        {
            return (UserProfile)Enum.Parse(typeof(UserProfile), perfil);
        }
    }
}
