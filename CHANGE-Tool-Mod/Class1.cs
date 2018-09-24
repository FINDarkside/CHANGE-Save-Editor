using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CHANGE_Tool_Mod
{
    public class ToolMod
    {

        public static void Start()
        {


            try
            {

            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                File.WriteAllText(@"./crash.txt", s);

            }

        }

        private static void UpdateRegistryKeys()
        {
            var backup = TakeBackup();

            SetAllValues();

            string[] keys = new string[0];
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Delve Interactive\\CHANGE"))
            {
                keys = rk.GetValueNames();
            }


            string result = "";
            foreach (var key in keys)
            {
                string name = key.Substring(0, key.LastIndexOf("_")).ToLower();
                result += "registryKeys.Add(\"" + name + "\", \"" + key + "\");\n";
            }

            File.WriteAllText("./registryKeys.txt", result);

            ApplyBackup(backup);
        }



        private static void SetAllValues()
        {
            // GameManager
            PlayerPrefs.SetInt("saveExists", 1);
            PlayerPrefs.SetInt("theSeed", 0);
            PlayerPrefs.SetFloat("hunger", 0);
            PlayerPrefs.SetFloat("happiness", 0);
            PlayerPrefs.SetFloat("hygiene", 0);
            PlayerPrefs.SetFloat("cash", 0);
            PlayerPrefs.SetFloat("savedPosition", 0);
            PlayerPrefs.SetInt("crimeLevel", 0);
            PlayerPrefs.SetInt("homelessRep", 0);
            PlayerPrefs.SetInt("hasDog", 0);
            PlayerPrefs.SetInt("dayCount", 0);
            PlayerPrefs.SetInt("isSick", 0);
            PlayerPrefs.SetFloat("trashCount", 0);
            PlayerPrefs.SetFloat("dogHunger", 0);
            PlayerPrefs.SetFloat("studyLevel", 0);
            PlayerPrefs.SetInt("policeWarningCount", 0);
            PlayerPrefs.SetInt("addictedToDrugs", 1);
            PlayerPrefs.SetInt("isWinter", 1);
            PlayerPrefs.SetInt("hasGuitar", 1);
            PlayerPrefs.SetInt("hasNewClothes", 1);
            PlayerPrefs.SetInt("dailyPapers", Tramp.dailyIssueCount);
            PlayerPrefs.SetInt("daysWorked", 0);
            PlayerPrefs.SetInt("applicationsMade", 0);
            PlayerPrefs.SetInt("shelterUseCount", 0);
            PlayerPrefs.SetInt("begCount", 0);
            PlayerPrefs.SetInt("trashUseCount", 0);
            PlayerPrefs.SetInt("cigUseCount", 0);
            PlayerPrefs.SetInt("beerUseCount", 0);
            InventoryManager.instance.SaveData();
            PlayerPrefs.SetInt("jobType", 1);

            // PauseMenu
            PlayerPrefs.SetInt("Vsync", 1);
            PlayerPrefs.SetInt("AutoEat", 1);
            PlayerPrefs.SetInt("FastStart", 1);
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.SetFloat("SFXVolume", 1);
            PlayerPrefs.SetFloat("MasterVolume", 1);
            PlayerPrefs.SetInt("Resolution", 1);
            PlayerPrefs.SetInt("PostProcessing", 1);

            // ProgressionManager
            PlayerPrefs.SetInt("PlayerLevel", 0);
            PlayerPrefs.SetInt("CurrentXP", 0);

            foreach (var item in Enum.GetValues(typeof(ITEM_TYPES)))
            {
                string name = "ITEM_" + item.ToString();
                PlayerPrefs.SetInt(name, 0);
            }

            foreach (var trait in Enum.GetValues(typeof(GameManager.thePerks)))
            {
                PlayerPrefs.SetInt("PERK" + (int)trait, 0);
            }
        }


        private static List<KeyValuePair<string, object>> TakeBackup()
        {
            var backup = new List<KeyValuePair<string, object>>();
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Delve Interactive\\CHANGE"))
            {
                string[] keys = rk.GetValueNames();
                foreach (string key in keys)
                {
                    backup.Add(new KeyValuePair<string, object>(key, rk.GetValue(key)));
                }
            }
            return backup;
        }

        private static void ApplyBackup(List<KeyValuePair<string, object>> backup)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Delve Interactive\\CHANGE", true))
            {
                string[] keys = rk.GetValueNames();
                foreach (string key in keys)
                {
                    rk.DeleteValue(key);
                }
                foreach (var item in backup)
                {
                    rk.SetValue(item.Key, item.Value);
                }
            }

        }
    }
}
