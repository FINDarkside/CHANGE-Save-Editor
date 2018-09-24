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
            registryKeys.Add("unity.cloud_userid", "unity.cloud_userid_h2665564582");
            registryKeys.Add("unity.player_sessionid", "unity.player_sessionid_h1351336811");
            registryKeys.Add("saveexists", "saveExists_h663925892");
            registryKeys.Add("theseed", "theSeed_h1942587115");
            registryKeys.Add("hunger", "hunger_h1600073190");
            registryKeys.Add("happiness", "happiness_h1331119438");
            registryKeys.Add("hygiene", "hygiene_h1105579220");
            registryKeys.Add("cash", "cash_h2087764572");
            registryKeys.Add("savedposition", "savedPosition_h4026958969");
            registryKeys.Add("crimelevel", "crimeLevel_h4052719107");
            registryKeys.Add("homelessrep", "homelessRep_h2863141764");
            registryKeys.Add("hasdog", "hasDog_h1586493043");
            registryKeys.Add("daycount", "dayCount_h1193350458");
            registryKeys.Add("issick", "isSick_h1644493197");
            registryKeys.Add("trashcount", "trashCount_h4226913402");
            registryKeys.Add("doghunger", "dogHunger_h1372439594");
            registryKeys.Add("studylevel", "studyLevel_h532418140");
            registryKeys.Add("policewarningcount", "policeWarningCount_h1658425008");
            registryKeys.Add("dailypapers", "dailyPapers_h3089021465");
            registryKeys.Add("daysworked", "daysWorked_h1369404618");
            registryKeys.Add("applicationsmade", "applicationsMade_h837912897");
            registryKeys.Add("shelterusecount", "shelterUseCount_h715135892");
            registryKeys.Add("begcount", "begCount_h3868527654");
            registryKeys.Add("trashusecount", "trashUseCount_h2044720217");
            registryKeys.Add("cigusecount", "cigUseCount_h444936264");
            registryKeys.Add("beerusecount", "beerUseCount_h728153813");
            registryKeys.Add("jobtype", "jobType_h3392964378");
            registryKeys.Add("screenmanager resolution width", "Screenmanager Resolution Width_h182942802");
            registryKeys.Add("screenmanager resolution height", "Screenmanager Resolution Height_h2627697771");
            registryKeys.Add("screenmanager fullscreen mode", "Screenmanager Fullscreen mode_h3630240806");
            registryKeys.Add("screenmanager resolution use native", "Screenmanager Resolution Use Native_h1405027254");
            registryKeys.Add("worldposition", "worldPosition_h1044188958");
            registryKeys.Add("vsync", "Vsync_h224880020");
            registryKeys.Add("autoeat", "AutoEat_h888103098");
            registryKeys.Add("faststart", "FastStart_h2209012325");
            registryKeys.Add("musicvolume", "MusicVolume_h3041295148");
            registryKeys.Add("sfxvolume", "SFXVolume_h2009793184");
            registryKeys.Add("mastervolume", "MasterVolume_h2602803985");
            registryKeys.Add("resolution", "Resolution_h2981718891");
            registryKeys.Add("postprocessing", "PostProcessing_h1186065430");
            registryKeys.Add("item_trash", "ITEM_TRASH_h330926739");
            registryKeys.Add("unityselectmonitor", "UnitySelectMonitor_h17969598");
            registryKeys.Add("unitygraphicsquality", "UnityGraphicsQuality_h1669003810");
            registryKeys.Add("addictedtodrugs", "addictedToDrugs_h430477687");
            registryKeys.Add("iswinter", "isWinter_h3990835468");
            registryKeys.Add("hasguitar", "hasGuitar_h2509770467");
            registryKeys.Add("hasnewclothes", "hasNewClothes_h3559656041");
            registryKeys.Add("playerlevel", "PlayerLevel_h4113798944");
            registryKeys.Add("currentxp", "CurrentXP_h2254539972");
            registryKeys.Add("item_sandwich", "ITEM_SANDWICH_h2825495714");
            registryKeys.Add("item_sausageroll", "ITEM_SAUSAGEROLL_h2959958405");
            registryKeys.Add("item_fruit", "ITEM_FRUIT_h306255955");
            registryKeys.Add("item_crisps", "ITEM_CRISPS_h1790518535");
            registryKeys.Add("item_dogfood", "ITEM_DOGFOOD_h838605281");
            registryKeys.Add("item_beer", "ITEM_BEER_h1961661887");
            registryKeys.Add("item_mealdeal", "ITEM_MEALDEAL_h1977082470");
            registryKeys.Add("item_deodorant", "ITEM_DEODORANT_h3256137667");
            registryKeys.Add("item_cigarettes", "ITEM_CIGARETTES_h2485419746");
            registryKeys.Add("item_newclothes", "ITEM_NEWCLOTHES_h4009134297");
            registryKeys.Add("item_sleepingbag", "ITEM_SLEEPINGBAG_h4254542564");
            registryKeys.Add("item_guitar", "ITEM_GUITAR_h1637461299");
            registryKeys.Add("item_papers", "ITEM_PAPERS_h2511391946");
            registryKeys.Add("item_coffee", "ITEM_COFFEE_h1754375427");
            registryKeys.Add("item_chocolate", "ITEM_CHOCOLATE_h2952368603");
            registryKeys.Add("item_hotdog", "ITEM_HOTDOG_h1571202224");
            registryKeys.Add("item_scratchcard", "ITEM_SCRATCHCARD_h2522366439");
            registryKeys.Add("item_newshoes", "ITEM_NEWSHOES_h319808145");
            registryKeys.Add("item_wintercoat", "ITEM_WINTERCOAT_h3628820869");
            registryKeys.Add("item_sanitizer", "ITEM_SANITIZER_h3328746666");
            registryKeys.Add("item_hat", "ITEM_HAT_h59442130");
            registryKeys.Add("item_gloves", "ITEM_GLOVES_h1603964779");
            registryKeys.Add("item_pills", "ITEM_PILLS_h336138053");
            registryKeys.Add("item_biggerbag", "ITEM_BIGGERBAG_h902569687");
            registryKeys.Add("item_tie", "ITEM_TIE_h59463639");
            registryKeys.Add("item_textbook", "ITEM_TEXTBOOK_h911507579");
            registryKeys.Add("item_readingglasses", "ITEM_READINGGLASSES_h1719644577");
            registryKeys.Add("item_guitarpick", "ITEM_GUITARPICK_h3294533442");
            registryKeys.Add("item_buspass", "ITEM_BUSPASS_h3554278266");
            registryKeys.Add("item_cup", "ITEM_CUP_h59448009");
            registryKeys.Add("item_soap", "ITEM_SOAP_h1962331522");
            registryKeys.Add("item_tent", "ITEM_TENT_h1962312452");
            registryKeys.Add("perk0", "PERK0_h231059353");
            registryKeys.Add("perk1", "PERK1_h231059352");
            registryKeys.Add("perk2", "PERK2_h231059355");
            registryKeys.Add("perk3", "PERK3_h231059354");
            registryKeys.Add("perk4", "PERK4_h231059357");
            registryKeys.Add("perk5", "PERK5_h231059356");
            registryKeys.Add("perk6", "PERK6_h231059359");
            registryKeys.Add("perk7", "PERK7_h231059358");
            registryKeys.Add("perk8", "PERK8_h231059345");
            registryKeys.Add("perk9", "PERK9_h231059344");
            registryKeys.Add("perk10", "PERK10_h3329991336");
            registryKeys.Add("perk11", "PERK11_h3329991337");
            registryKeys.Add("perk12", "PERK12_h3329991338");
            registryKeys.Add("perk13", "PERK13_h3329991339");
            registryKeys.Add("perk14", "PERK14_h3329991340");
            registryKeys.Add("perk15", "PERK15_h3329991341");
            registryKeys.Add("perk16", "PERK16_h3329991342");
            registryKeys.Add("perk17", "PERK17_h3329991343");
            registryKeys.Add("perk18", "PERK18_h3329991328");
            registryKeys.Add("perk19", "PERK19_h3329991329");
            registryKeys.Add("perk20", "PERK20_h3329991371");
            registryKeys.Add("perk21", "PERK21_h3329991370");
            registryKeys.Add("perk22", "PERK22_h3329991369");
            registryKeys.Add("perk23", "PERK23_h3329991368");
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
