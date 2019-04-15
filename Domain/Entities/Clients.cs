

using System.Collections.Generic;
using IdentityServer4.Models;

namespace identityserver4POC.Domain.Entities {
    public class Clients {
        public static IEnumerable<Client> Get() {
                return new List<Client> {
                    new Client {
                        ClientId = "oauthClient",
                        ClientName = "Haoni Arruda Hashimoto",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = new List<Secret> { new Secret("myPassword@2019".Sha256())},                         
                        AllowedScopes = new List<string> {"customAPI.read"}
                    }
                };
            }
    }
}