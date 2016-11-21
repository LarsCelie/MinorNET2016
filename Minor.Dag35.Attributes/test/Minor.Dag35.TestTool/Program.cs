using Minor.Dag35.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Minor.Dag35.TestTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load(new AssemblyName("Minor.Dag35.Attributes"));

            WriteClassInfo(assembly);
        }

        private static void WriteClassInfo(Assembly ass)
        {
            foreach (var type in ass.GetTypes())
            {
                Console.WriteLine($"public class {type.Name}");

                WriteMethodInfo(type);

                Console.WriteLine();
            }
        }

        private static void WriteMethodInfo(Type type)
        {
            foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly))
            {

                Console.WriteLine($"\t{getVisibility(method)} {method}");

                WriteTestAttributeInfo(type, method);

                Console.WriteLine();
            }
        }

        private static void WriteTestAttributeInfo(Type type, MethodInfo method)
        {
            foreach (var devAttr in method.GetCustomAttributes<TestAttribute>())
            {
                object instance = Activator.CreateInstance(type);
                object[] parameters = devAttr.Input;
                object result = null;

                try
                {
                    result = method.Invoke(instance, parameters);
                }
                catch (Exception e)
                {
                    result = e.GetBaseException().GetType().Name;
                }

                Object output = devAttr.Output != null ? devAttr.Output : devAttr.ExpectedException;
                string expected = "";

                if (!output.Equals(result))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    expected = $" (Expected: { output})";
                }

                Console.WriteLine($"\t\t{method.Name}({string.Join(" ", devAttr.Input)}) = {result}{expected}");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
        }

        private static string getVisibility(MethodInfo method)
        {
            StringBuilder sb = new StringBuilder();
            if (method.IsPrivate)
                sb.Append("private");
            else if (method.IsPublic)
                sb.Append("public");
            else if (method.IsFamily)
                sb.Append("protected");
            else if (method.IsAssembly)
                sb.Append("internal");
            else if (method.IsFamilyOrAssembly)
                sb.Append("protected internal");

            if (method.IsAbstract)
                sb.Append(" abstract");
            else if (method.IsVirtual)
                sb.Append(" virtual");

            if (method.IsStatic)
                sb.Append(" static");
            return sb.ToString();
        }
    }
}
