// ****************************************************************************
// Author(s) for this code file:
//       -John Phillips | john.phillips@thoughtspot.com
// ****************************************************************************

using System.Text.Json.Serialization;

namespace GetAccessToken
{
    public sealed class GetAccessTokenResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; init; } = string.Empty;

        [JsonPropertyName("creation_time_in_millis")]
        public long CreationTimeInMillis { get; init; }

        [JsonPropertyName("expiration_time_in_millis")]
        public long ExpirationTimeInMillis { get; init; }

        [JsonPropertyName("scope")]
        public TokenScope Scope { get; init; } = new();

        [JsonPropertyName("valid_for_user_id")]
        public string ValidForUserId { get; init; } = string.Empty;

        [JsonPropertyName("valid_for_username")]
        public string ValidForUsername { get; init; } = string.Empty;


        public override string ToString()
        {
            return $"{nameof(ValidForUsername)}: '{ValidForUsername}', " +
                   $"{nameof(ValidForUserId)}: '{ValidForUserId}', " +
                   $"{nameof(Scope)}: '{Scope}'";
        }
    }
}