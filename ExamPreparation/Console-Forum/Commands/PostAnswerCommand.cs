namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) : base(forum)
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

            string body = this.Data[1];
            int Id = this.Forum.Answers.Count + 1;

            var answer = new Answer(Id, body, this.Forum.CurrentUser);

            this.Forum.CurrentQuestion.Answers.Add(answer);
            this.Forum.Answers.Add(answer);

            this.Forum.Output.AppendLine(
                string.Format(Messages.PostAnswerSuccess, Id));
        }
    }
}
