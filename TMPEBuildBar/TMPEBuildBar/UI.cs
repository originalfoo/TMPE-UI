using ColossalFramework.UI;
using UnityEngine;

namespace TMPEBuildBar
{
    /* Useful bits of the UI

       * UISlicedSprite ThumbnailBar = the bar where advisor button goes
       * UISlicedSprite TSBar = Tool strip bar (Icon WxH: 43x49)
           * UITabStrip MainToolStrip = where roads..policies buttons live
               * UIButton * = a button
               * UISprite Separator = a gap in the buttons
           * UITabContainer TSContainer = where tabbed tool strips live
               * UIPanel UIPanel = tab bar
               * UIPanel UIPanel = tool panel, eg. roads menu (Icon: WxH: 109x100)
           * UIPanel OptionsBar = where option buttons go (eg. curved road button when roads menu is open)
       * UIPanel InfoPanel = RICO graphs, population, etc. (Icon WxH: 36x36)
    */
    public class UIX
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
