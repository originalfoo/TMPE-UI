using ColossalFramework.UI;
using UnityEngine;

namespace TMPEBuildBar
{
    public class UI
    {
        public static UIButton CreateButton(UIComponent parent, string name)
        {
            UIButton newButton = parent.AddUIComponent<UIButton>();

            newButton.name = name;

            /*
            newButton.normalBgSprite   = name+"Normal";
            newButton.hoveredBgSprite  = name+"Hover";
            newButton.pressedBgSprite  = name+"Press";
            newButton.disabledBgSprite = name+"Disable";
            newButton.focusedBgSprite  = name+"Focus";
            */

            // newButton.relativePosition = new Vector3(5f, 0f);

            /*
            newButton.size = new Vector2(50f, 50f);
            newButton.text = "some text";
            newButton.textScale = 1.3f;
            newButton.disabledTextColor = new Color32(128, 128, 128, 255);
            newButton.textVerticalAlignment = UIVerticalAlignment.Middle;
            newButton.textHorizontalAlignment = UIHorizontalAlignment.Center;
            */

            return newButton;
        }

    }
}
