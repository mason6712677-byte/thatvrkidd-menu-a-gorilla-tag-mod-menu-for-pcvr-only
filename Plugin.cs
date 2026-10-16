
using BepInEx;
using UnityEngine;
using UnityEngine.XR;

namespace GorillaModMenu
{
    [BepInPlugin("com.mason.gorillamenu",
        "Gorilla Mod Menu", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private bool menuOpen = false;
        private bool previousY = false;

        private void Awake()
        {
            Logger.LogInfo("Mod menu loaded!");
        }

        private void Update()
        {
            InputDevice controller =
                InputDevices.GetDeviceAtXRNode(
                    XRNode.LeftHand);

            bool yPressed = false;

            if (controller.isValid)
            {
                controller.TryGetFeatureValue(
                    CommonUsages.secondaryButton,
                    out yPressed);
            }

            if (yPressed && !previousY)
            {
                menuOpen = !menuOpen;

                Logger.LogInfo(
                    menuOpen
                        ? "Menu opened!"
                        : "Menu closed!");
            }

            previousY = yPressed;
        }
    }
}
