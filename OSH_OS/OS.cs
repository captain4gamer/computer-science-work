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
        bool running;
        public OS()
        {
            root = new Folder("Root");
            running = true;
        }
        public bool IsRunning()
        {
            return running;
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
            string[] splitString = split[split.Length - 1].Split(new char[] { '.' });
            string name = "";
            for(int i = 0;i < split[split.Length - 1].Length - splitString[splitString.Length - 1].Length - 1; i++)
            {
                name += split[split.Length - 1][i];
            }
            File file = FindFile(FullPath);
            Folder folder = FindFolder(destination);
            if(file != null && folder != null)
            {
                CreateNewFile(name, destination, file.GetFileType(), file.GetContent());
            }
        }
        public void MoveFile(string origin, string destination, string name)
        {
            Folder folder1 = FindFolder(origin);
            Folder folder2 = FindFolder(destination);
            File file = null;
            if (folder1 != null && folder2 != null)
            {
                file = folder1.GetFile(name);
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
        public void ListFolderContent(string Path)
        {
            Folder folder = FindFolder(Path);
            folder.ShowContentList();
        }
        public void ListFolderContentTypes(string Path)
        {
            Folder folder = FindFolder(Path);
            folder.ShowFolderContentTypes();
        }
        public void Run()
        {
            Console.WriteLine("1. To create a new folder, type 1 and then press enter");
            Console.WriteLine("2. To create a new file, type 2 and then press enter");
            Console.WriteLine("3. To delete a file, type 3 and then press enter");
            Console.WriteLine("4. To copy a file, type 4 and then press enter");
            Console.WriteLine("5. To move a file, type 5 and then press enter");
            Console.WriteLine("6. To delete a folder, type 6 and then press enter");
            Console.WriteLine("7. To list folder content, type 7 and then press enter");
            Console.WriteLine("8. To list folder content types, type 8 and then press enter");
            Console.WriteLine("9. To exit, type 9 and press enter");
            int func = int.Parse(Console.ReadLine());
            if (func == 1)
            {
                Console.WriteLine("Please enter the name of the new folder");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the path in which the folder will be created");
                string path = Console.ReadLine();
                CreateNewFolder(name,path);
            }
            if (func == 2)
            {
                Console.WriteLine("Please enter the name of the new file");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the type of the file");
                int FileType = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the content of the new file");
                string content = Console.ReadLine();
                Console.WriteLine("Please enter the path in which the file will be created");
                string path = Console.ReadLine();
                CreateNewFile(name, path, FileType, content);
            }
            if (func == 3)
            {
                Console.WriteLine("Please enter the name of the file");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the path of the file");
                string path = Console.ReadLine();
                RemoveFile(name,path);
            }
            if (func == 4)
            {
                Console.WriteLine("Please enter the name of the path of the file");
                string fullpath = Console.ReadLine();
                Console.WriteLine("Please enter the destination");
                string destination = Console.ReadLine();
                CopyFile(fullpath,destination);
            }
            if (func == 5)
            {
                Console.WriteLine("Please enter the path of the folder in which the file is found");
                string Origin = Console.ReadLine();
                Console.WriteLine("Please enter the destination of the file");
                string Destination = Console.ReadLine();
                Console.WriteLine("Please enter the name of the file");
                string Name = Console.ReadLine();
                Console.WriteLine("Please enter the path in which the file will be created");
                MoveFile(Origin,Destination,Name);
            }
            if (func == 6)
            {
                Console.WriteLine("Please enter the name of the folder");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the path of the folder");
                string path = Console.ReadLine();
                RemoveFolder(name,path);
            }
            if (func == 7)
            {
                Console.WriteLine("Please enter the path of the folder");
                string path = Console.ReadLine();
                ListFolderContent(path);
            }
            if (func == 8)
            {
                Console.WriteLine("Please enter the path of the folder");
                string path = Console.ReadLine();
                ListFolderContentTypes(path);
            }
            if (func == 9)
                running = false;
        }
        public Folder FindFolder(string path)
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
            string path = "";
            for(int i = 0;i < split.Length - 1; i++)
            {
                path += split[i];
            }
            Folder folder = null;
            File file = null;
            folder = FindFolder(path);
            if (folder != null)
            {
                file = folder.GetFile(split[split.Length - 1]);
                return file;
            }
            return null;
        }   
    }
}