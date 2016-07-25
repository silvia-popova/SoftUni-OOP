namespace Executor.IO.Commands
{
    using System;
    using System.Collections.Generic;

    using Executor.Contracts;
    using Executor.Exceptions;

    public class DisplayCommand : Command, IExecutable
    {
        public DisplayCommand(
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
            string[] data = this.Data;

            if (data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = data[1];
            string sortType = data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<ISudent> studentComparator = this.CreateStudentComparator(sortType);
                ISimpleOrderedBag<ISudent> list = this.Repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<ICourse> courseComparator = this.CreateCourseComparator(sortType);
                ISimpleOrderedBag<ICourse> list = this.Repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ICourse> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((course, course1) => course.CompareTo(course1));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((course, course1) => course1.CompareTo(course));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ISudent> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ISudent>.Create((student, student1) => student.CompareTo(student1));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ISudent>.Create((student, student1) => student1.CompareTo(student));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
