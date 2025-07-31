// ****************************************************************************
// Author(s) for this code file:
//       -John Phillips | john.phillips@thoughtspot.com
// ****************************************************************************

using System.Text.Json.Serialization;

namespace GetAccessToken
{
    public sealed class TokenScope
    {
        [JsonPropertyName("access_type")]
        public string AccessType { get; init; } = string.Empty;

        [JsonPropertyName("org_id")]
        public int OrgId { get; init; }

        [JsonPropertyName("metadata_id")]
        public string MetadataId { get; init; } = string.Empty;


        public override string ToString()
        {
            return $"{nameof(AccessType)}: '{AccessType}', " +
                   $"{nameof(OrgId)}: '{OrgId}', " +
                   $"{nameof(MetadataId)}: '{MetadataId}'";
        }
    }
}