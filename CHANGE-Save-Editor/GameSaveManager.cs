using CHANGE_Save_Editor.GameData;
using CHANGE_Save_Editor.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace CHANGE_Save_Editor
{
    public class GameSaveManager
    {
        private string savePath;

        private Dictionary<string, string> registryKeys = new Dictionary<string, string>();

        public GameSaveManager(string savePath)
        {
            this.savePath = savePath;
        }


    }
}
