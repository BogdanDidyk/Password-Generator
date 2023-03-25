﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        [Flags]
        public enum PasswordChars
        {
            Digits = 0b0001,
            Alphabet = 0b0010,
            Symbols = 0b0100
        }

        const int MIN_PASSWORD_LENGTH = 5;
        const int MAX_PASSWORD_LENGTH = 15;

        readonly Random rnd;
        readonly string DIGITS;
        readonly string ALPHABET;
        readonly string SPECIAL_SYMBOLS;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
}