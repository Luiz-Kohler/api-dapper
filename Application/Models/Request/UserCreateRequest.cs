namespace Application.Models.Request
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        public string Nick { get; set; }

        public UserCreateRequest(string name, string nick)
        {
            Name = name;
            Nick = nick;
        }

        public UserCreateRequest()
        {
        }
    }
}
