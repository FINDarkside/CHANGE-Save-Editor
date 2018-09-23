using CHANGE_Save_Editor.GameData;
using CHANGE_Save_Editor.Helpers;
using Microsoft.Win32;
using System;

namespace CHANGE_Save_Editor
{
    public static class RegistrySaveManager
    {

        public static GameSave Load()
        {
            GameSave save = new GameSave();
            save.Inventory = new Inventory();
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
                        else if (keyName.StartsWith("PERKS"))
                        {
                            int n = int.Parse(keyName.Substring(5));
                            Perk perk = (Perk)n;
                            bool val = Convert.ToBoolean(rk.GetValue(key));
                            save.Perks.Add(perk, val);
                        }
                        else
                        {
                            var val = rk.GetValue(key);
                            save.SetValue(keyName.ToLower(), val);
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
