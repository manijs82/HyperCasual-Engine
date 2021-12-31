using System;
using System.Linq;
using System.Reflection;

namespace HyperCasual_Engine.Utils
{
    public static class Reflections
    {
        public static Type[] GetInheritedClasses(Type parentType) 
        {
            //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
            return Assembly.GetAssembly(parentType).GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(parentType)).ToArray();
        }
    }
}