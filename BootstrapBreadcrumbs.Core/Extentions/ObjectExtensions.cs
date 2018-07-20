using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace BootstrapBreadcrumbs.Core.Extentions
{
    static class ObjectExtensions
    {
        internal static object AddProperty(this object obj, string name, object value)
        {
            var properties = obj.GetType().GetProperties();
            var newObject = new ExpandoObject() as IDictionary<string, Object>; ;

            foreach(var property in properties)
            {
                newObject.Add(property.Name, property.GetValue(obj));
            }

            newObject.Add(name, value);

            return newObject;
        }

    }
}
