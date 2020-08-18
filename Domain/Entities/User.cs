using Domain.FluentValidators;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; protected set; }
        public string Nick { get; protected set; }

        public User()
        {
        }

        public User(string name, string nick)
        {
            Name = name;
            Nick = nick;
        }

        public User(int id, string name, string nick)
        {
            Id = id;
            Name = name;
            Nick = nick;
        }

        public void Update(string nick)
        {
            Nick = nick;
        }

        public void Validate()
        {
            new UserValidator().CustomValidate(this);
        }
    }
}
