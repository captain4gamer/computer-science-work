﻿using System;
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
            string[] split = path.Split(new char[] { '/' });
            Folder folder = null;
            bool b = true;
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

        }
    }
}