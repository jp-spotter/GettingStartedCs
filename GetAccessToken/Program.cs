// ****************************************************************************
// Author(s) for this code file:
//       -John Phillips | john.phillips@thoughtspot.com
// ****************************************************************************

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace GetAccessToken
{
    internal class Program
    {
        public const string V2ApiRelativeUrl = "api/rest/2.0/";
        public const string TokenFullUrl     = "auth/token/full";

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        public static async Task Main()
        {
            try
            {
                // Get the configuration settings and build the HTTP request
                var tsRestApiCfg = GetRestApiCfgFromAppSettings();
                var httpRequestMessage = BuildHttpRequest(tsRestApiCfg);
                var httpClient = GetConfiguredHttpClient(tsRestApiCfg);

                // Send the HTTP request and get the response
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                // Throws an exception if the HTTP response is not successful
                httpResponseMessage.EnsureSuccessStatusCode();

                // Reads the response content (JSON returned from the ThoughtSpot API)
                var responseStringContent = await httpResponseMessage.Content.ReadAsStringAsync();

                // This is the response object with properties for use in within your application.
                var getAccessTokenResponseObj = JsonSerializer.Deserialize<GetAccessTokenResponse>(responseStringContent);

                // Optional -- get the prettified JSON output to write to the console for this sample.
                var prettyJson = GetPrettifiedJsonOutput(getAccessTokenResponseObj);

                Console.WriteLine(prettyJson);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


        /// <summary>
        ///     Serializes the GetAccessTokenResponse object to a prettified JSON string.
        /// </summary>
        /// <param name="getAccessTokenResponse">The <see cref="GetAccessTokenResponse"/> object to serialize.</param>
        /// <returns>A JSON string with indentation.</returns>
        private static string GetPrettifiedJsonOutput(GetAccessTokenResponse? getAccessTokenResponse) =>
            JsonSerializer.Serialize(getAccessTokenResponse, new JsonSerializerOptions { WriteIndented = true });


        /// <summary>
        ///     Retrieves the REST API configuration from the appsettings.json file.
        /// </summary>
        /// <returns>A <see cref="TsRestApiCfg" /> object populated with configuration settings.</returns>
        private static TsRestApiCfg GetRestApiCfgFromAppSettings()
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile(
                             "appsettings.json")
                        .Build();

            var tsRestApiCfg = new TsRestApiCfg();

            config.Bind(
                "TsRestApiCfg",
                tsRestApiCfg);

            return tsRestApiCfg;
        }


        /// <summary>
        ///     Builds the HTTP request message for obtaining an access token.
        /// </summary>
        /// <param name="tsRestApiCfg">The REST API configuration.</param>
        /// <returns>An <see cref="HttpRequestMessage" /> configured for the token request.</returns>
        private static HttpRequestMessage BuildHttpRequest(TsRestApiCfg tsRestApiCfg)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post,
                new Uri(
                    TokenFullUrl,
                    UriKind.Relative));

            httpRequestMessage.Content = JsonContent.Create(
                new GetAccessTokenRequest
                {
                    Username          = tsRestApiCfg.Username,
                    SecretKey         = tsRestApiCfg.Secret,
                    ValidityTimeInSec = tsRestApiCfg.ValidityTimeInSec
                });

            httpRequestMessage.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/json");

            return httpRequestMessage;
        }


        /// <summary>
        ///     Gets a configured HTTP client for making requests to the ThoughtSpot API.
        /// </summary>
        /// <param name="tsRestApiCfg">The REST API configuration.</param>
        /// <returns>A configured <see cref="HttpClient" /> instance.</returns>
        public static HttpClient GetConfiguredHttpClient(TsRestApiCfg tsRestApiCfg)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(
                tsRestApiCfg.TsClusterBaseUrl,
                V2ApiRelativeUrl);

            httpClient.DefaultRequestHeaders.Add(
                "User-Agent",
                tsRestApiCfg.TsUserAgent);

            return httpClient;
        }
    }
}