using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DSC.Core;

namespace DSC.UI.Editor
{
    public class ContextUI
    {
        [MenuItem("GameObject/DSC/UI/Modify/Change scale to one", false, 20)]
        static void ScaleToOne(MenuCommand hCommand)
        {
            if (!(hCommand.context is GameObject hGameObject)
                || !hGameObject.TryGetComponent(out RectTransform hRect))
                return;

            Vector3 vScale = hRect.localScale;
            hRect.sizeDelta *= MathUtility.Abs(vScale);
            hRect.localScale = MathUtility.ToOne(vScale);
        }

        [MenuItem("GameObject/DSC/UI/Modify/HD to 4K", false, 20)]
        static void HDto4K(MenuCommand hCommand)
        {
            if (!(hCommand.context is GameObject hGameObject)
                || !hGameObject.TryGetComponent(out RectTransform hRect))
                return;
            
            hRect.sizeDelta *= 4;
        }
    }
}
