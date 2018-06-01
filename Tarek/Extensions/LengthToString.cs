using System;

namespace Tarek.Extensions
{
    public static class LengthToString
    {
        public static string ToReadableLength(this long fileSize)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB

            if (fileSize == 0)
                return "0" + suf[fileSize];

            long bytes = Math.Abs(fileSize);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(fileSize) * num).ToString() + suf[place];
        }
    }
}
