
using BepInEx;
using UnityEngine;
using UnityEngine.XR;

namespace GorillaModMenu
{
    [BepInPlugin("com.mymods.gorillamenu",
                 "Gorilla Mod Menu", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private bool menuOpen = false;
        private bool lastYState = false;

        private void Awake()
        {
            Logger.LogInfo("Gorilla Mod Menu loaded!");
        }

        private void Update()
        {
            InputDevice leftController =
                InputDevices.GetDeviceAtXRNode(
                    XRNode.LeftHand);

            bool yPressed = false;

            if (leftController.isValid)
            {
                leftController.TryGetFeatureValue(
                    CommonUsages.secondaryButton,
                    out yPressed);
            }

            // Toggle once per button press
            if (yPressed && !lastYState)
            {
                menuOpen = !menuOpen;

                Logger.LogInfo(
                    menuOpen ? "Menu OPEN" : "Menu CLOSED");
            }

            lastYState = yPressed;
        }
    }
}
