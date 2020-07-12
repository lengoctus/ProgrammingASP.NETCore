using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestVersion.ActionFile.IAction;

namespace TestVersion.ActionFile.CsAction
{
    class TextFileAction : FileNTU, ITextFile
    {
        public string ReadFile(string Path)
        {
            if (string.IsNullOrEmpty(Path.Trim())) return "0";
            try
            {
                using (StreamReader stream = File.OpenText(Path))
                {
                    string content = "";
                    while (true)
                    {
                        var str = stream.ReadLine();
                        if (str == null) break;
                        content += str + "\n";
                    }
                    return content;

                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public bool WriteFile(string Path, string Content)
        {
            if (string.IsNullOrEmpty(Path.Trim()) || string.IsNullOrEmpty(Content.Trim())) return false;

            try
            {
                using (StreamWriter writer = File.AppendText(Path))
                {
                    writer.WriteLine(Content);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
