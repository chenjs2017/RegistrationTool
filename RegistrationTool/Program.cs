using System;
using System.Xml;

namespace PluginRegistrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistrationHelper registrationHelper = new RegistrationHelper();

            string path = AppContext.BaseDirectory +  "/reg.xml";

            bool unregister = false;
            bool register = true;
            foreach (string arg in args)
            {
                if (arg.Split('=').GetValue(0).ToString().ToUpperInvariant() == "/PATH")
                {
                    path = arg.Split('=').GetValue(1).ToString();
                }
                if (arg.ToUpperInvariant() == "/UNREGISTER")
                {
                    unregister = true;
                }
                if (arg.ToUpperInvariant() == "/?" || arg == "/HELP")
                {

                    register = false;
                }
            }
            if (register)
            {
                XmlDocument assemblyRegistrationXml = new XmlDocument();
                assemblyRegistrationXml.Load(path);
                if (!unregister)
                {
                    registrationHelper.Register(assemblyRegistrationXml);
                }
                else
                {

                    registrationHelper.Unregister(assemblyRegistrationXml);
                }
                if (registrationHelper.Errors.Count != 0)
                {
                    foreach (string error in registrationHelper.Errors)
                    {
                        Console.WriteLine(error);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
