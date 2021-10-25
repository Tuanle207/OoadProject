using SE214L22.Contract.Entities;

namespace SE214L22.Contract.Util
{
    public interface ISession
    {
        User CurrentUser { get; }
        bool IsMasterAdmin { get; }

        bool ComparePassword(string candidatePassword, string userPassword);
        string GetNewPassword();
        string HashPassword(string password);
        bool IsLoggedIn();
        void SetIsMasterAdmin(bool value);
        void SetSessionUser(User user);
    }
}
