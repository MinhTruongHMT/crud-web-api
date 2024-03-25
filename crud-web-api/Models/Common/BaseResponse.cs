namespace crud_web_api.Models.Common
{
    public class BaseResponse
    {
        public int Code { get; set; } = 1;
        public string Message { get; set; } = string.Empty;
        public dynamic? Data { get; set; } = null;

        public BaseResponse()
        {
        }
    }
}
