using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace CHANGE_Save_Editor.Helpers
{
    static class GameSaveReflectionHelper
    {
        private static Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();

        static GameSaveReflectionHelper()
        {
            Type t = typeof(GameSave);
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                properties[prop.Name.ToLower()] = prop;
            }
        }

        public static bool SetValue(this GameSave instance, string name, object val)
        {
            if (!properties.ContainsKey(name) || val.GetType() == typeof(byte[]))
            {
                Debug.WriteLine("Skipped " + name);
                // TODO: How to handle?
                return false;
            }

            PropertyInfo prop = properties[name];
            Type targetType = prop.PropertyType;

            if (targetType.IsEnum)
            {
                prop.SetValue(instance, Enum.ToObject(targetType, val));
            }
            else if (targetType == typeof(float))
            {
                prop.SetValue(instance, Util.LongToFloat(Convert.ToInt64(val)));
            }
            else if (targetType == typeof(int))
            {
                prop.SetValue(instance, Convert.ToInt32(val));
            }
            else if (targetType == typeof(bool))
            {
                prop.SetValue(instance, Convert.ToBoolean(val));
            }
            else
            {
                throw new Exception("Unexpected target type: " + targetType.ToString());
            }

            return true;
        }
    }

}
