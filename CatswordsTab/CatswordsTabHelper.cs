using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using CatswordsTab.Properties;

namespace CatswordsTab
{
    public class CatswordsTabHelper
    {
        // https://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
        public string GetFileMd5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public string GetFileSha1(string filename)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        // https://stackoverflow.com/questions/7514101/how-do-i-read-exactly-n-bytes-from-a-stream
        public string GetFileHead32(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                int count = 32;

                byte[] buffer = new byte[count];
                int offset = 0;
                while (offset < count)
                {
                    int read = stream.Read(buffer, offset, count - offset);
                    if (read == 0)
                        throw new System.IO.EndOfStreamException();
                    offset += read;
                }
                System.Diagnostics.Debug.Assert(offset == count);

                return Convert.ToBase64String(buffer);
            }
        }

        public string GetFileExtension(string filename)
        {
            return Path.GetExtension(filename);
        }
    }
}
