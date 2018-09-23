using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHANGE_Save_Editor.Helpers
{
    public static class RegistryKeyMapper
    {
        public static Dictionary<string, string> registryKeys = new Dictionary<string, string>();

        static RegistryKeyMapper()
        {
            registryKeys.Add("applicationsmade", "applicationsMade_h837912897");
            registryKeys.Add("autoeat", "AutoEat_h888103098");
        }

        public static void EnsureKey(string key)
        {
            string keyName = key.Contains("_") ? key.Substring(0, key.LastIndexOf("_")) : key;
            keyName = keyName.ToLower();

            if (registryKeys.ContainsKey(keyName.ToLower()))
            {
                if (registryKeys[keyName] != key)
                {
                    Debug.WriteLine("Colliding registry keys: " + registryKeys[keyName] + " and " + key);
                    registryKeys[keyName] = key;
                }
                return;
            }
            else
            {
                Debug.WriteLine("New registry key: " + key);
                registryKeys.Add(keyName, key);
            }


        }
    }
}
