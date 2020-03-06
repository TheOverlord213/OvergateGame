#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace O3DWB
{
    [Serializable]
    public class ObjectScaleGizmo : ObjectGizmo
    {
        #region Private Constant Variables
        private const float _minObjectScaleValue = 0.00001f;
        #endregion

        #region Private Variables
        private Vector3 _scaleAccumulatedByGizmoInteraction = Vector3.one;
        #endregion

        #region Public Methods
        public override GizmoType GetGizmoType()
        {
            return GizmoType.Scale;
        }

        public override void RenderHandles(TransformGizmoPivotPoint transformPivotPoint)
        {
            if (CanTransformObjects())
            {
                Vector3 newScaleAccumulatedByGizmoInteraction = Handles.ScaleHandle(_scaleAccumulatedByGizmoInteraction, _worldPosition, _worldRotation, HandleUtility.GetHandleSize(_worldPosition));
                if (newScaleAccumulatedByGizmoInteraction != _scaleAccumulatedByGizmoInteraction)
                {
                    GameObjectExtensions.RecordObjectTransformsForUndo(_targetObjects);
                    List<GameObject> topParents = GameObjectExtensions.GetParents(_targetObjects);

                    Vector3 scaleFactor = CalculateScaleFactorUsedToScaleObjects(newScaleAccumulatedByGizmoInteraction);
                    ScaleObjectsBySpecifiedPivotPoint(transformPivotPoint, scaleFactor, topParents);

                    _scaleAccumulatedByGizmoInteraction = newScaleAccumulatedByGizmoInteraction;
                    GizmoTransformedObjectsMessage.SendToInterestedListeners(this);
                }
            }
        }
        #endregion

        #region Private Methods
        private void ScaleObjectsBySpecifiedPivotPoint(TransformGizmoPivotPoint scalePivotPoint, Vector3 scaleFactor, List<GameObject> gameObjectsToScale)
        {
            if (scalePivotPoint == TransformGizmoPivotPoint.Pivot) ScaleObjectsByPivot(scaleFactor, gameObjectsToScale);
            else ScaleObjectsByGizmoPosition(scaleFactor, gameObjectsToScale);
        }

        private Vector3 CalculateScaleFactorUsedToScaleObjects(Vector3 newAccumulatedScaleByGizmoInteraction)
        {
            return Vector3.Scale(newAccumulatedScaleByGizmoInteraction, _scaleAccumulatedByGizmoInteraction.GetInverse());
        }

        private void ScaleObjectsByPivot(Vector3 scaleFactor, List<GameObject> gameObjectsToScale)
        {
            foreach (GameObject gameObject in gameObjectsToScale)
            {
                Transform gameObjectTransform = gameObject.transform;
                gameObjectTransform.localScale = CalculateNewObjectScale(gameObjectTransform.localScale, scaleFactor);
            }
        }

        private Vector3 CalculateNewObjectScale(Vector3 currentObjectScale, Vector3 scaleFactor)
        {
            Vector3 newObjectScale = Vector3.Scale(currentObjectScale, scaleFactor);
            newObjectScale.ReplaceCoordsValueWith(0.0f, _minObjectScaleValue);

            return newObjectScale;
        }

        private void ScaleObjectsByGizmoPosition(Vector3 scaleFactor, List<GameObject> gameObjectsToScale)
        {
            foreach (GameObject gameObject in gameObjectsToScale)
            {
                Transform gameObjectTransform = gameObject.transform;

                gameObjectTransform.localScale = CalculateNewObjectScale(gameObjectTransform.localScale, scaleFactor);
                ScaleObjectDistanceFromGizmoPosition(scaleFactor, gameObjectTransform);
            }
        }

        private void ScaleObjectDistanceFromGizmoPosition(Vector3 scaleFactor, Transform gameObjectTransform)
        {
            Vector3 gizmoToObject = gameObjectTransform.position - _worldPosition;
            gameObjectTransform.position = _worldPosition + Vector3.Scale(gizmoToObject, scaleFactor);
        }
        #endregion
    }
}
#endif