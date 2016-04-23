using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryIoCSample
{
    public class ServiceWithTypeParameter : IServiceWithTypeParameter
    {
        private TestObject _paramObject;
        public ServiceWithTypeParameter(TestObject param)
        {
            _paramObject = param;
        }

        public void PrintObjectFields()
        {
            Console.WriteLine("Object Name: " + _paramObject.ObjectName);
            Console.WriteLine("Object Type: " + _paramObject.ObjectType);
        }
    }
}
