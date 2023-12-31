﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {           //appsettingsi okumamızı sağlıyor
        public IConfiguration Configuration { get; }
        //IConfiguration ile okunan değerlerin atanması yapılır
        private TokenOptions _tokenOptions;
        //Token ne zaman biticek
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //              appsettings.section("TokenOptions").Get<TokenOptions>göre maple
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Token ne zaman biticek = şuandan itibaren dakika ekle(_tokenOptions.AccessTokenExpiration )
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            // anahtar değeri =                  Security formatında( Token Optiondan al)
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            // Hangi anahtarı kullanıcak ve algoritma =
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //json web token değeri =         (token option, user, signingCredentials,   operationClaims                  
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
              //system.identityModel.Tokens.JWT Token oluşturma
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            //microsoft.identityModel.Tokens
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                //
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                //Şuandan önceki bir değer verilemez
                //notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {                       //system.security.claims
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
