using System;
using System.IO;

namespace Explorer.Framework.Utilities
{
    public static class FileHelper
    {
        /// <summary>
        /// Write content to a file named unnamed.txt
        /// </summary>
        /// <param name="content"></param>
        public static void WriteToFile(string content)
        {
            WriteToFile(fileName: "unnamed.txt", content: content, append: false, filePath: null, fileType: null);
        }

        /// <summary>
        /// Write content to a named file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public static void WriteToFile(string fileName, string content)
        {
            WriteToFile(fileName: fileName, content: content, append: false, filePath: null, fileType: null);
        }

        /// <summary>
        /// Write content to a named file with optional parameters
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <param name="append"></param>
        /// <param name="filePath"></param>
        /// <param name="fileType"></param>
        public static void WriteToFile(string fileName, string content, bool append = false, string filePath = null, string fileType = null)
        {
            if (!String.IsNullOrEmpty(fileType))
            {
                fileName += '.' + fileType;
            }
            var path = "";
            if (String.IsNullOrEmpty(filePath))
            {
                path = Path.Combine(ConfigManager.BaseFolder.Value, fileName);
            }
            else
            {
                path = Path.Combine(filePath, fileName);
            }

            if (!File.Exists(path))
            {
                if (append is false)
                {
                    File.WriteAllText(path, content);
                }
                else
                {
                    File.AppendAllText(path, content);
                }
            }
        }

        /// <summary>
        /// Read from a file named unnamed.txt
        /// </summary>
        /// <returns></returns>
        [Obsolete("Do not use. Use ReadFromFile() with one or more parameters")]
        public static string ReadFromFile()
        {
            return ReadFromFile(fileName: "unnamed.txt", filePath: null, fileType: null);
        }

        /// <summary>
        /// Read from a named file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFromFile(string fileName)
        {
            return ReadFromFile(fileName: fileName, filePath: null, fileType: null);
        }

        /// <summary>
        /// Read from a named file with optional parameters
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="filePath"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ReadFromFile(string fileName, string filePath = null, string fileType = null)
        {
            if (!String.IsNullOrEmpty(fileType))
            {
                fileName += '.' + fileType;
            }
            var path = "";
            if (String.IsNullOrEmpty(filePath))
            {
                path = Path.Combine(ConfigManager.BaseFolder.Value, fileName);
            }
            else
            {
                path = Path.Combine(filePath, fileName);
            }
            if (!File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                throw new Exception("Could not read from file");
            }
        }
    }
}