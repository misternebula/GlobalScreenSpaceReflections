using OWML.ModHelper;

namespace GlobalScreenSpaceReflections;
public class GlobalScreenSpaceReflections : ModBehaviour
{
	private void Start()
	{
		ModHelper.HarmonyHelper.AddPostfix<PlayerCameraController>(nameof(PlayerCameraController.Start), typeof(Patches), nameof(Patches.PlayerCameraController_Start));
		ModHelper.HarmonyHelper.AddPostfix<DreamWorldController>(nameof(DreamWorldController.FixedUpdate), typeof(Patches), nameof(Patches.DreamWorldController_FixedUpdate));
	}
}

public static class Patches
{
	public static void PlayerCameraController_Start(PlayerCameraController __instance)
	{
		__instance._playerCamera.postProcessingSettings.screenSpaceReflectionAvailable = true;
		__instance._playerCamera.postProcessingSettings._screenSpaceReflectionEnabled = true;
	}

	public static void DreamWorldController_FixedUpdate(DreamWorldController __instance)
	{
		__instance._playerCamera.postProcessingSettings.screenSpaceReflectionAvailable = true;
	}
}

