using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryIoCSample
{
    public class MultipleImplementationTwo : IMultipleImplementations
    {
        public void Print()
        {
            Console.WriteLine("While I am another!");
        }
    }
}
