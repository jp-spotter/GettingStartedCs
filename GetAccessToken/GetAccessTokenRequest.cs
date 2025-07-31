// ****************************************************************************
// Author(s) for this code file:
//       -John Phillips | john.phillips@thoughtspot.com
// ****************************************************************************


using System.Text.Json.Serialization;

namespace GetAccessToken
{
    public class GetAccessTokenRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; init; } = string.Empty;

        [JsonPropertyName("secret_key")]
        public string SecretKey { get; set; } = string.Empty;

        [JsonPropertyName("validity_time_in_sec")]
        public int ValidityTimeInSec { get; init; } = 300;


        public override string ToString()
        {
            return $"{nameof(Username)}: {Username}, " +
                   $"{nameof(ValidityTimeInSec)}: {ValidityTimeInSec}, " +
                   $"{nameof(SecretKey)}: {SecretKey}";
        }
    }
}