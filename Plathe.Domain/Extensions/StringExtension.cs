using System;
using System.Linq;

namespace Plathe.Domain.Extensions
{
    public static class StringExtension
    {
        public static string CreateRandomString(this string str)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result; 
        }
    }
}