using UnityEditor;
using UnityEditor.UI;

namespace Eidtor
{
    [CustomEditor(typeof(SEButton))]
    [CanEditMultipleObjects]
    public class SEButtonEditor : ButtonEditor
    {
        private SerializedProperty _clickSE;

        protected override void OnEnable()
        {
            base.OnEnable();

            _clickSE = serializedObject.FindProperty("_clickSE");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUILayout.PropertyField(_clickSE);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
