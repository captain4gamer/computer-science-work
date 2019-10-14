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
            Folder f = FindFolder(path);
            if (f != null)
                f.AddSubFolder(name);
        }
        public void CreateNewFile(string Name, string Path, int FileType, string Content)
        {
            File file = new File(Name, FileType, Content);
            Folder f = FindFolder(Path);
            if (f != null)
            {
                f.AddFile(file);    
            }
    
        }
        public void RemoveFile(string Name, string path)
        {
            Folder f = FindFolder(path);
            if (f != null)
            {
                if (f.GetFile(Name) != null)
                {
                    f.RemoveFile(Name);
                }
            }
        }
        public void CopyFile(string FullPath, string destination)
        {
            string[] split = FullPath.Split(new char[] { '/' });
            File file = FindFile(FullPath);
            Folder folder = FindFolder(destination);
            if(file != null && folder != null)
            {
                CreateNewFile(split[0], destination, file.GetFileType(), file.GetContent());
            }
        }
        public void MoveFile(string origin, string destination, string name)
        {
            Folder folder1 = FindFolder(origin);
            Folder folder2 = FindFolder(destination);
            File file = null;
            if (folder1 != null && folder2 != null)
            {
                file = folder2.GetFile(name);
                if(file != null)
                {
                    CopyFile(origin + "/" + name, destination);
                    RemoveFile(name, origin);
                }
            }
        }
        public void RemoveFolder(string name, string path)
        {
            Folder f = FindFolder(path);
            if(f != null)
            {
                if(f.GetSubFolder(name) != null)
                {
                    f.RemoveSubFolder(name);
                }
            }
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
            string[] split = path.Split(new char[] { '/' });
            Folder folder = null;
            if (split[0] == "Root")
            {
                folder = root;
                for (int i = 1; i < split.Length; i++)
                {
                    if (folder.GetSubFolder(split[i]) != null)
                    {
                        folder = folder.GetSubFolder(split[i]);
                    }
                    else
                    {
                        i = split.Length;
                        folder = null;
                    }
                }
            }
            return folder;
        }
        private File FindFile(string FullPath)
        {
            string[] split = FullPath.Split(new char[] { '/' });
            Folder folder = null;
            File file = null;
            folder = FindFolder(FullPath);
            if (folder != null)
                {
                    file = folder.GetFile(split[split.Length - 1]);
                    return file;
                }
            return null;
        }   
    }
}