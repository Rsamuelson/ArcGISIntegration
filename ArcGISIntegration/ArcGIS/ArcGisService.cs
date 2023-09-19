using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace ArcGIS;

/// <summary>
///     Integration service for ArcGIS.
///     See: https://developers.arcgis.com/
/// </summary>
public sealed class ArcGisService
{
    private readonly HttpClient _arcGisHttpClient;

    public ArcGisService(string referrer)
    {
        _arcGisHttpClient = new HttpClient();

        _arcGisHttpClient.DefaultRequestHeaders.Add(HeaderNames.Referer, referrer);
    }

    /// <summary>
    ///     Calls the following API endpoint and returns the top scoring candidate.
    ///     https://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer/findAddressCandidates?{address}&f=json&token={token}
    ///     See: https://developers.arcgis.com/documentation/mapping-apis-and-services/geocoding/geocode-addresses/
    /// </summary>
    public async Task<string> GetAddressLocationCoordinatesAsync(string address, string token, CancellationToken cancellationToken = default)
    {
        var queryUri = "https://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer/findAddressCandidates";

        var queryStringKeyValuePairs = new Dictionary<string, string>()
        {
            { "f", "json" },
            { "token", token },
            { "address", address }
        };
        queryUri = QueryHelpers.AddQueryString(queryUri, queryStringKeyValuePairs);

        var httpResponseMessage = await _arcGisHttpClient.GetAsync(queryUri, cancellationToken);

        var contentString = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);

        return contentString;

        //In our actual code we Deserialize the contextString with json and return top scoring the result, but for testing we don't need to do that.
    }
}