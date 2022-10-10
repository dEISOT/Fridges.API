using AutoMapper;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Request;
using FridgesModel.Response;

namespace FridgesCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenService _tokenService;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, ITokenService tokenService, ITokenRepository tokenRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _tokenService = tokenService;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public async Task<LoginResponse> AuthenticateAsync(LoginRequest request)
        {
            var model = await _accountRepository.FindByEmailAsync(request.Email);
            if (model == null)
            {
                throw new Exception("Invalid Email or password");
            }
            var check = BCrypt.Net.BCrypt.Verify(request.Password, model.PasswordHash);

            if (!check)
            {
                throw new Exception("Invalid Email or password");
            }

            var result = await _tokenService.GenerateTokensAsync(model);
            return result;
        }

        public async Task LogoutAsync(string refreshToken)
        {
            var entity = await _tokenRepository.TryGetTokenAsync(refreshToken);
            await _tokenRepository.DeleteAsync(entity);  
        }

        public async Task<Guid> RegisterAsync(RegisterRequest request)
        {
            var model = await _accountRepository.FindByEmailAsync(request.Email);
            if (model != null)
            {
                throw new Exception("Account with this Email is already exist");
            }

            var account = _mapper.Map<AccountEntity>(request);
            account.Role = "User";
            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var result = await _accountRepository.AddAsync(account);

            return result;
        }
    }
}

