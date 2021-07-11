using System;
using System.Collections;
using MelonLoader;
using UnityEngine;
using VRC;
using VRC.UI;

namespace ForceClone
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(UiManagerInitializer());
        }

        private IEnumerator UiManagerInitializer()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
                yield return null;

            OnUiManagerInit();
        }

        private void OnUiManagerInit()
        {
            Utils.CreateDefaultButton("Force Clone Avatar", "Force Clone Public Avatars", Color.white, 0, 1,
                QuickMenu.prop_QuickMenu_0.transform.Find("UserInteractMenu"), new Action(() =>
            {
                string avatarID = QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar.id;

                if (QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar.releaseStatus != "private")
                {
                    MelonLogger.Msg("Force Cloning avatar with ID: " + avatarID);
                    new PageAvatar
                    {
                        field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                        {
                            field_Internal_ApiAvatar_0 = QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar
                        }
                    }.ChangeToSelectedAvatar();
                    VRCUiManager.prop_VRCUiManager_0.Method_Public_Void_Boolean_1(false);
                }
                else
                {
                    MelonLogger.Msg("Avatar ID " + avatarID + " is private!");
                }
            }));
        }
    }
}
