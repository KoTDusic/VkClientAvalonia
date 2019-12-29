using System;
using System.Linq;
using System.Reflection;
using RestSharp;
using System.Runtime.Serialization;

namespace Shared
{
    public static class RestRequestExtension
    {
        public static IRestRequest AddParamsToRequestFromJson(this IRestRequest request, object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var propertyType = property.PropertyType;
                var propValue = property.GetValue(obj, null);
                if (propValue == null)
                {
                    continue;
                }
                
                if (propertyType.IsArray)
                {
                    var elementType = propertyType.GetElementType();
                    propValue = ((Array) propValue).Length <= 0 || !(elementType != null)
                                                      || !elementType.IsPrimitive &&
                                                      !elementType.IsValueType &&
                                                      !(elementType == typeof(string))
                        ? string.Join(",", (string[]) propValue)
                        : string.Join(",", ((Array) propValue)
                            .OfType<object>()
                            .Select(item => item.ToString())
                            .ToArray());
                }

                request.AddParameter(property.GetCustomAttribute<DataMemberAttribute>().Name, propValue);
            }

            return request;
        }
    }
}