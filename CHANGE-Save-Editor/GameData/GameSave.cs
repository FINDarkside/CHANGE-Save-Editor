using CHANGE_Save_Editor.GameData;
using CHANGE_Save_Editor.Helpers;
using System.Collections.Generic;

namespace CHANGE_Save_Editor
{
    public class GameSave : BindableBase
    {
        public int PlayerLevel { get; set; }
        public int CurrentXP { get; set; }

        public int ApplicationsMade { get; set; }
        public int BeerUseCount { get; set; }
        public int BegCount { get; set; }
        public float Cash { get; set; }
        public int CigUseCount { get; set; }
        public int CrimeLevel { get; set; }
        public int DailyPapers { get; set; }
        public int DayCount { get; set; }
        public int DaysWorked { get; set; }
        public float DogHunger { get; set; }
        public float Happiness { get; set; }
        public bool HasDog { get; set; }
        public int HomelessRep { get; set; }
        public float Hunger { get; set; }
        public float Hygiene { get; set; }
        public bool IsSick { get; set; }
        public Inventory Inventory { get; set; }
        public int PoliceWarningCount { get; set; }
        public float Position { get; set; }
        public bool SaveExists { get; set; }
        public int ShelterUseCount { get; set; }
        public float StudyLevel { get; set; }
        public int Seed { get; set; }
        public float TrashCount { get; set; }
        public int TrashUseCount { get; set; }
        public float WorldPosition { get; set; }
        public bool AddictedToDrugs { get; set; }
        public bool IsWinter { get; set; }
        public bool HasGuitar { get; set; }
        public bool HasNewClothes { get; set; }
        public bool HasJob { get; set; }
        public Dictionary<Perk, bool> Perks { get; set; }
        public JobType JobType { get; set; }

        // We need to save the unknown values too to not lose any data
        public Dictionary<string, object> Other { get; set; }
    }
}
