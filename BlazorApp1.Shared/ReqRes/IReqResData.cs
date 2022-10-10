namespace BlazorApp1.Shared.ReqRes;

public interface IReqResData
{
    Task<ReqResResponse?> GetResponseData();
    void CancelRequest();
    Task<ReqResPostResponse?> PostData(ReqResPostRequest person);
}
