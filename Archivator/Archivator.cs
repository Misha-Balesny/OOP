using System;
using System.IO;
using System.IO.Compression;

namespace Archivator
{
    public class Archivator
    {
        public string Save(string sourceFile)
        {
            string compressedFile = "temp.gz";
            File.WriteAllText("temp.txt", sourceFile);
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
            File.Delete("temp.txt");
            return compressedFile;
        }
        
        public string Load(string compressedFile)
        {
            if (string.IsNullOrEmpty(compressedFile))
                compressedFile = "temp.gz";

            string targetFile = "temp.txt";
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
            return targetFile;
        }
    }
}

