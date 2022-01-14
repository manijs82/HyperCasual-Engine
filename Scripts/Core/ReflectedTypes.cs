using System;
using HyperCasual_Engine.Utils;

namespace HyperCasual_Engine
{
    public class ReflectedTypes<T>
    {
        public readonly Type[] Types;
        public readonly string[] TypesNames;
        public int TypeChoiceIndex;

        public ReflectedTypes()
        {
            Types = Reflections.GetInheritedClasses(typeof(T));
            
            TypesNames = new string[Types.Length];
            for (int i = 0; i < TypesNames.Length; i++) 
                TypesNames[i] = Types[i].Name;
        }

        public Type GetTypeFromString(string typeName)
        {
            int index = Array.IndexOf(TypesNames, typeName);
            return Types[index];
        }
    }
}