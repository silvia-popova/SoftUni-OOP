using System.Linq;
using System.Text;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;

    public class ShowQuestionsCommand : AbstractCommand 
    {
        public ShowQuestionsCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            StringBuilder result = new StringBuilder();

            if (this.Forum.Questions.Count == 0)
            {
                result.AppendLine("No questions");
            }
            else
            {
                var sortedQuestionss = this.Forum.Questions.OrderBy(q => q.Id);
                foreach (var question in sortedQuestionss)
                {
                    result.AppendLine(question.ToString());
                }
            }

            this.Forum.Output.AppendLine(result.ToString().Trim());
        }
    }
}
