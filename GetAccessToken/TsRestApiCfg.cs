// ****************************************************************************
// Author(s) for this code file:
//       -John Phillips | john.phillips@thoughtspot.com
// ****************************************************************************


namespace GetAccessToken
{
    public class TsRestApiCfg
    {
        /// <summary>
        ///     Gets or sets TS cluster URL for base URL for an Http Client.
        /// </summary>
        /// <value>The base URL.</value>
        public Uri TsClusterBaseUrl { get; set; } = new("https://demo.thoughtspot.com");

        /// <summary>
        ///     Gets or sets the username for which the access token is requested.,
        /// </summary>
        /// <value>The API key.</value>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the ThoughtSpot cluster secret (API key) used to obtain an access token.
        /// </summary>
        /// <value>The API key.</value>
        public string Secret { get; set; } = string.Empty;

        /// <summary>
        ///     The value to use in the "User-Agent" HTTP header for the API client (required).
        /// </summary>
        /// <value>The ts user agent.</value>
        /// <remarks>
        ///     Note, this is required for the API call to succeed. The TS cluster will return an error if the user agent
        ///     header is missing.
        /// </remarks>
        public string TsUserAgent { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the validity time of the access token for the API client. Default is 300 seconds (5 minutes).
        /// </summary>
        /// <value>The API key.</value>
        public int ValidityTimeInSec { get; set; } = 300;


        public override string ToString()
        {
            return $"{nameof(TsClusterBaseUrl)}: {TsClusterBaseUrl}, " +
                   $"{nameof(Username)}: {Username}, " +
                   $"{nameof(TsUserAgent)}: {TsUserAgent}, " +
                   $"{nameof(Secret)}: ********, " +
                   $"{nameof(ValidityTimeInSec)}: {ValidityTimeInSec}";
        }
    }
}