using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppInModularWay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountController accountController = new AccountController();
            AccountController.Start();
        }
    }
}
