using CHANGE_Save_Editor.GameData;
using CHANGE_Save_Editor.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace CHANGE_Save_Editor
{
    public static class RegistrySaveManager
    {

        public static void Save(GameSave save)
        {
            //ClearSave();
            var values = save.GetValues();
            using (var re = new RegistryEditor("Software\\Delve Interactive\\CHANGE"))
            {
                foreach (var kvp in values)
                {
                    var key = RegistryKeyMapper.GetKey(kvp.Key);
                    re.SetValue(key, kvp.Value);
                }
                save.Unknown.ForEach(item => re.SetValue(item.Key, item.Value));
                foreach (var kvp in save.Perks)
                {
                    var key = RegistryKeyMapper.GetKey("perk_" + kvp.Key.ToString());
                    re.SetValue(key, kvp.Value ? 1 : 0);
                }
                foreach (var item in save.Inventory.Items)
                {
                    var key = RegistryKeyMapper.GetKey("item_" + item.name);
                    re.SetValue(key, item.amount);
                }
            }
        }

        public static GameSave Load()
        {
            GameSave save = new GameSave();
            save.Unknown = new Dictionary<string, object>();
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
                        keyName = keyName.ToLower();

                        if (keyName.StartsWith("item_"))
                        {
                            int amount = Convert.ToInt32(rk.GetValue(key));
                            string name = keyName.Substring(4, keyName.Length - 4);
                            name = name[0].ToString().ToUpper() + name.Substring(1);
                            save.Inventory.CreateItem(name, amount);
                        }
                        else if (keyName.StartsWith("perk_"))
                        {
                            int n = int.Parse(keyName.Substring(4));
                            if (n >= Enum.GetValues(typeof(Perk)).Length)
                            {
                                save.Unknown.Add(key, rk.GetValue(key));
                            }
                            else
                            {
                                Perk perk = (Perk)n;
                                bool val = Convert.ToBoolean(rk.GetValue(key));
                                save.Perks.Add(perk, val);
                            }

                        }
                        else
                        {
                            var val = rk.GetValue(key);
                            bool valueSet = save.SetValue(keyName, val);
                            if (!valueSet)
                                save.Unknown.Add(key, val);
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

        public static void ClearSave()
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Delve Interactive\\CHANGE", true))
            {
                rk.GetValueNames().ForEach(name => rk.DeleteValue(name));
            }
        }
    }
}
