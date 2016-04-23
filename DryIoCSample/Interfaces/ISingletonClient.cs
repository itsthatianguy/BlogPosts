using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryIoCSample
{
    public interface ISingletonClient
    {
        void Print();
        void ChangeString(string newString);
    }
}
