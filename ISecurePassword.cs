using System;
using System.Security;

namespace Services
{
    public interface ISecurePassword
    {
        SecureString SecurePassword { get; }
    }
}
