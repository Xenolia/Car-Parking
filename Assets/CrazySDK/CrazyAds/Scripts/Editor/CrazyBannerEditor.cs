using UnityEditor;

#if CRAZY_GSDK
namespace CrazyGames
{
    [CustomEditor(typeof(CrazyBanner))]
    public class CrazyBannerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (CrazyBanner)target;
            var newValue = EditorGUILayout.EnumPopup("Banner size", script.Size);
            script.Size = (CrazyBanner.BannerSize)newValue;
            EditorUtility.SetDirty(target);
        }
    }
}

#endif