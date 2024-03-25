using crud_web_api.Entities;
using crud_web_api.Models.Common;

namespace crud_web_api.Models.Users
{

   
    public class UserData
    {
        public int TotalRecord { get; set; }
        public required List<User> Users { get; set; }
    }
    public class GetUsersResponse : BaseResponse
    {
        public new UserData? Data { get; set; }
    }
}
