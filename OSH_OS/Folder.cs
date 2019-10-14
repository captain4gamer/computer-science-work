using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSH_OS
{
    class Folder
    {
        string name;
        File[] files;
        int fileCount;
        Folder[] subFolders;
        int folderCount;

        public Folder(string Name)
        {
            name = Name;
            files = new File[10];
            fileCount = 0;
            subFolders = new Folder[10];
            folderCount = 0;
        }

        public int AddFile(File NewFile)
        {
            if(fileCount == 10)
            {
                return 1;
            }else if(File.NonUnique(files, NewFile))
            {
                return 2;
            }
            else
            {
                files[fileCount] = new File(NewFile);
                fileCount++;
                return 0;
            }
        }

        public File GetFile(string FileName)
        {
            for(int i = 0;i < fileCount; i++)
            {
                if (files[i].GetFullName() == FileName)
                    return files[i];
            }
            return null;
        }

        public File RemoveFile(string FileName)
        {
            File f = null;
            int index = -1;
            for(int i = 0;i < fileCount; i++)
            {
                if(files[i].GetFullName() == FileName)
                {
                    index = i;
                    i = fileCount;
                }
            }
            if(index != -1)
            {
                f = files[index];
                if(index == 10)
                {
                    files[index] = null;
                    fileCount--;
                }
                else
                {
                    for(int i = index;i < fileCount - 1; i++)
                    {
                        files[i] = files[i + 1];
                    }
                    files[fileCount] = null;
                    fileCount--;
                }
            }
            return f;
        }

        public int AddSubFolder(string SubFolderName)
        {
            if (folderCount == 10)
                return 1;
            for(int i = 0;i < folderCount; i++)
            {
                if (subFolders[i].name == SubFolderName)
                    return 2;
            }
            subFolders[folderCount] = new Folder(SubFolderName);
            folderCount++;
            return 0;
        }

        public Folder GetSubFolder(string SubFolderName)
        {
            for(int i = 0;i < folderCount; i++)
            {
                if (subFolders[i].name == SubFolderName)
                    return subFolders[i];
            }
            return null;
        }

        public Folder RemoveSubFolder(string SubFolderName)
        {
            Folder f = null;
            int index = -1;
            for (int i = 0; i < folderCount; i++)
            {
                if (subFolders[i].name == SubFolderName)
                {
                    index = i;
                    i = folderCount;
                }
            }
            if (index != -1)
            {
                f = subFolders[index];
                if (index == 10)
                {
                    subFolders[index] = null;
                    folderCount--;
                }
                else
                {
                    for (int i = index; i < folderCount - 1; i++)
                    {
                        subFolders[i] = subFolders[i + 1];
                    }
                    subFolders[folderCount] = null;
                    folderCount--;
                }
            }
            return f;
        }

        public void ShowContentList()
        {
            Console.WriteLine("Folders:");
            for(int i = 0;i < folderCount; i++)
            {
                Console.WriteLine(subFolders[i].name);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Files:");
            for(int i = 0;i < fileCount; i++)
            {
                Console.WriteLine(String.Format("file name:{0}  file size:{1}", files[i].GetFullName(),files[i].GetSize()));
            }
        }

        public void ShowFolderContentTypes()
        {
            string type;
            int count;
            for(int i = 0;i < File.GetFileTypesCount(); i++)
            {
                type = File.GetFileTypeByIndex(i);
                count = 0;
                for(int j = 0;j < fileCount; j++)
                {
                    if (type == File.GetFileTypeByIndex(files[j].GetFileType()))
                        count++;
                }
                Console.WriteLine(String.Format("type:{0}  count:{1}", type, count));
            }
        }
    }
}
