using BlazorApp1.Shared.ReqRes;
using System.Net.Http.Json;

namespace BlazorApp1.Services;

public class ReqResService : IReqResData
{
    private readonly IHttpClientFactory? httpClientFactory = null;
    private CancellationTokenSource? cancellationTokenSource = null;
    public ReqResService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public void CancelRequest()
    {
        cancellationTokenSource?.Cancel();
    }

    public async Task<ReqResResponse?> GetResponseData()
    {
        var httpClient = httpClientFactory?.CreateClient("reqres");
        if(httpClient != null)
        {
            cancellationTokenSource = new CancellationTokenSource();
            using var response = await httpClient.GetAsync("users", 
                HttpCompletionOption.ResponseHeadersRead, cancellationTokenSource.Token);
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReqResResponse>();
            } else
            {
                return null;
            }
        } else
        {
            return null;
        }
    }

    public async Task<ReqResPostResponse?> PostData(ReqResPostRequest person)
    {
        var httpClient = httpClientFactory?.CreateClient("reqres");
        if(httpClient != null)
        {
            using var response = await httpClient.PostAsJsonAsync<ReqResPostRequest>
                ("users", person);
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReqResPostResponse>();
            } else
            {
                return null;
            }

        } else
        {
            return null;
        }
    }
}
