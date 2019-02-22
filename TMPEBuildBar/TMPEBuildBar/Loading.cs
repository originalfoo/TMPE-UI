using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;
using TMPEBuildBar.UI;

namespace TMPEBuildBar
{

    public class Loading : LoadingExtensionBase
    {
        protected LoadMode _loadMode;

        public UIChameleonButton btn;

        public override void OnLevelLoaded(LoadMode mode)
        {
            _loadMode = mode;
            Debug.Log("TMPEBB OnLevelLoaded - check load mode");

            if (!ApplicableLoadMode())
            {
                return;
            }

            Debug.Log("TMPEBB OnLevelLoaded - load mode good");

            try
            {
                Debug.Log("TMPEBB OnLevelLoaded - about to add button");
                // todo: add build bar

                UIComponent parent = UIView.Find("TSBar");

                if (parent == null)
                {
                    Debug.Log("TMPEBB OnLevelLoaded - could not find parent 'TSBar'");
                }

                btn = parent.AddUIComponent<UIChameleonButton>();
                btn.name = "foofoo";
                Debug.Log("TMPEBB OnLevelLoaded - button added");
            }
            catch (Exception e)
            {
                Debug.Log("[TMPEBuildBar] Loading:OnLevelLoaded -> Exception: " + e.Message);
            }
        }

        public override void OnLevelUnloading()
        {
            try
            {
                if (!ApplicableLoadMode())
                {
                    return;
                }

                Debug.Log("TMPEBB UnLevelUnloading");

            }
            catch (Exception e)
            {
                Debug.Log("[TMPEBuildBar] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }

        // Defines which load modes are applicable to the mod
        protected bool ApplicableLoadMode()
        {
            return ( (_loadMode == LoadMode.LoadGame) || (_loadMode == LoadMode.NewGame) || (_loadMode == LoadMode.NewGameFromScenario) );
        }
    }
}