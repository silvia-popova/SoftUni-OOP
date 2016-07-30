namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            string title = this.Data[1];
            string body = this.Data[2];
            int Id = this.Forum.Questions.Count + 1;

            var question = new Question(Id, body, this.Forum.CurrentUser, title);
            this.Forum.Questions.Add(question);

            this.Forum.Output.AppendLine(
                string.Format(Messages.PostQuestionSuccess, Id));
        }
    }
}
