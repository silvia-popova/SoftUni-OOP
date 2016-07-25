namespace Executor.IO.Commands
{
    using Executor.Contracts;
    using Executor.Exceptions;

    public class ChangeRelativePathCommand : Command
    {
        public ChangeRelativePathCommand(
            string input,
            string[] data,
            IContentComparer tester,
            IDatabase repository,
            IDownloadManager downloadManager,
            IDirectoryManager ioManager)
            : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string relPath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}
