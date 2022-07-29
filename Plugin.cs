using BepInEx;
using HarmonyLib;


#pragma warning disable CS0618
namespace InfiniteTorches
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string ModName = "InfiniteTorches", ModVersion = "0.0.1", ModGUID = "com.Frogger." + ModName + "." + ModVersion;
        private static Harmony harmony = new Harmony(ModGUID);

        public static Plugin _thistype;

        public static bool isInfinite = true;

        private void Awake()
        {
            _thistype = this;
            harmony.PatchAll();
        }



        [HarmonyPatch]
        public static class Path
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.IsBurning))]
            static bool FireplaceIsBurningPatch(bool __result)
            {
                __result = true;
                return isInfinite;
            }
        }
    }
}
