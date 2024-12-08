using __21What;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21What.Patches
{
    [HarmonyPatch(typeof(JesterAI))]
    internal class JesterMusicPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void Gohan(JesterAI __instance)
        {
            __instance.popGoesTheWeaselTheme = Plugin.LK[0];
            Plugin.Log("************JESTER SUCCESSFULLY PATCHED************");
        }
    }
}
