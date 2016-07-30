using System.Linq;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            int Id = int.Parse(this.Data[1]);

            var question = this.Forum.Questions.FirstOrDefault(q => q.Id == Id);

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = question;
            this.Forum.Output.AppendLine(question.ToString());
        }
    }
}
