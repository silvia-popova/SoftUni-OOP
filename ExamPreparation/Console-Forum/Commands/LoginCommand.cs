using System.Linq;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var currentUser = this.Forum.CurrentUser;

            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (currentUser != null)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }
            else
            {
                var user = users.FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    throw new CommandException(Messages.InvalidLoginDetails);
                }

                if (user.Password != password)
                {
                    throw new CommandException(Messages.InvalidLoginDetails);
                }

                this.Forum.CurrentUser = user;

                this.Forum.Output.AppendLine(
                    string.Format(Messages.LoginSuccess, username));
            }
        }
    }
}
