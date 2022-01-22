using System.IO;

namespace HyperCasual_Engine
{
    public static class TextFileWriter
    {
        public static void CreateEmptyFile(string path)
        {
            using (File.Create(path)) {}
        }
        
        public static void OverwriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
        
        public static string GetText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}