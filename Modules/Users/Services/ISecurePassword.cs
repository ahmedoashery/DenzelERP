using System;
using System.Security;

namespace Modules.Users.Services
{
    public interface ISecurePassword
    {
        SecureString SecurePassword { get; }
    }
}
