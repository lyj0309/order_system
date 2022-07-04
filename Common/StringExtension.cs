﻿using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//直接给系统类写拓展方法
namespace System
{
    public static class StringExtension
    {
        public static string ToSHA512(this string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            using var s =  SHA512.Create();
            byte[] hash = s.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-",string.Empty).ToLowerInvariant();
        }
    }
}
