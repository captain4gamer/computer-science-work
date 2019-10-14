using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSH_OS
{
    class OS
    {
        Folder root;
        public OS()
        {
            root = new Folder("Root");
        }
        public void CreateNewFolder(string name, string path)
        {
            string[] split = path.Split(new char[] { '/' });
            Folder f;
            bool b = true;
            if(split[0] == "Root")
            {
                f = root;
                for(int i = 1;i < split.Length && b; i++)
                {
                    if(f.GetSubFolder(split[i]) != null)
                    {
                        f = f.GetSubFolder(split[i]);
                    }
                    else
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    f.AddSubFolder("name");
                }
            }
        }
        public void CreateNewFile()
        {

        }
        public void RemoveFile()
        {

        }
        public void CopyFile()
        {

        }
        public void MoveFile()
        {

        }
        public void RemoveFolder()
        {

        }
        public void ListFolderContent()
        {

        }
        public void ListFolderContentTypes()
        {

        }
        public void Run()
        {

        }
        private Folder FindFolder(string path)
        {

        }
        private File FindFile(string FullPath)
        {

        }
    }
}
