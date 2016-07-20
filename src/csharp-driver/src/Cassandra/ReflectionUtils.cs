using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cassandra
{
    internal static class ReflectionUtils
    {
        /// <summary>
        /// Returns an array of custom attributes applied to this member.
        /// </summary>
        public static object[] GetCustomAttributesLocal(this Type member, Type attributeType, bool inherit)
        {
            return (object[])member.GetTypeInfo().GetCustomAttributes(attributeType, inherit);
        }

        /// <summary>
        /// Returns a custom attribute applied to this member or null.
        /// </summary>
        public static object GetCustomAttributeLocal(this Type member, Type attributeType, bool inherit)
        {
            return member.GetCustomAttributesLocal(attributeType, inherit).FirstOrDefault();
        }

        /// <summary>
        /// Gets a value indicating whether the type is generic
        /// </summary>
        public static bool IsGenericTypeLocal(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        /// <summary>
        /// Gets a value indicating whether the type is an interface; that is, not a class or a value type.
        /// </summary>
        public static bool IsInterfaceLocal(this Type type)
        {
            return type.GetTypeInfo().IsInterface;
        }

        /// <summary>
        /// Gets a value indicating whether the type is an enumeration.
        /// </summary>
        public static bool IsEnumLocal(this Type type)
        {
            return type.GetTypeInfo().IsEnum;
        }

        /// <summary>
        /// Gets a value indicating whether the type is assignable from another type.
        /// </summary>
        public static bool IsAssignableFromLocal(this Type type, Type other)
        {
            return type.GetTypeInfo().IsAssignableFrom(other);
        }

        /// <summary>
        /// Gets an array of types representing the type argument of a generic type.
        /// </summary>
        public static Type[] GetGenericArgumentsLocal(this Type type)
        {
            return type.GetTypeInfo().GetGenericArguments();
        }

        /// <summary>
        /// Gets a type interface by name
        /// </summary>
        public static Type GetInterfaceLocal(this Type type, string name)
        {
            return type.GetTypeInfo().GetInterface(name);
        }

        /// <summary>
        /// Gets the interfaces implemented by a given type
        /// </summary>
        public static Type[] GetInterfacesLocal(this Type type)
        {
            return type.GetTypeInfo().GetInterfaces();
        }

        /// <summary>
        /// Gets the attributes of a given type
        /// </summary>
        public static TypeAttributes GetAttributesLocal(this Type type)
        {
            return type.GetTypeInfo().Attributes;
        }

        /// <summary>
        /// Gets a property by name
        /// </summary>
        public static PropertyInfo GetPropertyLocal(this Type type, string name)
        {
            return type.GetTypeInfo().GetProperty(name);
        }

        /// <summary>
        /// Returns true if the type has the given attribute defined.
        /// </summary>
        public static bool IsAttributeDefinedLocal(this Type type, Type attributeType, bool inherit)
        {
            return type.GetTypeInfo().IsDefined(attributeType, inherit);
        }

        /// <summary>
        /// Returns true if the type has the given attribute defined.
        /// </summary>
        public static bool IsSubclassOfLocal(this Type type, Type other)
        {
            return type.GetTypeInfo().IsSubclassOf(other);
        }
    }
}
