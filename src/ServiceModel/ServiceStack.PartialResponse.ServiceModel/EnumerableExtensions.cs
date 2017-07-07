using System.Collections;

namespace ServiceStack.PartialResponse.ServiceModel
{
    public static class EnumerableExtensions
    {
        public static bool IsGenericEnumerable(this IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                return false;
            }

            return enumerable.GetType().IsGenericType;
        }

        public static bool IsNotPrimitiveArray(this IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                return false;
            }
            
            var type = enumerable.GetType();
            return type.IsArray && !type.GetElementType().IsPrimitive;
        }
    }
}
