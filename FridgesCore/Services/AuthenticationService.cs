using FridgesCore.Interfaces;
using FridgesModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesCore.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthenticationResponse> AuthenticateAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshTokenResponse> RefreshTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
