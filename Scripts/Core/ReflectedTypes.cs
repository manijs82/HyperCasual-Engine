using System;
using HyperCasual_Engine.Utils;

namespace HyperCasual_Engine
{
    public struct ReflectedTypes
    {
        public readonly Type[] Types;
        public readonly string[] TypesNames;
        public int TypeChoiceIndex;

        public ReflectedTypes(Type type) : this()
        {
            Types = Reflections.GetInheritedClasses(type);
            
            TypesNames = new string[Types.Length];
            for (int i = 0; i < TypesNames.Length; i++) 
                TypesNames[i] = Types[i].Name;
        }
    }
}