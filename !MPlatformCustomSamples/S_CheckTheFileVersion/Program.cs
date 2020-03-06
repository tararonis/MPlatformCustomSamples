using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace S_CheckTheFileVersion
{
    class Program
    {
        //Why do we need it?
        //-To prevent the situation when dlls with the default version includes to installer
        //What it does:
        //Check that dlls doensn't have the default(1.7.0.0) version
        const string BuildVersion = "1.7.0.0";

        static string MPx64Path = @"E:\Work\cvsroot\MPlatform\trunk\Objects\MPlatform\x64\ReleasePX";
        static string MPx86Path = @"E:\Work\cvsroot\MPlatform\trunk\Objects\MPlatform\ReleasePX";
        static string MFx86Path = @"E:\Work\cvsroot\MPlatform\trunk\MFormats\MFormats\ReleasePX";
        static string MFx64Path = @"E:\Work\cvsroot\MPlatform\trunk\MFormats\MFormats\x64\ReleasePX";
        static string[] AllPathes = { MPx64Path, MPx86Path, MFx64Path, MFx86Path };



        static void Main(string[] args)
        {
            try
            {
                foreach (var path in AllPathes)
                    CheckTheDllsVersion(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an exception: " + ex.ToString());
                Console.ReadKey();
            }
        }

        private static void CheckTheDllsVersion(string path)
        {
            foreach (var filePath in Directory.EnumerateFiles(path))
            {
                Console.WriteLine("Check: " + filePath);
                if (filePath.Contains("dll"))
                {
                    Console.WriteLine("Is dll: " + filePath);
                    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
                    if (myFileVersionInfo.FileVersion == BuildVersion)
                    {
                        throw new Exception("Dif versions");
                    }
                }
            }
        }
    }
}

