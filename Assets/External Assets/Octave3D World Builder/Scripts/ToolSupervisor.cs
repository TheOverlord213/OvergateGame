#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace O3DWB
{
    public class ToolSupervisor
    {
        #region Constructors
        public ToolSupervisor()
        {
            #if UNITY_2018_1_OR_NEWER
            EditorApplication.projectChanged -= RemoveNullPrefabReferences;
            EditorApplication.projectChanged += RemoveNullPrefabReferences;
            #else
            EditorApplication.projectWindowChanged -= RemoveNullPrefabReferences;
            EditorApplication.projectWindowChanged += RemoveNullPrefabReferences;
            #endif
        }
        #endregion

        #region Public Static Functions
        public static ToolSupervisor Get()
        {
            if (Octave3DWorldBuilder.ActiveInstance == null) return null;
            return Octave3DWorldBuilder.ActiveInstance.ToolSupervisor;
        }
        #endregion

        #region Public Methods
        public void Supervise()
        {
            RemoveInvalidEntityRefrences();
        }
        #endregion

        #region Private Methods
        private void RemoveInvalidEntityRefrences()
        {
            RemoveNullGameObjectReferences();
        }

        private void RemoveNullGameObjectReferences()
        {
            ObjectSelection.Get().RemoveNullGameObjectEntries();
            Octave3DWorldBuilder.ActiveInstance.PlacementObjectGroupDatabase.RemoveGroupsWithNullParents();
            ObjectSnapping.Get().ObjectSnapMask.RemoveInvalidEntries();
            DecorPaintObjectPlacement.Get().DecorPaintMask.RemoveInvalidEntries();

            /*if(PrefabTagDatabase.Get().ContainsNullEntries())
            {
                Debug.Log("Detected null prefab tag references. This bug has been fixed and should never happen. If you are reading this, please contact me.");

                List<PrefabCategory> allPrefabCategories = PrefabCategoryDatabase.Get().GetAllPrefabCategories();
                foreach(var category in allPrefabCategories)
                {
                    List<Prefab> allPrefabsInCategory = category.GetAllPrefabs();
                    foreach(var prefab in allPrefabsInCategory)
                    {
                        prefab.TagAssociations.RemoveNullEntries();
                    }
                }

                PrefabTagDatabase.Get().RemoveNullEntries();
            }*/
        }

        public void RemoveNullPrefabReferences()
        {
            if (PrefabPreviewTextureCache.Get() == null) return;
            if (PrefabCategoryDatabase.Get() == null) return;
            if (DecorPaintObjectPlacementBrushDatabase.Get() == null) return;
            if (ObjectPlacement.Get() == null) return;

            PrefabPreviewTextureCache.Get().DestroyTexturesForNullPrefabEntries();
            PrefabCategoryDatabase.Get().RemoveNullPrefabEntriesInAllCategories();
            DecorPaintObjectPlacementBrushDatabase.Get().RemoveNullPrefabsFromAllBrushElements();
            ObjectPlacement.Get().PathObjectPlacement.PathSettings.TileConnectionSettings.RemoveNullPrefabReferences();
        }
        #endregion
    }
}
#endif