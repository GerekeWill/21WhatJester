using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace __21What
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "KurisuBot.21WhatJester";
        private const string modName = "21What";
        private const string modVersion = "1.0.0";
        public static Plugin instance;
        private readonly Harmony harmony = new Harmony(modGUID);
        internal ManualLogSource mls;
        internal static List<AudioClip> LK;
        internal static AssetBundle Bundle;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource("KurisuBot.21WhatJester");
            mls.LogInfo("21WhatJester Loading . . . ");
            string text = instance.Info.Location;
            text = text.TrimEnd("21WhatJester.dll".ToCharArray());

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);

            LK = new List<AudioClip>();
            Bundle = AssetBundle.LoadFromFile(text + "21What");
            if (Bundle != null)
            {
                LK = Bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                this.mls.LogError("Failed to load asset bundle (21What)");
            }
            mls.LogInfo("21WhatJester Loaded!");

        }
        public static void Log(string message)
        {
            Plugin.instance.Logger.LogInfo(message);
        }
    }
}