using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryIoCSample
{
    public class SingletonClient : ISingletonClient
    {
        private string _instanceString = "This is the original";

        public void ChangeString(string newString)
        {
            _instanceString = newString;
        }

        public void Print()
        {
            Console.WriteLine(_instanceString);
        }
    }
}
