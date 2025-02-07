using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton<Database>.Instance.Query();
            Singleton<Database>.Instance.Query();
        }
    }
}
