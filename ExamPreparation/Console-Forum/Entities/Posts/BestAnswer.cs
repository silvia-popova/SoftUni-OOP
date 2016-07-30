namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author) 
            : base(id, body, author)
        {
        }
    }
}
