using System;
using System.Collections.Generic;
using System.Text;

namespace TestVersion.ActionFile.IAction
{
    public interface ITextFile : IFileNTU
    {
        public string ReadFile(string Path);

        public bool WriteFile(string Path, string Content);
    }
}