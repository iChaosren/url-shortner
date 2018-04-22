﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortner.Helpers
{
    public static class LongBase64
    {
        public static long Base64StringToLong(string s)
        {
            long total = 0;

            for (int i = s.Length - 1; i >= 0; i--)
                total += b64_long[s[i]] * Convert.ToInt64(Math.Pow(64, (s.Length - 1 - i)));

            return total;
        }

        public static string LongToBase64String(long l)
        {
            if (l == 0)
                return "0";
            
            string b64 = "";

            int i = 1;
            long r = l;

            while (r > 0)
            {
                var z = Math.Pow(64.0, i);
                var x = (l * 1.0) % z;
                var y = Math.Floor((x / z) * 64.0);

                b64 = long_b64[Convert.ToInt64(y)] + b64;
                r -= Convert.ToInt64(x);
                i++;
            }

            return b64;
        }

        public static readonly Dictionary<char, long> b64_long = new Dictionary<char, long>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 },
            { 'G', 16 },
            { 'H', 17 },
            { 'I', 18 },
            { 'J', 19 },
            { 'K', 20 },
            { 'L', 21 },
            { 'M', 22 },
            { 'N', 23 },
            { 'O', 24 },
            { 'P', 25 },
            { 'Q', 26 },
            { 'R', 27 },
            { 'S', 28 },
            { 'T', 29 },
            { 'U', 30 },
            { 'V', 31 },
            { 'W', 32 },
            { 'X', 33 },
            { 'Y', 34 },
            { 'Z', 35 },
            { 'a', 36 },
            { 'b', 37 },
            { 'c', 38 },
            { 'd', 39 },
            { 'e', 40 },
            { 'f', 41 },
            { 'g', 42 },
            { 'h', 43 },
            { 'i', 44 },
            { 'j', 45 },
            { 'k', 46 },
            { 'l', 47 },
            { 'm', 48 },
            { 'n', 49 },
            { 'o', 50 },
            { 'p', 51 },
            { 'q', 52 },
            { 'r', 53 },
            { 's', 54 },
            { 't', 55 },
            { 'u', 56 },
            { 'v', 57 },
            { 'w', 58 },
            { 'x', 59 },
            { 'y', 60 },
            { 'z', 61 },
            { '-', 62 },
            { '_', 63 }
        };
        public static readonly Dictionary<long, char> long_b64 = new Dictionary<long, char>()
        {
            { 0, '0'},
            { 1, '1' },
            { 2, '2' },
            { 3, '3' },
            { 4, '4' },
            { 5, '5' },
            { 6, '6' },
            { 7, '7'  },
            { 8, '8' },
            { 9, '9' },
            { 10, 'A' },
            { 11, 'B' },
            { 12, 'C' },
            { 13, 'D' },
            { 14, 'E' },
            { 15, 'F' },
            { 16, 'G' },
            { 17, 'H' },
            { 18, 'I' },
            { 19, 'J' },
            { 20, 'K' },
            { 21, 'L' },
            { 22, 'M' },
            { 23, 'N' },
            { 24, 'O' },
            { 25, 'P' },
            { 26, 'Q' },
            { 27, 'R' },
            { 28, 'S' },
            { 29, 'T' },
            { 30, 'U' },
            { 31, 'V' },
            { 32, 'W' },
            { 33, 'X' },
            { 34, 'Y' },
            { 35, 'Z' },
            { 36, 'a' },
            { 37, 'b' },
            { 38, 'c' },
            { 39, 'd' },
            { 40, 'e' },
            { 41, 'f' },
            { 42, 'g' },
            { 43, 'h' },
            { 44, 'i' },
            { 45, 'j' },
            { 46, 'k' },
            { 47, 'l' },
            { 48, 'm' },
            { 49, 'n' },
            { 50, 'o' },
            { 51, 'p' },
            { 52, 'q' },
            { 53, 'r' },
            { 54, 's' },
            { 55, 't' },
            { 56, 'u' },
            { 57, 'v' },
            { 58, 'w' },
            { 59, 'x' },
            { 60, 'y' },
            { 61, 'z' },
            { 62, '-' },
            { 63, '_' }
        };

    }
}
