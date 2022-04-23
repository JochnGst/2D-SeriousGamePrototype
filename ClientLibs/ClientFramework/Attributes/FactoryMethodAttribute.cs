using System;

namespace ClientFramework.Attributes
{
    public class FactoryMethodAttribute : Attribute
    {
        private readonly Type _type;

        public FactoryMethodAttribute(Type type)
        {
            // Type of the created object
            _type = type;
        }
    }
}