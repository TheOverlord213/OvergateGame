#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace O3DWB
{
    public class ObjectMassEraseOperation : IObjectEraseOperation
    {
        #region Public Methods
        public void Perform()
        {
            List<GameObject> gameObjectsForMassEraseOperation = ObjectEraser.Get().GetGameObjectsForMassEraseOperation();
            
            bool eraseEntireHierarchy = !AllShortcutCombos.Instance.EraseIndividualObjects.IsActive();
            if (eraseEntireHierarchy) ObjectErase.EraseObjectHierarchiesInObjectCollection(gameObjectsForMassEraseOperation);
            else ObjectErase.EraseGameObjectCollection(gameObjectsForMassEraseOperation);
        }
        #endregion
    }
}
#endif