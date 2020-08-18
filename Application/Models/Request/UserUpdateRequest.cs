namespace Application.Models.Request
{
    public class UserUpdateRequest
    {
        public string Nick { get; set; }

        public UserUpdateRequest(string nick)
        {
            Nick = nick;
        }
        public UserUpdateRequest()
        {
        }
    }
}
