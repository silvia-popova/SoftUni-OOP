namespace ConsoleForum.Entities.Users
{
    public class Guest : User
    {
        public Guest(int id, string name, string password, string email) 
            : base(id, name, password, email)
        {
        }
    }
}
