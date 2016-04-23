using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryIoCSample
{
    public class Program
    {
        public static Container Container { get; private set; }

        private static void ConfigureContainer()
        {
            Container = new Container();
            
            // Basic test first
            Container.Register<IClient, TestClient>();

            // Singletons can be set up using Reuse - demo this by getting an instance, updating value, then resolving a new instance
            Container.Register<ISingletonClient, SingletonClient>(Reuse.Singleton);

            // Registering with a primitive type to be passed to constructor
            Container.Register<IServiceWithParameter, ServiceWithParameter>(Made.Of(() => new ServiceWithParameter(Arg.Index<string>(0)), requestIgnored => "this is the parameter"));

            // Then registering a complex object instance to be used
            Container.Register<TestObject>();
            var testObj = new TestObject
            {
                ObjectName = "Ian",
                ObjectType = "Person"
            };
            // Register the instance above (into the container) - giving it an Id ("serviceKey") = "obj1"
            Container.RegisterInstance<TestObject>(testObj, serviceKey: "obj1");
            // Register ServiceWithTypeParameter - saying "When you make me a ServiceWithTypeParameter; and a contructor needs a TestObject - use the one with Id "obj1"
            Container.Register<IServiceWithTypeParameter, ServiceWithTypeParameter>(made: Parameters.Of.Type<TestObject>(serviceKey: "obj1"));

            // And finally multiple implementations
            // Registering multiple interface implementations using an enum key
            Container.Register<IMultipleImplementations, MultipleImplementationOne>(serviceKey: InterfaceKey.FirstKey);
            Container.Register<IMultipleImplementations, MultipleImplementationTwo>(serviceKey: InterfaceKey.SecondKey);
            
        }

        static void Main(string[] args)
        {
            // Without Dry Ioc
            IClient client = new TestClient();

            ConfigureContainer();

            // With Dry Ioc
            Console.WriteLine("Basic implementation:");
            IClient resolvedClient = Container.Resolve<IClient>();
            resolvedClient.Print();
            Console.WriteLine();

            // Singleton test
            Console.WriteLine("Singleton implementation:");
            ISingletonClient firstSingleton = Container.Resolve<ISingletonClient>();
            firstSingleton.Print();
            firstSingleton.ChangeString("I've now been modified!");

            ISingletonClient secondSingleton = Container.Resolve<ISingletonClient>();
            secondSingleton.Print();
            Console.WriteLine();

            // Resolving with a passed in primitive type 
            Console.WriteLine("Primitive type as parameter:");
            IServiceWithParameter resolvedWithPrimitiveParameter = Container.Resolve<IServiceWithParameter>();
            resolvedWithPrimitiveParameter.PrintParameter();
            Console.WriteLine();

            // Resolving with a passed in complex object
            Console.WriteLine("Object as parameter:");
            IServiceWithTypeParameter resolvedWithTypeParameter = Container.Resolve<IServiceWithTypeParameter>();
            resolvedWithTypeParameter.PrintObjectFields();
            Console.WriteLine();

            // Resolving an interface that has multiple implementations using a key
            Console.WriteLine("Multiple implementations, retrieving specific:");
            IMultipleImplementations firstImplementation = Container.Resolve<IMultipleImplementations>(serviceKey: InterfaceKey.FirstKey);
            firstImplementation.Print();
            IMultipleImplementations secondImplementation = Container.Resolve<IMultipleImplementations>(serviceKey: InterfaceKey.SecondKey);
            secondImplementation.Print();
            Console.WriteLine();

            // Or retrieve all implementations in an IEnumerable
            Console.WriteLine("Multiple implementations, retrieving all:");
            IEnumerable<IMultipleImplementations> allImplementations = Container.ResolveMany<IMultipleImplementations>();
            foreach (IMultipleImplementations implementation in allImplementations)
            {
                implementation.Print();
            }

            Console.ReadLine();
        }
    }
}
