using CHANGE_Save_Editor.GameData;
using CHANGE_Save_Editor.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace CHANGE_Save_Editor
{
    public static class RegistrySaveManager
    {

        public static GameSave Load()
        {
            GameSave save = new GameSave();
            save.Other = new Dictionary<string, object>();
            save.Inventory = new Inventory();
            save.Perks = new Dictionary<Perk, bool>();

            try
            {
                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Delve Interactive\\CHANGE"))
                {
                    string[] keys = rk.GetValueNames();
                    foreach (string key in keys)
                    {
                        string keyName = key.Contains("_") ? key.Substring(0, key.LastIndexOf("_")) : key;

                        if (keyName.StartsWith("ITEM"))
                        {
                            int amount = Convert.ToInt32(rk.GetValue(key));
                            save.Inventory.CreateItem(keyName, amount);
                        }
                        else if (keyName.StartsWith("PERK"))
                        {
                            int n = int.Parse(keyName.Substring(4));
                            Perk perk = (Perk)n;
                            bool val = Convert.ToBoolean(rk.GetValue(key));
                            save.Perks.Add(perk, val);
                        }
                        else
                        {
                            var val = rk.GetValue(key);
                            bool valueSet = save.SetValue(keyName.ToLower(), val);
                            if (!valueSet)
                                save.Other.Add(key, val);
                        }
                        RegistryKeyMapper.EnsureKey(key);
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Handle errors
                return null;
            }

            return save;
        }
    }
}
