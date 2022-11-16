using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace MainCUI
{
    interface IOperator
    {
        int DoOperation(int a, int b);
    }

    class Addition : IOperator
    {
        public int DoOperation(int a, int b)
        {
            return a + b;
        }
    }

    class Subtraction : IOperator
    {
        public int DoOperation(int a, int b)
        {
            return a - b;
        }
    }

    class Program
    {
        static void DoDemoPolymorphism()
        {
            IOperator ops = new Addition();
            Console.WriteLine(ops.DoOperation(100, 25));

            ops = new Subtraction();
            Console.WriteLine(ops.DoOperation(100, 25));
        }

        static void DoDemoPlugin()
        {
            // Get list of DLL files in main executable folder
            string exePath = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(exePath);
            FileInfo[] fis = new DirectoryInfo(folder).GetFiles("*.dll");

            var plugins = new List<IPluginContract>();

            // Load all assemblies from current working directory
            foreach(FileInfo fileInfo in fis)
            {
                var domain = AppDomain.CurrentDomain;
                Assembly assembly = domain.Load(
                    AssemblyName.GetAssemblyName(fileInfo.FullName));

                // Get all of the types in the dll
                Type[] types = assembly.GetTypes();

                // Only create instance of concrete class that inherits from IPluginContract
                foreach(var type in types)
                {
                    if (type.IsClass && 
                        typeof(IPluginContract).IsAssignableFrom(type))
                    {
                        plugins.Add(Activator.CreateInstance(type) as IPluginContract);
                    }                        
                }                
            }

            // Invoke all the functions in all the dlls that we found
            foreach(var plugin in plugins)
            {
                int result = plugin.InvokeSignature(100, 25);
                Console.WriteLine(result);
            }
        }

        static void Main(string[] args)
        {
            DoDemoPolymorphism();
            //DoDemoPlugin();

            Console.ReadLine();
        }
    }
}
