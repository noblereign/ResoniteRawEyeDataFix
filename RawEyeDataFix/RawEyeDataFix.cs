using FrooxEngine;
using FrooxEngine.CommonAvatar;
using HarmonyLib;
using ResoniteModLoader;

namespace RawEyeDataFix;

public class RawEyeDataFix : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0"; //Changing the version here updates it in all locations needed
	public override string Name => "RawEyeDataFix";
	public override string Author => "Noble";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/noblereign/ResoniteRawEyeDataFix/";

	const string harmonyId = "dog.glacier.RawEyeDataFix";

	public static ModConfiguration? Config;

	[AutoRegisterConfigKey]
	public static readonly ModConfigurationKey<bool> Enabled = new("Enabled", "Enables the fix", () => true);

	public override void OnEngineInit() {
		Config = GetConfiguration()!;
		Config!.Save(true);
		Setup();
	}

	static void Setup() {
		Harmony harmony = new Harmony(harmonyId);
		harmony.PatchAll();
	}

	[HarmonyPatch(typeof(AvatarRawEyeData), "OnCommonUpdate")]
	class AvatarRawEyeData_OnCommonUpdate_Patch {
		static bool Prefix(AvatarRawEyeData __instance) {
			if (!Config!.GetValue(Enabled)) return true;

			if (__instance._activeUser.Target == __instance.LocalUser) {
				Eyes eyes = __instance.InputInterface.GetDevice((Eyes eyes2) => eyes2.IsEyeTrackingActive);
				if (eyes != null) {
					__instance.ConvergenceDistance.Value = eyes.ConvergenceDistance;
					__instance.Timestamp.Value = eyes.Timestamp;
					__instance.LeftEye.UpdateFromEye(eyes.LeftEye);
					__instance.RightEye.UpdateFromEye(eyes.RightEye);
					__instance.CombinedEye.UpdateFromEye(eyes.CombinedEye);
				}
			}

			return false;
		}
	}
}
