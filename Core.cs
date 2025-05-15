using MelonLoader;
using HarmonyLib;

[assembly: MelonInfo(typeof(EOWMod.Core), "EOWMod", "1.0.0", "DohmBoy64", null)]
[assembly: MelonGame("Fallen Tree Games Ltd", "The Precinct")]

namespace EOWMod
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            var harmony = new HarmonyLib.Harmony("com.eowmod.patch");
            harmony.PatchAll();
            LoggerInstance.Msg("Initialized with civilian patches.");
        }
    }
}