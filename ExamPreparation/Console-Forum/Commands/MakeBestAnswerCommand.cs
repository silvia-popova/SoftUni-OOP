using System.Linq;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int Id = int.Parse(this.Data[1]);

            var answer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(a => a.Id == Id);

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if (this.Forum.CurrentUser != this.Forum.CurrentQuestion.Author && !(this.Forum.CurrentUser is IAdministrator))
            {
                throw new CommandException(Messages.NoPermission);
            }

            var checkForBestAnswer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(a => a is BestAnswer);

            if (checkForBestAnswer == null)
            {
                var bestAnswer = new BestAnswer(answer.Id, answer.Body, answer.Author);

                this.Forum.CurrentQuestion.Answers.Remove(answer);
                this.Forum.CurrentQuestion.Answers.Add(bestAnswer);


                this.Forum.Output.AppendLine(
                    string.Format(Messages.BestAnswerSuccess, Id));
            }
        }
    }
}
