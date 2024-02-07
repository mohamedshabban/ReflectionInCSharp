namespace ReflectionInCSharp
{
    internal class Program
    {
        /// <summary>
        /// Reflections refer to the ability of program to examine and interact with its own structure at runtime
        /// this includes inspecting and manipulating types, methods, props, and other elements 
        /// Reflection allows you to dynamically load assembllies, create instances of types,
        /// invoke methods and access or modify object properties
        /// even if the their details not known at compile time
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Type mainType = typeof(ExampleClassReflection);
            //display name of type
            Console.WriteLine("Type: {0}", mainType.FullName);

            MethodInfo[] methodsInClass = mainType.GetMethods();
            object? instance = Activator.CreateInstance(mainType);
            foreach (MethodInfo method in methodsInClass)
            {
                if (method.Name == "SayHello")
                {
                    method.Invoke(instance, null);
                    break;
                }
            }
            var nestedProperty = mainType.GetProperty("Person");

        }
    }
    public class ExampleClassReflection
    {
        public Person Person { get; set; }
        public ExampleClassReflection()
        {
            Console.WriteLine("Instance created using Reflection");
            Person = new Person() { Name = "Ahmed", Age = 25, Height = 178 };
        }
        public void SayHello()
        {
            Console.WriteLine("Hello, Reflection");
        }
    }
    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
    }
}