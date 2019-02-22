using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;
using System;

/* Useful bits of the UI:

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

   Info button: RoundBackBig*
   Roads: ToolbarIconGroup1*
     
     */

namespace TMPEBuildBar.UI
{
    public class UIChameleonButton : UIButton
    {
        // supported screen regions (InfoPanel = at bottom of screen, not info views!!)
        public enum UIScreenRegion { None, Floating, InfoPanel, TSBar, MainToolStrip, ThumbnailBar };

        // internal store of current screen region
        protected UIScreenRegion m_ScreenRegion = UIScreenRegion.None;

        // internal flag; true when component is being dragged
        protected bool m_dragging = false;

        // icon used as foreground (an easier way to interact with separate atlas for fg)
        protected UISprite icon = null;

        // add icon component
        public override void Start()
        {
            Debug.Log("TMPEBB - Chameleon button - start");
            base.Start();
            tooltip = "Chameleon button";
            ScreenRegion = UIScreenRegion.Floating;
            //icon = this.AddUIComponent<UISprite>();
            //icon.size = new Vector2(34,34);
        }

        // disable foreground sprite on main component
        protected override UITextureAtlas.SpriteInfo GetForegroundSprite()
        {
            return null;
        }

        // disable background sprite for info bar region
        protected override UITextureAtlas.SpriteInfo GetBackgroundSprite()
        {
            return (m_ScreenRegion == UIScreenRegion.InfoPanel) ? null : base.GetBackgroundSprite();
        }

        // get/set screen region
        public UIScreenRegion ScreenRegion
        {
            get => m_ScreenRegion;
            set
            {
                Debug.Log("TMPEBB - Chameleon button - screen region setter");
                if (value != m_ScreenRegion)
                {
                    Debug.Log("TMPEBB - Chameleon button - screen region has changed");
                    m_ScreenRegion = value;
                    OnScreenRegionChange();
                }
            }
        }

        // triggered when screen region changes, assimilages button design to region
        protected void OnScreenRegionChange()
        {
            Debug.Log("TMPEBB - Chameleon button on region change");
            switch (m_ScreenRegion)
            {
                case UIScreenRegion.None:
                case UIScreenRegion.Floating:
                    Debug.Log("TMPEBB - Chameleon button - floating");
                    size = new Vector2(46, 46);
                    scaleFactor = 1.0F;
                    SetBgSprites("RoundBackBig");
                    break;
                case UIScreenRegion.TSBar:
                case UIScreenRegion.MainToolStrip:
                    Debug.Log("TMPEBB - Chameleon button - tool strip");
                    size = new Vector2(43, 43);
                    scaleFactor = 1.0F;
                    SetBgSprites("ToolbarIconGroup1");
                    break;
                case UIScreenRegion.ThumbnailBar:
                    Debug.Log("TMPEBB - Chameleon button - thumbnail");
                    size = new Vector2(36, 36);
                    scaleFactor = 1.0F;
                    SetBgSprites("OptionBase");
                    break;
                default:
                    Debug.Log("TMPEBB - Chameleon button - info bar");
                    size = new Vector2(36, 36);
                    scaleFactor = 1.0F;
                    break;
            }
            Invalidate();
        }

        protected void SetBgSprites(string prefix)
        {
            normalBgSprite   = prefix + (prefix == "ToolbarIconGroup1" ? "Normal" : "");
            disabledBgSprite = prefix+"Disabled";
            hoveredBgSprite  = prefix+"Hovered" ;
            pressedBgSprite  = prefix+"Pressed" ;
            focusedBgSprite  = prefix+"Focused" ; 
        }

        protected override void OnClick(UIMouseEventParameter p)
        {
            if (p.buttons.IsFlagSet(UIMouseButton.Left))
            {
                Debug.Log("TMPEBB - Chameleon button - left click");
                ScreenRegion = UIScreenRegion.ThumbnailBar;
                base.OnClick(p);
            }
        }

        protected override void OnMouseDown(UIMouseEventParameter p)
        {
            if (p.buttons.IsFlagSet(UIMouseButton.Right))
            {
                Debug.Log("TMPEBB - Chameleon button - start drag");
                m_dragging = true;
            }
            else
            {
                base.OnMouseDown(p);
            }
        }

        protected override void OnMouseUp(UIMouseEventParameter p)
        {
            if (m_dragging)
            {
                Debug.Log("TMPEBB - Chameleon button - stop drag");
                m_dragging = false;
                // do stuff
            }
            else
            {
                base.OnMouseUp(p);
            }
        }

        protected override void OnMouseMove(UIMouseEventParameter p)
        {
            if (m_dragging)
            {
                //Debug.Log("TMPEBB - Chameleon button - drag move");
                var ratio = UIView.GetAView().ratio;
                position = new Vector3(position.x + (p.moveDelta.x * ratio), position.y + (p.moveDelta.y * ratio), position.z);
                // check screen region
            }
            else
            {
                base.OnMouseMove(p);
            }
        }
    }
}
