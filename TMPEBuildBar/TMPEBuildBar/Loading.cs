using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace TMPEBuildBar
{

    public class Loading : LoadingExtensionBase
    {
        private LoadMode _loadMode;
        private GameObject _gameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _loadMode = mode;

                if (!ApplicableLoadMode())
                {
                    return;
                }

                // tood: add build bar

                // UI.CreateButton();

                Debug.Log("TMPEBB OnLevelLoaded");

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

                if (_gameObject == null)
                {
                    return;
                }

                UnityEngine.Object.Destroy(_gameObject);
            }
            catch (Exception e)
            {
                Debug.Log("[TMPEBuildBar] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }

        // Defines which load modes are applicable to the mod
        public bool ApplicableLoadMode()
        {
            return (_loadMode != LoadMode.LoadGame || _loadMode != LoadMode.NewGame || _loadMode != LoadMode.NewGameFromScenario);
        }
    }
}