﻿
using System.Net;
using System.Net.Http.Headers;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());
            var response = await base.SendAsync(request, cancellationToken);

            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // 
            }

            return response;
        }
    }
}
