﻿namespace Executor.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Executor.Contracts;
    using Executor.Exceptions;

    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.CurrentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.CurrentPath);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}",
                                                                  new string('-', identation),
                                                                  currentPath));
                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        for (int i = 0; i < indexOfLastSlash; i++)
                        {
                            OutputWriter.WriteMessage("-");
                        }

                        OutputWriter.WriteMessageOnNewLine(file.Substring(indexOfLastSlash));
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.CurrentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {                                                                       
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.CurrentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidPathException();
                }
            }
            else
            {
                string currentPath = SessionData.CurrentPath;
                currentPath += "\\" + relativePath;
                this.ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            SessionData.CurrentPath = absolutePath;
        }
    }
}
