﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth.OAuth.ChannelElements;
using DotNetOpenAuth.OAuth.Messages;

namespace ExtApi.Engine
{
    public class InMemoryTokenManager : IConsumerTokenManager
    {
        private Dictionary<string, string> tokensAndSecrets = new Dictionary<string, string>();

        public string ConsumerKey { get; set; }

        public string ConsumerSecret { get; set; }

        public void AddKeyAndSecret(string token, string secret)
        {
            if (!tokensAndSecrets.ContainsKey(token))
                tokensAndSecrets.Add(token, secret);
        }

        #region ITokenManager Members

        public string GetConsumerSecret(string consumerKey)
        {
            if (consumerKey == this.ConsumerKey)
            {
                return this.ConsumerSecret;
            }
            else
            {
                throw new ArgumentException("Unrecognized consumer key.", "consumerKey");
            }
        }

        public string GetTokenSecret(string token)
        {
            return this.tokensAndSecrets[token];
        }

        public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
        {
            this.tokensAndSecrets[response.Token] = response.TokenSecret;
        }

        public void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
        {
            this.tokensAndSecrets.Remove(requestToken);
            this.tokensAndSecrets[accessToken] = accessTokenSecret;
        }

        /// <summary>
        /// Classifies a token as a request token or an access token.
        /// </summary>
        /// <param name="token">The token to classify.</param>
        /// <returns>Request or Access token, or invalid if the token is not recognized.</returns>
        public TokenType GetTokenType(string token)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
