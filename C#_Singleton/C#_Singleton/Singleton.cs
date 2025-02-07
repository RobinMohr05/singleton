﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Singleton
{
    public static class Singleton<T> where T : new()
    {
        private static readonly T _instance = new T();

        public static T Instance => _instance;
    }
}
