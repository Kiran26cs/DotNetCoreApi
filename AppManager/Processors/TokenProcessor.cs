using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AppManager.AppInterfaces;
using Microsoft.IdentityModel.Tokens;

namespace AppManager.Processors
{
    public class TokenProcessor : ITokenProcessor
    {
        public string createNewWebToken()
        {
            //the secret Key
            string secretKey = "Hello_secret_key";
            //Create symetric key 
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            //sign the token
            var signingCredentails = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            //Create the token

            var token = new JwtSecurityToken(issuer: "KiransComputer", audience: "someReceiver", expires: DateTime.Now.AddMinutes(1), signingCredentials: signingCredentails);


            //write the token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void ValidateWebToken()
        {
            throw new NotImplementedException();
        }
    }
}
