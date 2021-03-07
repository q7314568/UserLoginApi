namespace UserLoginApi.Models.Interface
{
    public interface IResponseModel
    {
        int errorCode { get; set; }
        string errorMessage { get; set; }
        int success { get; set; }
        string token { get; set; }
    }
}