using Microsoft.IdentityModel.Tokens;
using NoticiasWebApi.Models;
using System;

namespace NoticiasWebApi
{
    public interface ITokenProvider
    {
        string CreateToken(Usuario usuario, DateTime expirationDate);
        TokenValidationParameters GetValidationParameters();
    }
}