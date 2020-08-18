namespace Application.Models.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }

        public UserResponse(int id, string name, string nick)
        {
            Id = id;
            Name = name;
            Nick = nick;
        }
    }
}
