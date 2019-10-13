using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSH_OS
{
    class File
    {
        static string[] fileTypes = { "txt", "mp3", "pdf", "jpg", "mpg" };
        string name;
        int fileType;
        int size;
        string content;
        public File(string Name, int FileType, string Content)
        {
            this.name = Name;
            this.fileType = FileType;
            this.content = Content;
            size = content.Length;
        }
        public File(File ExistingFile)
        {
            this.name = ExistingFile.name;
            this.fileType = ExistingFile.fileType;
            this.content = ExistingFile.content;
            size = content.Length;
        }
        public void SetName(string Name)
        {
            this.name = Name;
        }
        public int GetFileType()
        {
            return fileType;
        }
        public int GetSize()
        {
            return size;
        }
        public string GetFullName()
        {
            return name + "." + fileTypes[fileType];
        }
        public override string ToString()
        {
            return "Name: " + GetFullName() + ", Size: " + GetSize();
        }
        public static bool NonUnique(File[] Files, File NewFile)
        {
            for (int i = 0; i < Files.Length; i++)
            {
                if(Files[i] != 0)
                    if (Files[i].GetFullName() == NewFile.GetFullName())
                        return true;
            }
            return false;
        }
        public static int GetFileTypesCount()
        {
            return fileTypes.Length;
        }
        public static string GetFileTypeByIndex(int index)
        {
            return fileTypes[index];
        }
    }
}
