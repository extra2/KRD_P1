using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRD_P1.Wrapper
{
    public interface IFile
    {
        bool FileExist(string path);
        void CreateFile(string path);
        string LoadFile(string path);
    }

    public class File : IFile
    {
        public void CreateFile(string path)
        {
            System.IO.File.Create(path);
        }

        public string LoadFile(string path)
        {
            return System.IO.File.Exists(path) ? System.IO.File.ReadAllText(path) : "";
        }

        bool IFile.FileExist(string path)
        {
            return System.IO.File.Exists(path);
        }
        
    }
}
