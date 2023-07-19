using static Users.Protos.Token;
using Users.Model.ViewModels;
using Users.Model;
using Microsoft.AspNetCore.Mvc;

namespace Users.Services
{
    public class CreateToken: ICreateToken
    {
        private readonly TokenClient _tokenClient;
        public CreateToken(TokenClient tokenClient)
        {
            this._tokenClient = tokenClient;
        }
        public async Task<TokenViewModel> Token(string userid)
        {
            var TokenResult = await _tokenClient.CreateTokenAsync(
                 new Protos.TokenRequest {Userid = userid });
                

            var token = new TokenViewModel
            {
                Token = TokenResult.Token
            };


            return token;

        }

    }
}
