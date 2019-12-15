﻿using Cloudflare.Abstractions.Builders;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Builders;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare
{
    public static class Cloudflare
    {
        private const string DefaultEndpointUrl = "https://api.cloudflare.com/client/v4/";
        public static Uri EndpointUrl { get; set; } = new Uri(DefaultEndpointUrl);

        public static ITokenAuthorizedSyntax WithToken(string token)
        {
            return new TokenAuthorizedBuilder(new EndpointFactory(), token);
        }

        public static IAuthorizedSyntax WithKey(string apiKey, string email)
        {
            return new AuthorizedBuilder(new EndpointFactory(), apiKey, email);
        }

        private class EndpointFactory : IRequestBuilderFactory
        {
            public IRequestBuilder CreateRequestBuilder()
            {
                var builder = new RequestBuilder
                {
                    BaseUrl = EndpointUrl
                };
                return builder;
            }
        }
    }
}