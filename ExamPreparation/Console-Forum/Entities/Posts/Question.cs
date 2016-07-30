using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;

    public class Question : IQuestion
    {
        private new List<IAnswer> answers;

        public Question(int id, string body, IUser author, string title)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
            this.Title = title;
            this.answers = new List<IAnswer>();
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }

        public string Title { get; set; }

        public IList<IAnswer> Answers => this.answers;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"[ Question ID: {this.Id} ]");
            result.AppendLine($"Posted by: {this.Author.Username}");
            result.AppendLine($"Question Title: {this.Title}");
            result.AppendLine($"Question Body: {this.Body}");
            result.AppendLine("====================");

            if (this.Answers.Count == 0)
            {
                result.Append("No answers");
            }
            else
            {
                result.AppendLine("Answers:");

                var bestAnswer = this.Answers.FirstOrDefault(a => a is BestAnswer);

                if (bestAnswer != null)
                {
                    result.AppendLine("********************");
                    result.AppendLine(bestAnswer.ToString());
                    result.AppendLine("********************");

                }

                var sortedAnswers = this.answers.OrderBy(a => a.Id).ToList();
                sortedAnswers.Remove(bestAnswer);

                foreach (var answer in sortedAnswers)
                {
                    result.AppendLine(answer.ToString());
                }
            }

            return result.ToString().Trim();
        }
    }
}
