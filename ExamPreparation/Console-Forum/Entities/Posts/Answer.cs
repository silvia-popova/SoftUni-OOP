using System.Text;

namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;

    public class Answer : IAnswer
    {
        public Answer(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"[ Answer ID: {this.Id} ]");
            result.AppendLine($"Posted by: {this.Author.Username}");
            result.AppendLine($"Answer Body: {this.Body}");
            result.AppendLine("--------------------");

            return result.ToString().Trim();
        }
    }
}
