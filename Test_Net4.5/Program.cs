using JQData.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Net4._5
{
    class Program
    {
        static void Main(string[] args)
        {

           var d=  JAPI.GetTokenAsync("17300543835", "Jq123789456").Result;
        }
    }
}
